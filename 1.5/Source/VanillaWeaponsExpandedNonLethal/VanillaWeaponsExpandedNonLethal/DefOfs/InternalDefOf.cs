using System;
using RimWorld;
using Verse;
using System.Collections.Generic;

namespace VanillaWeaponsExpandedNonLethal
{
    [DefOf]
    public static class InternalDefOf
    {
        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }

        public static HediffDef VWE_Anesthetic;
       


    }
}
