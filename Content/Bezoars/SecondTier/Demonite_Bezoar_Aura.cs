using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace BossesPoisonAura.Content.Bezoars.SecondTier
{
    internal class Demonite_Bezoar_Aura : ModItem
    {
        public override void SetStaticDefaults()
        {
            //make it shimmer to the demonite bezoar poison
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Demonite_Bezoar_Poison>();
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            //set the stats of the item
            Item.width = 29;
            Item.height = 26;
            Item.rare = ItemRarityID.LightPurple;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item29;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 2, silver: 50);
            Item.consumable = true;
        }

        public override bool? UseItem(Player player)
        {
            //check if it's the animation is not being played rn, and it's on the right side of networking
            if (player.itemAnimation > 0 && player.itemTime == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                //set the item time to the use time
                player.itemTime = Item.useTime;
                //check if the second tier hasn't been upgraded yet
                if (ModContent.GetInstance<BPAModSystem>().upgrades[1] == upgradeType.none)
                {
                    //set the second upgrade to be aura and display it in the chat
                    ModContent.GetInstance<BPAModSystem>().upgrades[1] = upgradeType.aura;
                    ffFunc.Talk(Language.GetTextValue("Mods.BossesPoisonAura.Chat.Aura"), new Color(50, 255, 130));
                }
                else
                {
                    //tell the player that they already made the upgrade
                    ffFunc.Talk(Language.GetTextValue("Mods.BossesPoisonAura.Chat.Used2"), new Color(50, 255, 130));
                }
            }
            return base.UseItem(player);
        }
    }
}
