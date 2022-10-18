using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            

            var user = await _userHelper.GetUserByEmailAsync("rodrigooliveirapina@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Rodrigo",
                    LastName = "Pina",
                    Email = "rodrigooliveirapina@gmail.com",
                    UserName = "rodrigooliveirapina@gmail.com",
                    PhoneNumber = "915775299",
                };

                var result = await _userHelper.AddUserAsync(user, "WorkShop2022.");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                if (!_context.Mechanics.Any())
                {
                    _context.Mechanics.Add(new Mechanic
                    {
                        EnterHour = 9,
                        EnterMinute = 30,
                        LeaveHour = 19,
                        LeaveMinute = 30,
                        User = user
                    });
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
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

            if (!_context.Schedules.Any())
            {
                AddSchedule("New Car", new DateTime(2022, 5, 1), cars[0]);
                AddSchedule("Old Car", new DateTime(2022, 5, 1), cars[1]);
                AddSchedule("Decent Car", new DateTime(2022, 5, 1), cars[2]);
                AddSchedule("Random Car", new DateTime(2022, 5, 1), cars[3]);
            }

            await _context.SaveChangesAsync();
        }

        void AddSchedule(string description, DateTime date, Car car)
        {
            _context.Schedules.Add(new Schedule
            {
                Descripton = description,
                Date = date,
                Car = car
            });
        }
    }
}