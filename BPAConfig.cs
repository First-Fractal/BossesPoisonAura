﻿using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace BossesPoisonAura
{
    internal class BPAConfig : ModConfig
    {
        //tell the mod that the configs are on the server and logistical side of the mod. 
        public override ConfigScope Mode => ConfigScope.ServerSide;

        //define the instance for the mod
        public static BPAConfig Instance;

        //display the general options line 
        [Header("$Mods.BossesPoisonAura.Configs.GeneralOptions")]

        //define the config value for the particle count of the aura
        [DefaultValue(180)]
        [Slider()]
        [DrawTicks()]
        [Increment(30)]
        [Range(0, 360)]
        public int BossAuraParticleCount;

        //define the config value for the boss aura intial radius
        [DefaultValue(20)]
        [Slider()]
        [Range(5, 60)]
        public int BossAuraInitalRadius;

        //define the config value for using the custom poison
        [DefaultValue(true)]
        public bool customPoison;
    }
}
