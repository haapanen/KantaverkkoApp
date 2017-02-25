using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantaverkkoApp.Repositories
{
    // .NET core library cannot reference a console app (database initializer)
    // and dbcontext actions require a console app => we have to make this 
    // a console app for now...
    public static class Program
    {
        public static void Main() { }
    }
}
