using NUnit.Framework;
using System;
using System.Collections.Generic;
using Scripting_Game;

namespace Scripting_Game
{
    public class Tests
    {
        Tower testTower = new Tower(1);

        Player testPlayer = new Player(1, 1);
        Enemy testEnemy = new Enemy(1, 1);
        Upgrade testUpgrade = new Upgrade(1, 1);

        [Test]
        public void TestCreateTower()
        {
            Tower resultTower = new Tower(0);
            Assert.AreEqual(resultTower.towerSize, testTower.towerSize);
        }
        
        [Test]
        public void TestCreateCharacter()
        {
            Player resultPlayer = new Player(-10, 1);
            Enemy resultEnemy = new Enemy(0, 1);
            Upgrade resultUpgrade = new Upgrade(0, 1);
            Assert.AreEqual(testPlayer.powerLevel, resultPlayer.powerLevel);
            Assert.AreEqual(testEnemy.powerLevel, resultEnemy.powerLevel);
            Assert.AreEqual(testUpgrade.powerLevel, resultUpgrade.powerLevel);
        }

        [Test]
        public void TestTowerContainsPlayer()
        {
            Tower tower = new Tower(1);
            Player player = new Player(1, 1);

            tower.Insert_In_Tower(player);

            Assert.IsTrue(tower.towerFloors.Contains(player));
        }

        [Test]
        public void TestVSEnemy()
        {
            Tower playerTower = new Tower(2);
            Player player = new Player(10, 1);
            playerTower.Insert_In_Tower(player);

            Tower enemyTower = new Tower(2);
            Enemy enemy = new Enemy(5, 1);
            enemyTower.Insert_In_Tower(enemy);

            float targetPower = player.powerLevel + enemy.powerLevel;

            player.BattleEnemy(enemy, playerTower, enemyTower);

            Assert.AreEqual(targetPower, player.powerLevel);
        }

        [Test]
        public void TestVSUpgrade()
        {
            Tower playerTower = new Tower(2);
            Player player = new Player(10, 1);
            Upgrade upgrade = new Upgrade(20, 2);
            playerTower.Insert_In_Tower(player);
            playerTower.Insert_In_Tower(upgrade);

            float targetPower = player.powerLevel + upgrade.powerLevel;

            player.GetUpgrade(upgrade, playerTower);

            Assert.AreEqual(targetPower, player.powerLevel);
        }

        [Test]
        public void TestTowerLevelChange()
        {
            Tower playerTower = new Tower(2);
            Player player = new Player(10, 1);
            playerTower.Insert_In_Tower(player);
            float playerTowerSizeBefore = playerTower.towerSize;

            Tower enemyTower = new Tower(2);
            Enemy enemy = new Enemy(5, 1);
            enemyTower.Insert_In_Tower(enemy);
            float enemyTowerSizeBefore = enemyTower.towerSize;

            player.BattleEnemy(enemy, playerTower, enemyTower);

            float playerTowerSizeAfter = playerTower.towerSize;
            float enemyTowerSizeAfter = enemyTower.towerSize;

            Assert.AreEqual(playerTowerSizeAfter, playerTowerSizeBefore + 1);
            Assert.AreEqual(enemyTowerSizeAfter, enemyTowerSizeBefore - 1);
        }

        [Test]
        public void TestLastEnemyInTower()
        {
            Tower playerTower = new Tower(2);
            Player player = new Player(10, 1);
            playerTower.Insert_In_Tower(player);

            Tower enemyTower = new Tower(1);
            Enemy enemy = new Enemy(5, 1);
            enemyTower.Insert_In_Tower(enemy);

            player.BattleEnemy(enemy, playerTower, enemyTower);

            Assert.IsTrue(enemyTower.towerSize == 0 );
            Assert.IsTrue(enemyTower.towerFloors.Contains(enemy) == false);
        }

        [Test]
        public void TestEnemyWin()
        {
            Tower playerTower = new Tower(2);
            Player player = new Player(2, 1);
            playerTower.Insert_In_Tower(player);

            Tower enemyTower = new Tower(2);
            Enemy enemy = new Enemy(5, 1);
            enemyTower.Insert_In_Tower(enemy);

            player.BattleEnemy(enemy, playerTower, enemyTower);

            Assert.AreEqual(player.lives, player.lives--);
        }

        [Test]
        public void TestFullCombat()
        {
            Tower playerTower = new Tower(2);
            Player player = new Player(7, 1);
            playerTower.Insert_In_Tower(player);

            Tower enemyTower1 = new Tower(2);
            Enemy enemy1 = new Enemy(5, 1);
            enemyTower1.Insert_In_Tower(enemy1);

            Tower enemyTower2 = new Tower(3);
            Enemy enemy2 = new Enemy(10, 2);
            enemyTower1.Insert_In_Tower(enemy1);

            player.BattleEnemy(enemy1, playerTower, enemyTower1);
            player.BattleEnemy(enemy2, playerTower, enemyTower2);

            player.WinCondition();

            Assert.IsTrue(player.levelComplete);
        }

    }
}