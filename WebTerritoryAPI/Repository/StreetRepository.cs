using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTerritoryAPI.Models;
using WebTerritoryAPI.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace WebTerritoryAPI.Repository
{
    public class StreetRepository : IStreetRepository
    {
        public readonly TerritoryContext _dbContext;
        public StreetRepository(TerritoryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteStreet(long Id)
        {
            var street = _dbContext.Streets.Find(Id);
            _dbContext.Streets.Remove(street);
            Save();
        }

        public Street GetStreetById(long streetId)
        {
            return _dbContext.Streets.Find(streetId);
        }
        public IEnumerable<Street> GetStreetByField(string field, long streetId)
        {
            string path = "[streets]";
            return _dbContext.Streets.FromSqlRaw("SELECT * FROM " + path + " WHERE " + field + "=" + streetId.ToString()).ToList();
        }

        public IEnumerable<Street> GetStreet()
        {
            return _dbContext.Streets.ToList();
        }

        public void InsertStreet(Street street)
        {
            _dbContext.Streets.Add(street);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateStreet(Street street)
        {
            _dbContext.Streets.Update(street);
            Save();
        }
    }
}
