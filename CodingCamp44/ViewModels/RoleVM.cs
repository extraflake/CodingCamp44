using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.ViewModels
{
    public class RoleVM
    {
        /* public int Id { get; set; }
         public string Name { get; set; }*/
         public List<content> data { get; set; }
         public string status { get; set; }


        public class content
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public List<RoleVM> RoleVMs{ get; set; }
    }
}
