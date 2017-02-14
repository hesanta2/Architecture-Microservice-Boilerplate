using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace µService.Infrastructure.Persistence
{
    public static class UnityOfWork
    {
        [ThreadStatic]
        private static DataBaseEntities _context = null;
        public static DataBaseEntities Context { get { return _context; } set { _context = value; } }


        public static void Initialize()
        {
            _context = new DataBaseEntities();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public static void Dispose()
        {
            _context.SaveChanges();
            _context.Dispose();
        }

    }
}
