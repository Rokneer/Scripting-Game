using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripting_Game
{
    public class Player : Character
    {
        public float lives = 3f;
        public bool levelComplete = false;

        public Player(float playerPower, int playerTowerIndex)
        {
            powerLevel = playerPower;
            if(powerLevel <= 0) powerLevel = 1;

            towerIndex = playerTowerIndex;
            if (towerIndex <= 0) towerIndex = 1;
        }

        public void BattleEnemy(Enemy enemy, Tower playerTower, Tower enemyTower)
        {

            if (powerLevel > enemy.powerLevel)
            {
                powerLevel += enemy.powerLevel; //AÑADE PODER AL JUGADOR
                playerTower.towerSize++;
                playerTower.towerFloors.Add(null);

                enemyTower.towerSize--;
                enemyTower.towerFloors.RemoveAt(enemy.towerIndex);
                enemyTower.towerFloors.Remove(enemy);
                if (enemyTower.towerFloors.Count == 0)
                {
                    enemyTower.towerFloors.Clear();
                    enemyTower.towerSize = 0;
                    Console.WriteLine("Enemy Tower is Down!");
                }
                Console.WriteLine("Player Won!");
            }
            else if(powerLevel <= enemy.powerLevel)
            {
                enemy.powerLevel += powerLevel; //AÑADE PODER AL ENEMIGO
                lives--;

                Console.WriteLine("Enemy Won!");
            }
            else Console.WriteLine("ERROR");
        }

        public void WinCondition()
        {
            levelComplete = true;
            Console.WriteLine("Level Complete");
        }

        public void GetUpgrade(Upgrade upgrade, Tower playerTower)
        {
            powerLevel += upgrade.powerLevel;
            playerTower.towerFloors.Remove(upgrade);
            Console.WriteLine("Upgraded!");
        }
    }
}
