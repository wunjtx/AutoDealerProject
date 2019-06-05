
using AutoDealer.Core.Data;
using AutoDealer.Core.Domain;
using AutoDealer.Core.Paging;
using System.Data.Entity;

namespace AutoDealer.Service
{
    public class AutoService : IAutoService
    {
        private readonly IRepository<Auto> carRepository;

        public AutoService(IRepository<Auto> carRepository)
        {
            this.carRepository = carRepository;
        }

        public void CreateCar(Auto car)
        {
            carRepository.Insert(car);
        }

        public void DeleteCar(Auto car)
        {
            carRepository.Delete(car);
        }

        public void DeleteCar(int Id)
        {
            carRepository.Delete(GetCar(Id));
        }

        public IDbSet<Auto> GetSet()
        {
            return  carRepository.GetSet();
        }

        public Auto GetCar(int carID)
        {
            return carRepository.GetById(carID);
        }

        public IPagedList<Auto> GetCars(int pageNumber, int pageSize)
        {
            return carRepository.Table.ToPagedList(m => m.ID, pageNumber, pageSize);
        }

        public IPagedList<Auto> GetCars(string keyword, int pageNumber, int pageSize)
        {
            return carRepository.Table.ToPagedList(m => m.ID, pageNumber, pageSize);
        }

        public void UpdateCar(Auto car)
        {
            carRepository.Update(car);
        }
    }
}