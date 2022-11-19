using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Workshop.Web.Data.Entities;
using Workshop.Web.Helpers;

namespace Workshop.Web.Data
{
    public class SeedDb
    {
        readonly DataContext _context;
        readonly IUserHelper _userHelper;
        readonly Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Mechanic");
            await _userHelper.CheckRoleAsync("Worker");
            await _userHelper.CheckRoleAsync("Client");

            User user = null;

            if (!_context.Users.Any())
            {
                user = await AddUser("rodrigooliveirapina@gmail.com", "Rodrigo", "Pina", "915775299", "Admin");
                await AddUser("pinossaur@gmail.com", "Pina", "Dinossauro", "915775299", "Mechanic");
                await AddUser("andrepina@gmail.com", "Andre", "Pina", "915775299", "Worker");
            }

            List<Car> cars = new List<Car>();
            if (!_context.Cars.Any())
            {
                cars.Add(AddCar("BMW", "i8", "12-AB-34", "~/img/cars/default.png", user));
                cars.Add(AddCar("Honda", "Civic", "21-BA-43", "~/img/cars/default.png", user));
                cars.Add(AddCar("Opel", "Corsa", "42-XZ-11", "~/img/cars/default.png", user));
                cars.Add(AddCar("Ford", "Focus", "99-FJ-61", "~/img/cars/default.png", user));
            }

            if (!_context.Schedules.Any())
            {
                AddSchedule("New Car", DateTime.Today, cars[0]);
                AddSchedule("Old Car", DateTime.Today, cars[1]);
                AddSchedule("Decent Car", DateTime.Today, cars[2]);
                AddSchedule("Random Car", DateTime.Today, cars[3]);
            }

            await _context.SaveChangesAsync();
        }

        async Task<User> AddUser(string email, string firstName, string lastName, string phoneNumber, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phoneNumber,
                    RegisterDate = DateTime.Now,
                    ImagePath = "~/img/users/default.png"
                };

                var result = await _userHelper.AddUserAsync(user, "WorkShop2022.");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, role);
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

                if (role == "Mechanic")
                {
                    _context.Mechanics.Add(new Mechanic
                    {
                        EnterHour = 10,
                        EnterMinute = 0,
                        LeaveHour = 18,
                        LeaveMinute = 0,
                        User = user
                    });
                }
                return user;
            }
            return null;
        }

        Car AddCar(string brand, string model, string licensePlate, string imagePath, User user)
        {
            Car car = new Car
            {
                Brand = brand,
                Model = model,
                Year = _random.Next(1990, DateTime.Now.Year),
                LicensePlate = licensePlate,
                ImagePath = imagePath,
                User = user
            };

            _context.Cars.Add(car);

            return car;
        }

        void AddSchedule(string description, DateTime date, Car car)
        {
            _context.Schedules.Add(new Schedule
            {
                Description = description,
                StartDate = date,
                Car = car
            });
        }
    }
}