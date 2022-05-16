using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Repository.Interfaces
{
    public interface IDistrictRepository : ITerritoryRepository
    {
        IEnumerable<District> GetDistrict();
        IEnumerable<District> GetDistrictByField(string field, long districtId);
        District GetDistrictById(long districtId);
        void InsertDistrict(District district);
        void DeleteDistrict(long districtId);
        void UpdateDistrict(District district);
    }
}
