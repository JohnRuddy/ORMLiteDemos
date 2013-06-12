using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace ORMLiteDemoWebsite.Data
{
    public class Person
    {
        [AutoIncrement]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Age { get; set; }


    }
}