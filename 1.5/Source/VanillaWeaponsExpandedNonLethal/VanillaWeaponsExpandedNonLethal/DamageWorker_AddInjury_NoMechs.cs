using System;
using RimWorld;
using Verse;
using UnityEngine;



namespace VanillaWeaponsExpandedNonLethal
{
    public class DamageWorker_AddInjury_NoMechs : DamageWorker_AddInjury
    {



        public override DamageResult Apply(DamageInfo dinfo, Thing thing)
        {
            Pawn pawn = thing as Pawn;
            if (pawn?.RaceProps?.IsMechanoid == true)
            {
                DamageResult damageResult = new DamageResult();
                return damageResult;
            }
            if (pawn.health.hediffSet.HasHediff(InternalDefOf.VWE_Anesthetic))
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



