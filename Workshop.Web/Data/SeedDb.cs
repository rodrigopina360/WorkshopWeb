using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var user = await _userHelper.GetUserByEmailAsync("rodrigooliveirapina@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Rodrigo",
                    LastName = "Pina",
                    Email = "rodrigooliveirapina@gmail.com",
                    UserName = "rodrigooliveirapina@gmail.com",
                    PhoneNumber = "915775299"
                };

                var result = await _userHelper.AddUserAsync(user, "WorkShop2022.");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            List<Car> cars = new List<Car>();
            cars.Add(new Car
            {
                Brand = "BMW",
                Model = "i8",
                Year = _random.Next(1990, DateTime.Now.Year),
                LicensePlate = "12-AB-34",
                User = user
            });
            cars.Add(new Car
            {
                Brand = "Honda",
                Model = "Civic",
                Year = _random.Next(1990, DateTime.Now.Year),
                LicensePlate = "21-BA-43",
                User = user
            });
            cars.Add(new Car
            {
                Brand = "Opel",
                Model = "Corsa",
                Year = _random.Next(1990, DateTime.Now.Year),
                LicensePlate = "42-XZ-11",
                User = user
            });
            cars.Add(new Car
            {
                Brand = "Ford",
                Model = "Focus",
                Year = _random.Next(1990, DateTime.Now.Year),
                LicensePlate = "99-FJ-61",
                User = user
            });

            if (!_context.Cars.Any())
            {
                foreach(Car car in cars)
                {
                    _context.Cars.Add(car);
                }
            }

            if (!_context.UserTypes.Any())
            {
                AddUserType("User", "Base workshop user");
                AddUserType("Mechanic", "User with a schedule");
                AddUserType("Admin", "User with full access to schedules and user types");
            }

            if (!_context.Schedules.Any())
            {
                AddSchedule(new DateTime(2022, 5, 1), cars[0]);
                AddSchedule(new DateTime(2022, 5, 1), cars[1]);
                AddSchedule(new DateTime(2022, 5, 1), cars[2]);
                AddSchedule(new DateTime(2022, 5, 1), cars[3]);
            }

            await _context.SaveChangesAsync();
        }

        void AddUserType(string name, string description)
        {
            _context.UserTypes.Add(new UserType
            {
                Name = name,
                Description = description
            });
        }

        void AddSchedule(DateTime date, Car car)
        {
            _context.Schedules.Add(new Schedule
            {
                Date = date,
                Car = car
            });
        }
    }
}