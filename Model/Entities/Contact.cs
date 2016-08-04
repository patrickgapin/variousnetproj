using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Entities
{
    public class Contact: Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
