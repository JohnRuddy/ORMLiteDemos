using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORMLiteDemoWebsite.Data;
using ServiceStack.OrmLite;
using ServiceStack.Text;

namespace ORMLiteDemoWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["OrmLiteConnectionString"].ToString(), true,
                                            SqlServerDialect.Provider);

        protected void Page_Load(object sender, EventArgs e)
        {

            dbFactory.Run(db => db.DropTable<PersonAddress>());
            dbFactory.Run(db => db.DropTable<Address>());
            dbFactory.Run(db => db.DropTable<Person>());

            dbFactory.Run(db => db.CreateTable<Person>());
            dbFactory.Run(db => db.CreateTable<Address>());
            dbFactory.Run(db => db.CreateTable<PersonAddress>());

            using (IDbConnection db = dbFactory.OpenDbConnection())
            {
                db.Insert(new Address { County = "Mayo" });
                db.Insert(new Address { County = "Dublin" });
            }

            using (IDbConnection db = dbFactory.OpenDbConnection())
            {
                db.Insert(new Person { Age = 21, Name = "John"});
                db.Insert(new Person { Age = 31, Name = "Mark" });
                db.Insert(new Person { Age = 52, Name = "David"});
                db.Insert(new Person { Age = 43, Name = "Mary"});
            }

            using (IDbConnection db = dbFactory.OpenDbConnection())
            {
                db.Insert(new PersonAddress { AddressId = 1, PersonId = 1 });
                db.Insert(new PersonAddress { AddressId = 1, PersonId = 2 });
                db.Insert(new PersonAddress { AddressId = 2, PersonId = 3 });
                db.Insert(new PersonAddress { AddressId = 2, PersonId = 4 });
                db.Insert(new PersonAddress { AddressId = 2, PersonId = 1 });

            }

            // select some data from the database
            using (IDbConnection db = dbFactory.OpenDbConnection())
            {
                var NamesWithA = db.Select<Person>(p => p);
                Response.Write(NamesWithA.SerializeToString());
            }
        }

        protected object GetLatestAddressText(object personid)
        {
            string address = string.Empty;
            using (IDbConnection db = dbFactory.OpenDbConnection())
            {


                var addressid = db.Select<PersonAddress>(pa => pa.PersonId == int.Parse(personid.ToString())).OrderByDescending(a => a.Id).FirstOrDefault().AddressId;
                var addressDetail = db.Select<Address>(a => a.Id == addressid).FirstOrDefault().County;
                //IEnumerable<PersonAddress> pa = (from p in PersonAddresses
                //                                 where p.PersonId == 1
                //                                 select p);
                address = addressDetail;
            }
            return address;
        }
    }
}