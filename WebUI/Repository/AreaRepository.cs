using System;
using System.Collections.Generic;
using System.Linq;
using WebUI.DBContexts;
using WebUI.Models;
using WebUI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebUI.Repository
{
    public class AreaRepository : IAreaRepository
    {
        public readonly UserContext _dbContext;
        public AreaRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteArea(long Id)
        {
            var area = _dbContext.Areas.Find(Id);
            _dbContext.Areas.Remove(area);
            Save();
        }

        public Area GetAreaById(long areaId)
        {
            return _dbContext.Areas.Find(areaId);
        }

        public IEnumerable<Area> GetArea()
        {
            var result = _dbContext.Areas.ToList();
            if (result == null)
                return new List<Area>();
            return _dbContext.Areas.ToList();
        }

        public void InsertArea(Area area)
        {
            _dbContext.Areas.Add(area);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateArea(Area area)
        {
            _dbContext.Areas.Update(area);
            Save();
        }
    }
}
