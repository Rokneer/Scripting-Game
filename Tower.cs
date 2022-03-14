using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripting_Game
{
    public class Tower
    {
        public float towerSize;
        public List<Character> towerFloors = new List<Character>();
        public Tower(float towerSize_)
        {
            towerSize = towerSize_;
            if (towerSize <= 0f) towerSize = 1f;
            for (int i = 0; i < towerSize; i++) towerFloors.Add(null);
        }

        public void Insert_In_Tower(Character character)
        {
            towerFloors.Insert(character.towerIndex, character);
        }
    }
}
