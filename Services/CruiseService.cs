using System;
using Vacay.Models;
using Vacay.Repositories;

namespace Vacay.Services
{
    public class CruisesService
    {
        private readonly CruisesRepository _repo;

        public CruisesService(CruisesRepository repo)
        {
            _repo = repo;
        }

        internal object Get()
        {
            return _repo.GetAll();
        }

        internal Cruise Create(Cruise newCruise)
        {
            return _repo.Create(newCruise);
        }
    }
}