
using Verse;
using System;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using VanillaWeaponsExpandedNonLethal;



namespace VanillaWeaponsExpandedNonLethal
{
    [StaticConstructorOnStartup]
    public static class StaticCollections
    {
        static StaticCollections()
        {
            foreach (UnaffectedByNonLethalDef unaffected in DefDatabase<UnaffectedByNonLethalDef>.AllDefsListForReading)
            {
                foreach (string thing in unaffected.unaffectedDefs)
                {
                    unaffectedDefnames.Add(thing);
                }
            }
        }

        // A list of designators that shouldn't appear on the architect menu.
        public static HashSet<string> unaffectedDefnames = new HashSet<string>();

       

    }
}
