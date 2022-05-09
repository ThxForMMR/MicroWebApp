using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTerritoryAPI.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using WebTerritoryAPI.Models;

namespace WebTerritoryAPI.Repository
{
    public class TerritoryRepository : ITerritoryRepository
    {
        TerritoryContext _dbContext;
        public TerritoryRepository(TerritoryContext context)
        {
            _dbContext = context;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
