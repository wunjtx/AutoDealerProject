
using AutoDealer.Core.Domain;
using AutoDealer.Core.Paging;
using System.Data.Entity;

namespace AutoDealer.Service
{
    public interface IAutoService
    {
        Auto GetCar(int carID);

        void UpdateCar(Auto car);

        void CreateCar(Auto car);

        void DeleteCar(Auto car);

        IPagedList<Auto> GetCars(int pageNumber, int pageSize);

        IDbSet<Auto> GetSet();
    }
}