using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTerritoryAPI.Models;

namespace WebTerritoryAPI.Repository
{
    public interface IHouseRepository : ITerritoryRepository
    {
        IEnumerable<House> GetHouse();
        IEnumerable<House> GetHouseByField(string field, long id);
        House GetHouseById(long houseId);
        void InsertHouse(House house);
        void DeleteHouse(long houseId);
        void UpdateHouse(House house);
    }
}
