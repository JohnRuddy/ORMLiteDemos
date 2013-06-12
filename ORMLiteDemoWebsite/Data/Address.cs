using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace ORMLiteDemoWebsite.Data
{
    public class Address
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string County { get; set; }
    }
}