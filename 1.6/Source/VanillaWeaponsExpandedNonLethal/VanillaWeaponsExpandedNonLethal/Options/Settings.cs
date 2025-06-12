using RimWorld;
using System;
using UnityEngine;
using Verse;


namespace VanillaWeaponsExpandedNonLethal
{


    public class VanillaWeaponsExpandedNonLethal_Settings : ModSettings

    {

        public static bool anestheticAffectsAnomalies = true;
        public static bool anestheticAffectsInsectoidsBosses = true;
        public static bool anestheticAffectsXMLDefined = true;



        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref anestheticAffectsAnomalies, "anestheticAffectsAnomalies", true);
            Scribe_Values.Look(ref anestheticAffectsInsectoidsBosses, "anestheticAffectsInsectoidsBosses", true);
            Scribe_Values.Look(ref anestheticAffectsXMLDefined, "anestheticAffectsXMLDefined", true);


        }



        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();


            ls.Begin(inRect);


            ls.CheckboxLabeled("VQE_MakeStunAndParalizeAffectAnomalies".Translate(), ref anestheticAffectsAnomalies, "VQE_MakeStunAndParalizeAffectAnomaliesDesc".Translate());
            ls.Gap(10);
            ls.CheckboxLabeled("VQE_MakeStunAndParalizeAffectInsectoidBosses".Translate(), ref anestheticAffectsInsectoidsBosses, "VQE_MakeStunAndParalizeAffectInsectoidBossesDesc".Translate());
            ls.Gap(10);
            ls.CheckboxLabeled("VQE_MakeStunAndParalizeAffectXMLDefined".Translate(), ref anestheticAffectsXMLDefined, "VQE_MakeStunAndParalizeAffectXMLDefinedDesc".Translate());


            ls.End();
        }





    }










}
