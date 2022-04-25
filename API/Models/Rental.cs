using System;

namespace API.Models
{
    public class Rental
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public int NumberOfDayRental { get; set; }
    }
}