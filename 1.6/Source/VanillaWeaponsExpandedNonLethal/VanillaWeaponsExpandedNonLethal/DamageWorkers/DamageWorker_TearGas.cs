using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace VanillaWeaponsExpandedNonLethal
{
    public class DamageWorker_TearGas : DamageWorker
    {
        public override void ExplosionStart(Explosion explosion, List<IntVec3> cellsToAffect)
        {
            if (def.explosionHeatEnergyPerCell > 1.401298E-45f)
            {
                GenTemperature.PushHeat(explosion.Position, explosion.Map, def.explosionHeatEnergyPerCell * cellsToAffect.Count);
            }
            FleckMaker.Static(explosion.Position, explosion.Map, FleckDefOf.ExplosionFlash, explosion.radius * 6f);
            FleckMaker.Static(explosion.Position, explosion.Map, FleckDefOf.ExplosionFlash, explosion.radius * 6f);
            ExplosionVisualEffectCenter(explosion);
        }

        public override DamageResult Apply(DamageInfo dinfo, Thing victim)
        {
            DamageResult damageResult = new DamageResult();
            Pawn pawn = victim as Pawn;
            if (pawn?.RaceProps?.IsMechanoid != true               
                && (VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsInsectoidsBosses || !DamageWorker_AddInjury_NoMechs.untameableInsects.Contains(pawn.def.defName))
                && (VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsAnomalies || !pawn.IsEntity)
                && (VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsXMLDefined || !StaticCollections.unaffectedDefnames.Contains(pawn.def.defName))
                && !pawn.Dead
    
                )
            {
                bool hasMask = false;

                Pawn pawnVictim = victim as Pawn;
                List<Apparel> wornApparel = pawnVictim.apparel?.WornApparel;
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
                    //Log.Message("no gas mask found");
                    float amount = dinfo.Amount;
                    damageResult.totalDamageDealt = Mathf.Min(victim.HitPoints, GenMath.RoundRandom(amount));
                    victim.HitPoints -= Mathf.RoundToInt(damageResult.totalDamageDealt);
                    if (victim.HitPoints <= 0)
                    {
                        victim.HitPoints = 0;
                        victim.Kill(new DamageInfo?(dinfo), null);
                    }

                }

            }
            return damageResult;
        }
    }
}