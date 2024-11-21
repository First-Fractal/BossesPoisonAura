using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BossesPoisonAura
{
    internal class BPACommand : ModCommand
    {
        
        //make the command run on all sides, since it's client side
        public override CommandType Type => CommandType.Chat;

        //the start of the command
        public override string Command => "BPA";

        //explain on what the command does
        public override string Description => Language.GetTextValue("Mods.SlayingMinionsPissOffBosses.command.abbr.desc");


        //the trigger for the command
        public override void Action(CommandCaller caller, string input, string[] args)
        {
            //setup a blank message
            string message = "";

            //go through all of the upgrades
            for (int i = 0; i < ModContent.GetInstance<BPAModSystem>().upgrades.Length; i++)
            {
                //get the current upgrade
                int upgrade = ModContent.GetInstance<BPAModSystem>().upgrades[i];

                //translate it to the string version
                string upgradeMessage = "none";
                if (upgrade == upgradeType.poison) upgradeMessage = "poison";
                if (upgrade == upgradeType.aura) upgradeMessage = "aura";

                //add it to the message
                message += $"Upgrade #{i+1} is set to {upgradeMessage}.\n";
            }

            //reply to the player with the upgrades
            caller.Reply(message, Microsoft.Xna.Framework.Color.SeaGreen);
        }

    }
}
