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
            else return base.Apply(dinfo, thing);


        }




    }


}



