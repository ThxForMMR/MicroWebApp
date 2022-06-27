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
    public class SpotRepository : ISpotRepository
    {
        public readonly UserContext _dbContext;
        public SpotRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteSpot(long Id)
        {
            var spot = _dbContext.Spots.Find(Id);
            _dbContext.Spots.Remove(spot);
            Save();
        }

        public Spot GetSpotById(long spotId)
        {
            return _dbContext.Spots.Find(spotId);
        }
        public IEnumerable<Spot> GetSpotByField(string field, long spotId)
        {
            string path = "[spots]";
            return _dbContext.Spots.FromSqlRaw("SELECT * FROM " + path + " WHERE " + field + "=" + spotId.ToString()).ToList();
        }

        public IEnumerable<Spot> GetSpot()
        {
            return _dbContext.Spots.ToList();
        }

        public void InsertSpot(Spot spot)
        {
            spot.CreatedAt = DateTime.UtcNow;
            _dbContext.Spots.Add(spot);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateSpot(Spot spot)
        {
            spot.UpdateAt = DateTime.UtcNow;
            _dbContext.Spots.Update(spot);
            Save();
        }
    }
}
