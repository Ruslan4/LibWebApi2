using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BestLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        List<User> db = new List<User> { new User() { Id = 1, Name = "erbe", Age = 10 }, new User() { Id = 1, Name = "erbe", Age = 10 } };


        public IHttpActionResult Get()
        {
            return Ok(db.ToList());
        }

        public IHttpActionResult Get(int id)
        {
            User user = db.FirstOrDefault(x => x.Id == id);
            if (user != null)
                return Ok(user);

            return NotFound();
        }

        public IHttpActionResult Post([FromBody]User user)
        {
            db.Add(user);
            return Ok(user);
        }

        public IHttpActionResult Put(int id, [FromBody]User user)
        {
            return NotFound();
        }

        public IHttpActionResult Delete(int id)
        {
            User user = db[id];
            if (user != null)
            {
                db.Remove(user);
                return Ok(user);
            }

            return NotFound();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
