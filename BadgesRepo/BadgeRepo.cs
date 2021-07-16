using BadgesPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepo
{
    public class BadgeRepo
    {
        Dictionary<int, List<string>> _badgesDict = new Dictionary<int, List<string>>();

        //create
        public bool AddBadgeToDict(Badge badge)
        {
            if(!_badgesDict.ContainsKey(badge.ID))
            {
                _badgesDict.Add(badge.ID, badge.Doors);
                return true;
            }
            else
            {
                Console.WriteLine("ID already exists.");
                return false;
            }
        }
        //read
        public Dictionary<int, List<string>> ShowAllBadges()
        {
            return _badgesDict;
        }
        
        //helper
        public Badge GetBadgeById(int id)
        {
            foreach (KeyValuePair<int, List<string>> kvp in _badgesDict)
            {
                if (kvp.Key == id)
                {
                    return new Badge(kvp.Key, kvp.Value);
                }
            }
            return null;
        }
    }
}
