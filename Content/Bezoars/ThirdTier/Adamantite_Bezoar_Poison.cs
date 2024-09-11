using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace BossesPoisonAura.Content.Bezoars.ThirdTier
{
    internal class Adamantite_Bezoar_Poison : ModItem
    {
        public override void SetStaticDefaults()
        {
            //make it shimmer to the adamantite bezoar aura
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Adamantite_Bezoar_Aura>();
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            //set the stats of the item
            Item.width = 29;
            Item.height = 25;
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
                //check if the third tier hasn't been upgraded yet
                if (ModContent.GetInstance<BPAModSystem>().upgrades[2] == upgradeType.none)
                {
                    //set the third upgrade to be poison and display it in the chat
                    ModContent.GetInstance<BPAModSystem>().upgrades[2] = upgradeType.poison;
                    ffFunc.Talk(Language.GetTextValue("Mods.BossesPoisonAura.Chat.Poison"), new Color(50, 255, 130));
                }
                else
                {
                    //tell the player that they already made the upgrade
                    ffFunc.Talk(Language.GetTextValue("Mods.BossesPoisonAura.Chat.Used3"), new Color(50, 255, 130));
                }
            }
            return base.UseItem(player);
        }
    }
}
