using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BossesPoisonAura.Content.Bezoars
{
    internal class Blue_Bezoar : ModItem
    {
        public override void SetStaticDefaults()
        {
            //make it shimmer to the blue bezoar poison
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Blue_Bezoar_Poison>();
            base.SetStaticDefaults();
        }

        //clone the defaults of bezoar while also modifying some values
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bezoar);
            Item.width = 28;
            Item.height = 24;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.sellPrice(gold: 2, silver: 50);
        }

        //make it where wearing this will make you immune to poison
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Poisoned] = true;
            base.UpdateAccessory(player, hideVisual);
        }

        //make it craftable via bezoar + 20 glow mushrooms at a workbench
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bezoar);
            recipe.AddIngredient(ItemID.GlowingMushroom, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
            base.AddRecipes();
        }
    }
}
