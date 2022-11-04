using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Workshop.Web.Data.Entities;
using Workshop.Web.Helpers;
using Workshop.Web.Models.ViewModels;

namespace Workshop.Web.Controllers
{
    public class AccountController : Controller
    {
        readonly IUserHelper _userHelper;
        readonly IConfiguration _configuration;
        readonly IImageHelper _imageHelper;
        readonly IMailHelper _mailHelper;
        public AccountController (IUserHelper userHelper, IConfiguration configuration, IImageHelper imageHelper, IMailHelper mailHelper)
        {
            _userHelper = userHelper;
            _configuration = configuration;
            _imageHelper = imageHelper;
            _mailHelper = mailHelper;
        }

        public IActionResult Login ()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Failed to Login");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {

            var user = await _userHelper.GetUserByEmailAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.Username);
                if(user == null)
                {
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Username,
                        UserName = model.Username,
                        RegisterDate = DateTime.Now,
                        ImagePath = "~/img/users/default.png"
                    };

                    var result = await _userHelper.AddUserAsync(user, model.Password);
                    if (result != IdentityResult.Success)
                    {
                        ModelState.AddModelError(string.Empty, "The user could not be created!");
                        return View (model);
                    }

                    await _userHelper.AddUserToRoleAsync(user, "Client");
                    string newToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                    string tokenLink = Url.Action("ConfirmEmail", "Account", new
                    {
                        userId = user.Id,
                        token = newToken
                    }, protocol: HttpContext.Request.Scheme);

                    Response response = _mailHelper.SendEmail(model.Username, "Email Confirmation", "<h1>Email Confirmation</h1>" +
                        "Thank you for registering!\n" +
                        "Before using your account, please confirm your account by clicking on <a href=\"" + tokenLink + "\">this</a> link!");

                    if (response.IsSuccess)
                    {
                        ViewBag.Message = "An email has been sent with instructions on how to activate your account!";
                        return View(model);
                    }

                    ModelState.AddModelError(string.Empty, "The user could not be logged!");
                }
            }
            return View(model);
        }

        public IActionResult RegisterWorker ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterWorker (RegisterWorkerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.Username);
                if (user == null)
                {
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Username,
                        UserName = model.Username,
                        RegisterDate = DateTime.Now,
                        ImagePath = "~/img/users/default.png"
                    };

                    var result = await _userHelper.AddUserAsync(user, model.Password);
                    if (result != IdentityResult.Success)
                    {
                        ModelState.AddModelError(string.Empty, "The user could not be created!");
                        return View(model);
                    }

                    await _userHelper.AddUserToRoleAsync(user, model.Type);
                    var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                    await _userHelper.ConfirmEmailAsync(user, token);

                    ViewBag.Message = "Account successfully created!";

                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateUser ()
        {
            var user = await _userHelper.GetUserByEmailAsync(User.Identity.Name);
            var model = new ChangeUserViewModel();
            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser (ChangeUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(User.Identity.Name);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    if(model.ImageFile != null)
                    {
                        user.ImagePath = await _imageHelper.UploadImageAsync(model.ImageFile, "users");
                    }
                    var response = await _userHelper.UpdateUserAsync(user);

                    if (response.Succeeded)
                    {
                        return RedirectToAction("Profile");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
                    }
                }
            }

            return View(model);
        }

        public IActionResult ChangePassword ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword (ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(User.Identity.Name);
                if(user != null)
                {
                    var result = await _userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ChangeUser");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not Found!");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken ([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.Username);
                if(user != null)
                {
                    var result = await _userHelper.ValidatePasswordAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Tokens:Issuer"],
                            _configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(15),
                            signingCredentials: credentials);
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return Created(string.Empty, results);
                    }
                }
            }
            return BadRequest();
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }
            var user = await _userHelper.GetUserByIdAsync(userId);
            if(user == null)
            {
                return NotFound();
            }

            var result = await _userHelper.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
            {

            }

            return View();
        }
    }
}
