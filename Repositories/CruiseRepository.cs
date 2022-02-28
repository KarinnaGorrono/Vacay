using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Vacay.Models;

namespace Vacay.Repositories
{
    public class CruisesRepository
    {
        private readonly IDbConnection _db;

        public CruisesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Cruise> GetAll()
        {
            string sql = "SELECT * FROM cruises;";
            return _db.Query<Cruise>(sql).ToList();
        }

        internal Cruise Create(Cruise newCruise)
        {
            string sql = @"
      INSERT INTO cruises
      (price, destination, sailDate)
      VALUES
      (@price, @destination, @sailDate);
      SELECT LAST_INSERT_ID()
      ";
            int id = _db.ExecuteScalar<int>(sql, newCruise);
            newCruise.Id = id;
            return newCruise;
        }
    }
}