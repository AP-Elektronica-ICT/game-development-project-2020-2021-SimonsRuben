using GameDevProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Detections
{
    class HitDetections
    {
        private Hero hero;
        private List<Spearman> enemies;
        public HitDetections(Hero player,List<Spearman> aliveenemies)
        {
            this.hero = player;
            this.enemies = aliveenemies;
        }
        
        public void update()
        {
            CheckHeroToEnemy();
            CheckEnemyToHero();
        }
        private void CheckHeroToEnemy()
        {
            
        }

        private void CheckEnemyToHero()
        {

        }

        private void DoDamage()
        {

        }
    }
}
