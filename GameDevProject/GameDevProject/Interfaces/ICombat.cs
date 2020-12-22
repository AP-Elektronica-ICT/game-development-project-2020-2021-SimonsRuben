using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Interfaces
{
    interface ICombat
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public void TakeDamage(int dmg);

    }
}
