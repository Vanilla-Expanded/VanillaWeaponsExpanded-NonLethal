using RimWorld;
using UnityEngine;
using Verse;


namespace VanillaWeaponsExpandedNonLethal
{



    public class VanillaWeaponsExpandedNonLethal_Mod : Mod
    {


        public VanillaWeaponsExpandedNonLethal_Mod(ModContentPack content) : base(content)
        {
            GetSettings<VanillaWeaponsExpandedNonLethal_Settings>();
        }

        public override string SettingsCategory()
        {
            return "VWE - Non-lethal";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            VanillaWeaponsExpandedNonLethal_Settings.DoWindowContents(inRect);
        }
    }


}
