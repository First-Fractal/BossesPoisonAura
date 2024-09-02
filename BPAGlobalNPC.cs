using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BossesPoisonAura
{
    internal class BPAGlobalNPC : GlobalNPC
    {
        public override void AI(NPC npc)
        {
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
                        if (Vector2.Distance(player.Center, npc.Center) < 30 * 16)
                        {
                            //give the player the buff
                            player.AddBuff(BuffID.Poisoned, 1);
                        }
                    }
                }
            }
            
            base.AI(npc);
        }
    }
}
