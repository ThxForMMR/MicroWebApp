using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Repository.Interfaces
{
    public interface IHouseRepository : ITerritoryRepository
    {
        IEnumerable<House> GetHouse();
        IEnumerable<House> GetHouseByField(string field, long id);
        House GetHouseById(long houseId);
        void InsertHouse(House house);
        void DeleteHouse(long houseId);
        void UpdateHouse(House house);
        void BindHouse(long id, long[] ids);
        void UnbindHouse(long[] ids);
    }
}
