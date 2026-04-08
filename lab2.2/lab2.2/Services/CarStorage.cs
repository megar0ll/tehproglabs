using lab2_2.Models;

namespace lab2_2.Services
{
    public static class CarStorage
    {
        private static Car[] cars = new Car[100];
        private static int count = 0;

        static CarStorage()
        {
            cars[0] = new Car { Id = 1, Brand = "Toyota", Model = "Camry", Year = 2023, Price = 3500000, Mileage = 0, FuelType = "Бензин", Description = "Новый автомобиль", CreatedDate = DateTime.Now.AddDays(-5) };
            cars[1] = new Car { Id = 2, Brand = "BMW", Model = "X5", Year = 2022, Price = 7800000, Mileage = 15000, FuelType = "Дизель", Description = "Премиальный внедорожник", CreatedDate = DateTime.Now.AddDays(-10) };
            cars[2] = new Car { Id = 3, Brand = "Tesla", Model = "Model 3", Year = 2024, Price = 5200000, Mileage = 5000, FuelType = "Электричество", Description = "Электромобиль", CreatedDate = DateTime.Now.AddDays(-2) };
            cars[3] = new Car { Id = 4, Brand = "Audi", Model = "A6", Year = 2023, Price = 5800000, Mileage = 8000, FuelType = "Бензин", Description = "Бизнес-седан", CreatedDate = DateTime.Now.AddDays(-7) };
            cars[4] = new Car { Id = 5, Brand = "Kia", Model = "Sportage", Year = 2024, Price = 3200000, Mileage = 1000, FuelType = "Бензин", Description = "Кроссовер", CreatedDate = DateTime.Now.AddDays(-1) };
            count = 5;
        }

        public static Car[] GetAllCars()
        {
            Car[] result = new Car[count];
            for (int i = 0; i < count; i++)
                result[i] = cars[i];
            return result;
        }

        public static int GetCount() => count;
        public static int GetMaxId() => count > 0 ? cars.Take(count).Max(c => c.Id) : 0;

        public static Car? GetCarById(int id)
        {
            for (int i = 0; i < count; i++)
                if (cars[i].Id == id) return cars[i];
            return null;
        }

        public static void AddCar(Car car)
        {
            if (count < 100)
            {
                cars[count] = car;
                count++;
            }
        }

        public static void UpdateCar(Car car)
        {
            for (int i = 0; i < count; i++)
                if (cars[i].Id == car.Id)
                    cars[i] = car;
        }

        public static void DeleteCar(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (cars[i].Id == id)
                {
                    for (int j = i; j < count - 1; j++)
                        cars[j] = cars[j + 1];
                    cars[count - 1] = null!;
                    count--;
                    break;
                }
            }
        }
    }
}