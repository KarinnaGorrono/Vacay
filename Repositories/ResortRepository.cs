using System;
using System.Collections.Generic;
using Vacay.Models;

namespace Vacay.Repositories
{
    public class ResortsRepository
    {
        private readonly IDbConnection _db;

        public ResortsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<ResortsRepository> GetAll()
        {
            string sql = "SELECT * FROM cruises;";
            return _db.Query<Resort>(sql).ToList();
        }

        internal Resort Create(Resort newResort)
        {
            string sql = @"
    INSERT INTO resorts
    (price, destination, arrivalDate)
    VALUES
    (@price, @destination, @arrivalDate);
    SELECT LAST_INSERT_ID()
    ";

            int id = _db.ExecuteScalar<int>(sql, newResort);
            newResort.Id = id;
            return newResort;
        }

    }
}