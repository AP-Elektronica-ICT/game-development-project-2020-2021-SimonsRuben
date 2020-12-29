using GameDevProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GameDevProject.Detections
{
    class HitDetections
    {
        private Hero hero;
        private List<Enemy> enemies;


        public HitDetections(Hero player,List<Enemy> aliveenemies)
        {
            this.hero = player;
            this.enemies = aliveenemies;
        }
        
        public void update(List<Enemy> aliveenemies)
        {
            this.enemies = aliveenemies;
            CheckHeroToEnemy();
            CheckEnemyToHero();
        }
        private void CheckHeroToEnemy()
        {
            if (hero.status == CharState.attack && !hero.Attacklock)
            {
                hero.Attacklock = true;
                foreach (Enemy entity in enemies)
                {
                    if (CollisionDetection.CheckCollision(hero.Attackbox,entity.CollisionRectangle))
                    {
                        entity.TakeDamage(hero.Damage);
                        //Debug.WriteLine("player hits enemy");
                    }
                }
            }


        }

        private void CheckEnemyToHero()
        {
            foreach (Enemy entity in enemies)
            {
                if (entity.status == CharState.attack && !entity.Attacklock)
                {
                    entity.Attacklock = true;
                    if (CollisionDetection.CheckCollision(hero.CollisionRectangle, entity.Attackbox))
                    {
                        hero.TakeDamage(entity.Damage);
                    }
                }
            }

        }

    }
}
