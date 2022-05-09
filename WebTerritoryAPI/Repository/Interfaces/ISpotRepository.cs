using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTerritoryAPI.Models;

namespace WebTerritoryAPI.Repository.Interfaces
{
    public interface ISpotRepository : ITerritoryRepository
    {
        IEnumerable<Spot> GetSpot();
        IEnumerable<Spot> GetSpotByField(string field, long id);
        Spot GetSpotById(long id);
        void InsertSpot(Spot spot);
        void DeleteSpot(long id);
        void UpdateSpot(Spot spot);
    }
}
