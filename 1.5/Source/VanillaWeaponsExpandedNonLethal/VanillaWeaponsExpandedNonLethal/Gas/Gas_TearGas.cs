﻿using System.Collections.Generic;
using RimWorld;
using Verse;

namespace VanillaWeaponsExpandedNonLethal
{
    public class Gas_TearGas : Gas
    {
        public const int refreshTicks = 120;
        public const int severityPerTick = 1;

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, true);
            destroyTick = Find.TickManager.TicksGame + def.gas.expireSeconds.RandomInRange.SecondsToTicks();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<int>(ref destroyTick, "destroyTick", 0, false);
        }

        public override void Tick()
        {
            if (destroyTick <= Find.TickManager.TicksGame)
            {
                Destroy(DestroyMode.Vanish);
            }
            graphicRotation += graphicRotationSpeed;
            if (!Destroyed && Find.TickManager.TicksGame % refreshTicks == 0)
            {
                Map map = Map;
                IntVec3 position = Position;
                List<Thing> thingList = position.GetThingList(map);
                if (thingList.Count > 0)
                {
                    for (int i = 0; i < thingList.Count; i++)
                    {
                        if(thingList[i] is Pawn) {

                            Pawn pawn = thingList[i] as Pawn;
                            if (pawn?.RaceProps?.IsMechanoid != true
                                && (VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsInsectoidsBosses || !DamageWorker_AddInjury_NoMechs.untameableInsects.Contains(pawn.def.defName))
                                && (VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsAnomalies || !pawn.IsEntity)
                                && (VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsXMLDefined || !StaticCollections.unaffectedDefnames.Contains(pawn.def.defName))
                                && !pawn.Dead
                                && pawn.Position == position)
                            {
                                DoOPToxicGas(this, thingList[i]);
                            }
                        }
                        
                    }
                }
            }
        }

        public void DoOPToxicGas(Thing Gas, Thing targ)
        {
            if (targ is Pawn pawn && pawn.health.capacities.CapableOf(PawnCapacityDefOf.Breathing))
            {

                bool hasMask = false;


                List<Apparel> wornApparel = pawn.apparel?.WornApparel;
                if (wornApparel?.Count > 0)
                {
                    for (int i = 0; i < wornApparel.Count; i++)
                    {
                        if (wornApparel[i].def == ThingDefOf.Apparel_GasMask)
                        {
                            hasMask = true;
                            //Log.Message("gas mask found");
                            break;
                        }

                    }
                }
                if (!hasMask)
                {
                    HediffDef hediffToApply = InternalDefOf.VWE_TearGas;
                    if (hediffToApply != null)
                    {
                        Pawn_HealthTracker health = pawn.health;
                        Hediff hediff;
                        if (health == null)
                        {
                            hediff = null;
                        }
                        else
                        {
                            HediffSet hediffSet = health.hediffSet;
                            hediff = (hediffSet?.GetFirstHediffOfDef(hediffToApply, false));
                        }
                        float statValue = 1 - pawn.GetStatValue(StatDefOf.ToxicResistance, true);
                        float num = severityPerTick;
                        if (num < 0.01f)
                        {
                            num = 0.01f;
                        }
                        float num2 = Rand.Range(0.01f * statValue, num * statValue);
                        if (hediff != null && num2 > 0f)
                        {
                            hediff.Severity += num2;
                            return;
                        }
                        Hediff hediff2 = HediffMaker.MakeHediff(hediffToApply, pawn, null);
                        hediff2.Severity = num2;
                        pawn.health.AddHediff(hediff2, null, null, null);
                    }
                }


            }
        }
    }
}