using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BossesPoisonAura.Content
{
    internal class Blue_Poison : ModBuff
    {
        //make the blue poison a debuff, not a pvp buff, not save when leaving the world, and not longer in expert mode
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //set the player blue poison flag to be true
            player.GetModPlayer<BPAModPlayer>().bluePoison = true;
            base.Update(player, ref buffIndex);
        }
    }
}
