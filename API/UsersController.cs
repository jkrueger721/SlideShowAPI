using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SlideShowAPI.Modals;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SlideShowAPI.API
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private UserContext context;
        public UsersController(UserContext context)
        {
            this.context = context;
        }
        // GET: api/values
        [HttpGet]
        public String Get()
        {
            return "Im here from User controller";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
         public string Post([FromBody]User user)
        {
            User foundUser = context.Users.SingleOrDefault<User>(u => u.Username == user.Username);
            if (foundUser != null)
            {
                return "Username not Availabel";
            }

            user.Salt = Auth.GenerateSalt();
            user.Password = Auth.Hash(user.Password, user.Salt);
            context.Users.Add(user);
            context.SaveChanges();
            return Auth.GenerateJWT(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Login([FromBody] User user)
        {
            User foundUser = context.Users.SingleOrDefault<User>(
                u => u.Username == user.Username && u.Password == Auth.Hash(user.Password, u.Salt)
                );
            if (foundUser != null)
            {

                string id = foundUser.Id.ToString();
                //return Ok(user);
                return Auth.GenerateJWT(foundUser);
            }
            return "Username and Password don't match";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
