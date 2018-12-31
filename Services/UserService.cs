using SlideShowAPI.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlideShowAPI.Services
{
    public class UserService
    {
        private UserContext _db;

        public UserService(UserContext db)
        {
            _db = db;
        }

       
    }
}
