using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Proje.models
{
    internal class koordinatlarItem
    {
        public Guid id { get; set; }
        public string koordinatlar { get; set; }
        public string lat { get; set; }

        public string Long { get; set; }
        public string datetime { get; set; }
    }

}
