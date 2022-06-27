using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.DBContexts;
using WebUI.Models;
using WebUI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Repository
{
    public class StreetRepository : IStreetRepository
    {
        public readonly UserContext _dbContext;
        public StreetRepository(UserContext dbContext)
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
            street.CreatedAt = DateTime.UtcNow;
            _dbContext.Streets.Add(street);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateStreet(Street street)
        {
            street.UpdateAt = DateTime.UtcNow;
            _dbContext.Streets.Update(street);
            Save();
        }
    }
}
