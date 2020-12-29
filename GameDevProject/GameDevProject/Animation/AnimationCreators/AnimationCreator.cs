using GameDevProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation.AnimationCreators
{
    class AnimationCreator
    {
        //wordt aangeroepen om de volledige lijst met alle animaties terug te geven aan enemy's en roept het aanmaken van de animaties aan
        private AnimationEntity hero;
        private AnimationEntity spearman;
        private AnimationFactory factory;
        public AnimationCreator()
        {
            this.factory = new AnimationFactory();
            this.hero = InfoHero();
            this.spearman = InfoSpearman();
        }
        private AnimationEntity InfoHero()
        {
            AnimationEntity temp = new AnimationEntity();
            temp.AttackL = new int[,] { { 660, 531, 100, Hero.height }, { 566, 531, 100, 78 }, { 470, 531, 90, 70 }, { 370, 531, 90, 70 } };
            temp.AttackR = new int[,] {
                { 22, 530, Hero.Width, Hero.height},
                {118, 530, 78, 78},
                {204, 530, 101, 60 },
                {304, 530, 90, 60}
            };
            temp.idleL = new int[,] {
                {396, 10, Hero.Width, Hero.height },
                {496, 10, Hero.Width, Hero.height },
                {596, 10, Hero.Width, Hero.height },
                {696, 10, Hero.Width, Hero.height}
            };
            temp.idleR = new int[,]{
                {24, 10,  Hero.Width, Hero.height},
                {124, 10,  Hero.Width, Hero.height},
                {224, 10,  Hero.Width, Hero.height},
                {324, 10,  Hero.Width, Hero.height}
            };
            temp.runL = new int[,]{
                {592, 88, Hero.Width, Hero.height},
                {490, 88, Hero.Width, Hero.height},
                {392, 88, Hero.Width, Hero.height},
                {288, 88, Hero.Width, Hero.height},
                { 192, 88, Hero.Width, Hero.height},
                { 92, 88, Hero.Width, Hero.height}
            };
            temp.runR = new int[,]{
                {128, 88, Hero.Width, Hero.height},
                {228, 88, Hero.Width, Hero.height},
                {328, 88, Hero.Width, Hero.height},
                {428, 88, Hero.Width, Hero.height},
                {528, 88, Hero.Width, Hero.height},
                {628, 88, Hero.Width, Hero.height}
            };
            temp.jumpingL = new int[,]{
                {492, 158, Hero.Width, Hero.height},
                {496, 226, Hero.Width, Hero.height}
            };
            temp.jumpingR = new int[,]
            {
                {228, 160, Hero.Width, Hero.height},
                {230, 226, Hero.Width, Hero.height}
            };
            temp.deathL = new int[,] {
                {493, 676, 45, Hero.height},
                {386, 676, 45, Hero.height},
                {286, 676, 45, Hero.height }
            };
            temp.deathR = new int[,]{
                {231, 676, 45, Hero.height},
                {334, 676, 45, Hero.height},
                {434, 676, 45, Hero.height }
            };

            return temp;
        }
        private AnimationEntity InfoSpearman()
        {
            AnimationEntity temp = new AnimationEntity();
            temp.idleL = new int[,] {
                {2614, 35, Spearman.Width, Spearman.height},
                {2326, 35, Spearman.Width, Spearman.height}};
            temp.idleR = new int[,]{
                {196, 35, Spearman.Width, Spearman.height},
                {292, 35, Spearman.Width,Spearman.height}
            };


            temp.runL = new int[,]{
                {1753, 35, Spearman.Width, Spearman.height},
                {1656, 35, Spearman.Width, Spearman.height},
                {1560, 35, Spearman.Width, Spearman.height},
                {1462, 35, Spearman.Width, Spearman.height}

            };
            temp.runR = new int[,]{
                {868, 35, Spearman.Width, Spearman.height},
                {964, 35, Spearman.Width, Spearman.height},
                {1059, 35, Spearman.Width, Spearman.height},
                {1155, 35, Spearman.Width, Spearman.height}

            };


            temp.AttackL = new int[,]{
                {2614, 35, Spearman.Width, Spearman.height},
                {1262, 35, 84, 82},
                {1167, 35, 77, 73},
                {1070, 35, 79, 73},
                {981, 35, 71, 73}

            };
            temp.AttackR = new int[,]{
{196, 35, Spearman.Width, Spearman.height},
{1345, 35, 84, 82},
{1444, 35, 77, 73},
{1539, 35, 79, 73},
{1635, 35, 71, 73}

            };


            temp.jumpingL = new int[,]
                {
{407, 35, Spearman.Width, Spearman.height},
{313, 35, Spearman.Width, Spearman.height}

            };
            temp.jumpingR = new int[,]{
{2212, 35, Spearman.Width, Spearman.height},
{2307, 35, Spearman.Width, Spearman.height}

            };



            temp.deathL = new int[,]
                {
{25, 30, 71, 72},
{121, 30, 67, 70},
{217, 30, 66, 67},
{0,0,0,0}

            };
            temp.deathR = new int[,]{
{2591, 30, 71, 72},
{2499, 30 ,67, 70},
{2404, 30, 66, 67},
{0,0,0,0}

            };





            return temp;
        }

        public List<List<Animatie>> GetHeroAnimation()
        {
            return factory.CreateTotalAnimation(hero);
        }
        public List<List<Animatie>> GetSpearmanAnimation()
        {
            return factory.CreateTotalAnimation(spearman);
        }
    }
}
