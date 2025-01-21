using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using BossesPoisonAura.Content.Bezoars.FirstTier;
using BossesPoisonAura.Content.Bezoars.SecondTier;
using BossesPoisonAura.Content.Bezoars.ThirdTier;
using BossesPoisonAura.Content.Bezoars.FourthTier;

namespace BossesPoisonAura
{

    //set the names for the upgrades
    public static class upgradeType
    {
        public static int none = 0;
        public static int aura = 1;
        public static int poison = 2;
    }

    internal class BPAModSystem : ModSystem
    {
        //create the upgrades list
        public int[] upgrades = [upgradeType.none, upgradeType.none, upgradeType.none, upgradeType.none];

        //save the upgrades to the world
        public override void SaveWorldData(TagCompound tag)
        {
            tag["upgrade"] = upgrades;
            base.SaveWorldData(tag);
        }

        //load the upgrades to the world
        public override void LoadWorldData(TagCompound tag)
        {
            if (tag.ContainsKey("upgrade"))
            {
                upgrades = tag.Get<int[]>("upgrade");
            }
        }
        
        //set the upgrades back to default when leaving the world to not get carry over between worlds
        public override void OnWorldUnload()
        {
            upgrades = [upgradeType.none, upgradeType.none, upgradeType.none, upgradeType.none];
            base.OnWorldUnload();
        }

        //send the upgrades to everyone in the world
        public override void NetSend(BinaryWriter writer)
        {
            for (int i = 0; i < upgrades.Length; i++)
            {
                writer.Write(upgrades[i]);
            }
            base.NetSend(writer);
        }



        //reccive the upgrades from everyone in the world
        public override void NetReceive(BinaryReader reader)
        {
            for (int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i] = reader.ReadInt32();
            }
            base.NetReceive(reader);
        }

        public override void AddRecipes()
        {
            //add in a way to get a partial refund on the blue bezoar
            Recipe recipe = Recipe.Create(ItemID.Bezoar);
            recipe.AddIngredient(ModContent.ItemType<Blue_Bezoar>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            //add in a way to get a partial refund on the crimtaine bezoar
            recipe = Recipe.Create(ItemID.Bezoar);
            recipe.AddIngredient(ModContent.ItemType<Crimtaine_Bezoar>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            //add in a way to get a partial refund on the demonite bezoar
            recipe = Recipe.Create(ItemID.Bezoar);
            recipe.AddIngredient(ModContent.ItemType<Demonite_Bezoar>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            //add in a way to get a partial refund on the adamanite bezoar
            recipe = Recipe.Create(ItemID.Bezoar);
            recipe.AddIngredient(ModContent.ItemType<Adamantite_Bezoar>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            //add in a way to get a partial refund on the titanium bezoar
            recipe = Recipe.Create(ItemID.Bezoar);
            recipe.AddIngredient(ModContent.ItemType<Titanium_Bezoar>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            //add in a way to get a partial refund on the titanium bezoar
            recipe = Recipe.Create(ItemID.Bezoar);
            recipe.AddIngredient(ModContent.ItemType<Ectoplasm_Bezoar>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            base.AddRecipes();
        }
    }
}
