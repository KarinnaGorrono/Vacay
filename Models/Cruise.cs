
using Vacay.Interfaces;

namespace Vacay.Models
{
    public class Cruise : IVacation
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Destination { get; set; }
        public string SailDate { get; set; }

    }
}