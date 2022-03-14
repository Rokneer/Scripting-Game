using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripting_Game
{
    public class Enemy: Character
    {
        public Enemy(float enemyPower, int enemyTowerIndex)
        {
            powerLevel = enemyPower;
            if(powerLevel <= 0) powerLevel = 1;
            towerIndex = enemyTowerIndex;
            if (towerIndex <= 0) towerIndex = 1;
        }
    }
}
