using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripting_Game
{
    public class Upgrade: Character
    {
        public Upgrade(float upgradePower, int upgradeTowerIndex)
        {
            powerLevel = upgradePower;
            if(powerLevel <= 0) powerLevel = 1;
            towerIndex = upgradeTowerIndex;
            if (towerIndex <= 0) towerIndex = 1;
        }
    }
}
