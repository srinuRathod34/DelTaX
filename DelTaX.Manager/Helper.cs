using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelTaX.Manager
{
    public static class Helper
    {
        public static void DBSetUpManager(string DelTexDBString)
        {
            DelTaX.Entities.DBSetUp.DBStringSet(DelTexDBString);
        }
    }
}
