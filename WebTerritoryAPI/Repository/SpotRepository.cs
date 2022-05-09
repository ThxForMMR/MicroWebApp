using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTerritoryAPI.Models;
using WebTerritoryAPI.Repository.Interfaces;
using WebTerritoryAPI.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace WebTerritoryAPI.Repository
{
    public class SpotRepository : ISpotRepository
    {
        public readonly TerritoryContext _dbContext;
        public SpotRepository(TerritoryContext dbContext)
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
            _dbContext.Spots.Add(spot);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateSpot(Spot spot)
        {
            _dbContext.Spots.Update(spot);
            Save();
        }
    }
}
