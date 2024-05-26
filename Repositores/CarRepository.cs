using CarRental.Contexts;
using CarRental.Dtos.Car;
using CarRental.Entities;

namespace CarRental.Repositores
{
    public class CarRepository
    {
        AppDbContext context;

        public CarRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<Car> GetCars()
        {
            return context.Cars.ToList();
        }

        public Car GetCar(int id)
        {
            return context.Cars.Where(x => x.ID == id).FirstOrDefault();
        }

        public bool AddCar(CreateCarDto Car)
        {
            if (Car.License != null)
            {
                Model model = context.Models.Where(x => x.ID == Car.ModelId).FirstOrDefault();
                if (model != null)
                {
                    Car CarDb = new Car();
                    CarDb.License = Car.License;
                    CarDb.Km = Car.Km;
                    CarDb.ModelId = Car.ModelId;
                    CarDb.Model = model;
                    context.Cars.Add(CarDb);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DeleteCar(int id)
        {
            Car Car = GetCar(id);
            if (Car != null)
            {
                context.Cars.Remove(Car);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCar(int id, Car Car)
        {
            Car dbCar = GetCar(id);
            if (dbCar != null)
            {
                dbCar.License = Car.License;
                dbCar.IsActive = Car.IsActive;
                dbCar.Km = Car.Km;
                context.Cars.Update(dbCar);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
