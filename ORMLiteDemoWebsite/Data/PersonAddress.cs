using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace ORMLiteDemoWebsite.Data
{
    public class PersonAddress
    {
        [AutoIncrement]
        public int Id { get; set; }
        
        [References(typeof(Person))]
        public int PersonId { get; set; }

        [References(typeof(Address))]
        public int AddressId { get; set; }

    }
}