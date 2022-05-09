using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTerritoryAPI.Models;

namespace WebTerritoryAPI.Repository
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
