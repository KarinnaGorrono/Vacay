using Vacay.Models;
using Vacay.Repositories;

namespace Vacay.Services
{

    public class ResortsService
    {
        private readonly ResortsRepository _repo;

        public ResortsService(ResortsRepository repo)
        {
            _repo = repo;
        }

        internal object Get()
        {
            return _repo.GetAll();
        }

        internal Resort Create(Resort newResort)
        {
            return _repo.Create(newResort);
        }
    }
}