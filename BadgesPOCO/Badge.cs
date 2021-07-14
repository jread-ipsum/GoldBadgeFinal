using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesPOCO
{
    public class Badge
    {
        public int ID { get; set; }
        public List<string> Doors { get; set; } = new List<string>();

        public Badge()
        {

        }

    }
}
