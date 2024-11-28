using System;
using RimWorld;
using Verse;
using UnityEngine;
using System.Collections.Generic;



namespace VanillaWeaponsExpandedNonLethal
{
    public class DamageWorker_AddInjury_NoMechs : DamageWorker_AddInjury
    {

        public static List<string> untameableInsects = new List<string>() { "VFEI2_Queen", "VFEI2_Empress", "VFEI2_Silverfish", "VFEI2_Teramantis", "VFEI2_Titantick", "VFEI2_Gigamite", "VFEI2_BlackEmpress", "VFEI2_Patriarch", "SW_Emperorisopod" };


        public override DamageResult Apply(DamageInfo dinfo, Thing thing)
        {
            Pawn pawn = thing as Pawn;
            if (pawn?.RaceProps?.IsMechanoid == true || (!VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsInsectoidsBosses && untameableInsects.Contains(pawn.def.defName)) 
                || (!VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsAnomalies && pawn.IsEntity)
                || (!VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsXMLDefined && StaticCollections.unaffectedDefnames.Contains(pawn.def.defName))
                )
            {
                DamageResult damageResult = new DamageResult();
                return damageResult;
            }
            if (pawn?.health?.hediffSet?.HasHediff(InternalDefOf.VWE_Anesthetic)==true)
            {
                if (pawn.health.hediffSet.GetFirstHediffOfDef(InternalDefOf.VWE_Anesthetic).Severity > 0.6f)
                {
                    DamageResult damageResult = new DamageResult();
                    return damageResult;
                }

            }


            return base.Apply(dinfo, thing);


        }




    }


}



