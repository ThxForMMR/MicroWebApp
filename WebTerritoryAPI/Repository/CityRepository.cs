using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTerritoryAPI.Models;
using WebTerritoryAPI.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace WebTerritoryAPI.Repository
{
    public class CityRepository : ICityRepository
    {
        public readonly TerritoryContext _dbContext;
        public CityRepository(TerritoryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteCity(long Id)
        {
            var city = _dbContext.Cities.Find(Id);
            _dbContext.Cities.Remove(city);
            Save();
        }

        public City GetCityById(long cityId)
        {
            return _dbContext.Cities.Find(cityId);
        }

        public IEnumerable<City> GetCityByField(string field, long cityId)
        {
            string path = "[cities]";
            return _dbContext.Cities.FromSqlRaw("SELECT * FROM " + path + " WHERE " + field + "=" + cityId.ToString()).ToList();
        }

        public IEnumerable<City> GetCity()
        {
            return _dbContext.Cities.ToList();
        }

        public void InsertCity(City city)
        {
            _dbContext.Cities.Add(city);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCity(City city)
        {
            _dbContext.Cities.Update(city);
            Save();
        }

        public void BindCities(long spotId, long[] ids)
        {
            foreach (long id in ids)
            {
                var city = GetCityById(id);
                city.SpotId = spotId;
                UpdateCity(city);
            }
        }

        public void UnbindCities(long[] ids)
        {
            foreach (long id in ids)
            {
                var city = GetCityById(id);
                city.SpotId = null;
                UpdateCity(city);
            }
        }
    }
}
