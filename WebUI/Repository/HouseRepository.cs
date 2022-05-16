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
    public class HouseRepository : IHouseRepository
    {
        public readonly UserContext _dbContext;
        public HouseRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteHouse(long Id)
        {
            var house = _dbContext.Houses.Find(Id);
            _dbContext.Houses.Remove(house);
            Save();
        }

        public House GetHouseById(long houseId)
        {
            return _dbContext.Houses.Find(houseId);
        }
        public IEnumerable<House> GetHouseByField(string field, long houseId)
        {
            string path = "[houses]";
            return _dbContext.Houses.FromSqlRaw("SELECT * FROM " + path + " WHERE " + field + "=" + houseId.ToString()).ToList();
        }

        public IEnumerable<House> GetHouse()
        {
            return _dbContext.Houses.ToList();
        }

        public void InsertHouse(House house)
        {
            _dbContext.Houses.Add(house);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateHouse(House house)
        {
            _dbContext.Houses.Update(house);
            Save();
        }
    }
}
