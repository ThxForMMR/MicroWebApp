using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Repository.Interfaces
{
    public interface IAreaRepository : ITerritoryRepository
    {
        IEnumerable<Area> GetArea();
        Area GetAreaById(long areaId);
        void InsertArea(Area area);
        void DeleteArea(long areaId);
        void UpdateArea(Area area);
    }
}
