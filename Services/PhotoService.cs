using SlideShowAPI.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlideShowAPI.Services
{
    public class PhotoService
    {
        private UserContext _db;

        public PhotoService(UserContext db)
        {
            _db = db;
        }
    }
}
