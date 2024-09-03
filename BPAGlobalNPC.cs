using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BossesPoisonAura
{
    internal class BPAGlobalNPC : GlobalNPC
    {
        //the radius of the poison aura is 30 blocks (16 pixels in one block)
        public static int radius;
        public override void AI(NPC npc)
        {
            radius = 20 * 16;

            //check if the current npc is a boss
            if (ffFunc.IsNPCaBoss(npc))
            {
                //loop through all players in the game
                foreach (Player player in Main.player)
                {
                    //check if the current player exists and not dead
                    if (player.active && !player.dead)
                    {
                        //check if the player is close enough to the boss
                        if (Vector2.Distance(player.Center, npc.Center) < radius)
                        {
                            //give the player the buff
                            player.AddBuff(BuffID.Poisoned, 1);
                        }
                    }
                }
            }
            
            base.AI(npc);
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            //check if the npc is a boss
            if (ffFunc.IsNPCaBoss(npc))
            {
                //define how much dust for the radius
                int radiusDustAmount = 180;

                //create the dusts needed
                for (int i = 0; i < radiusDustAmount; i++)
                {
                    //set the inital offset of the dust
                    Vector2 offset = new Vector2(radius, 0);

                    //rotate the offset
                    int rotateBy = 360 / radiusDustAmount * i;
                    offset = offset.RotatedBy(MathHelper.ToRadians(rotateBy));

                    //create the dust
                    Dust radiusDust = Dust.NewDustPerfect(npc.Center + offset, 39, Vector2.Zero);

                    //make it not have gravity and only use the first frame of it
                    radiusDust.noGravity = true;
                    radiusDust.firstFrame = true;

                }
            }
            base.DrawEffects(npc, ref drawColor);
        }
    }
}
