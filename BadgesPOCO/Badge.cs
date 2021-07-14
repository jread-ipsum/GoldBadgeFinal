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
        public List<string> Doors { get; set; }

        public Badge()
        {

        }

        public Badge(int iD, List<string> doors)
        {
            this.ID = iD;
            this.Doors = doors;
        }

    }
}
