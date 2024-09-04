using System;
using Terraria.ModLoader;

namespace BossesPoisonAura
{
    internal class BPAModPlayer : ModPlayer
    {
        //variables for if the blue poison is active and the amount of damage it does
        public bool bluePoison = false;
        public int intialPoison = 10;

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
                //check how much poison nerf upgrades the world has
                double poisonNerf = 0;
                foreach(int upgrade in ModContent.GetInstance<BPAModSystem>().upgrades)
                {
                    if (upgrade == upgradeType.poison) poisonNerf++;
                }

                //make it override all of the player postive regen
                if (Player.lifeRegen > 0) Player.lifeRegen = 0;
                
                //nerf the posion if there is any upgrades for it
                if (poisonNerf > 0) intialPoison = (int)(intialPoison * Math.Pow(0.66, poisonNerf));

                //make it lose hp
                Player.lifeRegen -= intialPoison;
            }
            base.UpdateBadLifeRegen();
        }

    }
}
