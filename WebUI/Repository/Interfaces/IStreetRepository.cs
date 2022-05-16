using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Repository.Interfaces
{
    public interface IStreetRepository : ITerritoryRepository
    {
        IEnumerable<Street> GetStreet();
        IEnumerable<Street> GetStreetByField(string field, long id);
        Street GetStreetById(long streetId);
        void InsertStreet(Street street);
        void DeleteStreet(long streetId);
        void UpdateStreet(Street street);
    }
}
