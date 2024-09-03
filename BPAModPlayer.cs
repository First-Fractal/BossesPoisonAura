using System;
using Terraria.ModLoader;

namespace BossesPoisonAura
{
    internal class BPAModPlayer : ModPlayer
    {
        public bool bluePoison = false;

        //reset the blue poison to be false when not active
        public override void ResetEffects()
        {
            bluePoison = false;
            base.ResetEffects(); 
        }

        //set the blue poison to be false when drsf
        public override void UpdateDead()
        {
            bluePoison = false;
            base.UpdateDead();
        }

        public override void UpdateBadLifeRegen()
        {
            //give the player negative life regen when having blue poison
            if (bluePoison)
            {
                //make it override all of the player postive regen
                if (Player.lifeRegen > 0) Player.lifeRegen = 0;
                //make it lose 4 hp per sec
                Player.lifeRegen -= 8;
            }
            base.UpdateBadLifeRegen();
        }

    }
}
