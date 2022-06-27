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
    public class DistrictRepository : IDistrictRepository
    {
        public readonly UserContext _dbContext;
        public DistrictRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteDistrict(long Id)
        {
            var district = _dbContext.Districts.Find(Id);
            _dbContext.Districts.Remove(district);
            Save();
        }

        public District GetDistrictById(long districtId)
        {
            return _dbContext.Districts.Find(districtId);
        }

        public IEnumerable<District> GetDistrictByField(string field, long districtId)
        {
            string path = "[districts]";
            return _dbContext.Districts.FromSqlRaw("SELECT * FROM " + path + " WHERE " + field + "=" + districtId.ToString()).ToList();
        }

        public IEnumerable<District> GetDistrict()
        {
            return _dbContext.Districts.ToList();
        }

        public void InsertDistrict(District district)
        {
            district.CreatedAt = DateTime.UtcNow;
            _dbContext.Districts.Add(district);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateDistrict(District district)
        {
            district.UpdateAt = DateTime.UtcNow;
            _dbContext.Districts.Update(district);
            Save();
        }
    }
}
