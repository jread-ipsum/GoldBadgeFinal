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
        public void AddBadgeToDict(Badge badge)
        {
            if(!_badgesDict.ContainsKey(badge.ID))
            {
                _badgesDict.Add(badge.ID, badge.Doors);
            }
        }
        //read
        public Dictionary<int, List<string>> ShowAllBadges()
        {
            return _badgesDict;
        }
        //update


        //delete

        //helper
        public Badge GetBadgeById(int iD)
        {
            foreach(KeyValuePair<int, List<string>> kvp in _badgesDict)
            {
                if(kvp.Key == iD)
                {
                    return kvp.value;
                }
            }
            return null;
        }
    }
}
