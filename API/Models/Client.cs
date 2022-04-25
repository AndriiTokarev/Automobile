using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Passport { get; set; }
    }
}