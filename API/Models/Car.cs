using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Car 
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string CarNumber { get; set; }
        public int RentalPrice { get; set; }
    }
}