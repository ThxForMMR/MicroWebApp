using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Repository.Interfaces
{
    public interface ICityRepository : ITerritoryRepository
    {
        IEnumerable<City> GetCity();
        IEnumerable<City> GetCityByField(string field, long cityId);
        City GetCityById(long cityId);
        void InsertCity(City city);
        void DeleteCity(long cityId);
        void UpdateCity(City city);
        void BindCities(long id, long[] ids);
        void UnbindCities(long[] ids);
    }
}
