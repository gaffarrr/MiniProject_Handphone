using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Handphone.Model.Entities
{
    public class HandphoneData
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Os { get; set; }
        public string Procie { get; set; }
        public int Price { get; set; }
        public List<string> Network { get; set; }
    }
}
