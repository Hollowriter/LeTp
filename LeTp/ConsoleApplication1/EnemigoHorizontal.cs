using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charcito
{
    class EnemigoHorizontal:Enemigo
    {
        public override void EnemyMovement()
        {
            SetX(GetX() + 1); // pendiente de terminarlo
        }
    }
}
