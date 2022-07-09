using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelTaX.Entities
{
    public static class DBSetUp
    {
        public static String DelTaXDB { get; set; } = null;
        public static void DBStringSet(string DBString)
        {
            DelTaXDB = DBString;
        }
    }
}
