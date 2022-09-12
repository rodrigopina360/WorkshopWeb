using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Web.Helpers;

namespace Workshop.Web.Data.Entities
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

            if (!_context.Cars.Any())
            {
                cars.Add(AddCar("BMW", "i8", "12-AB-34", user));
                cars.Add(AddCar("Honda", "Civic", "21-BA-43", user));
                cars.Add(AddCar("Opel", "Corsa", "42-XZ-11", user));
                cars.Add(AddCar("Ford", "Focus", "99-FJ-61", user));
                await _context.SaveChangesAsync();
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
        }

        Car AddCar(string brand, string model, string licensePlate, User user)
        {
            Car car = new Car
            {
                Brand = brand,
                Model = model,
                Year = _random.Next(1990, DateTime.Now.Year),
                LicensePlate = licensePlate,
                User = user
            };
            _context.Cars.Add(car);

            return car;
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