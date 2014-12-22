using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces
{
    interface IDamageable
    {
        float Health { get; set; }
        
        float MaxHealth { get; set; }

        void takeDamage(float amount);

        void die();
    }
}
