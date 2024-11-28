
using RimWorld;
using Verse;

namespace VanillaWeaponsExpandedNonLethal
{
    public class DamageWorker_ConditionalStun : DamageWorker_AddInjury
    {
      


        protected override void ApplySpecialEffectsToPart(Pawn pawn, float totalDamage, DamageInfo dinfo, DamageResult result)
        {
            base.ApplySpecialEffectsToPart(pawn, totalDamage, dinfo, result);
            if (!pawn.RaceProps.IsMechanoid &&
                (VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsInsectoidsBosses || !DamageWorker_AddInjury_NoMechs.untameableInsects.Contains(pawn.def.defName))
                && (VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsAnomalies || !pawn.IsEntity)
                && (VanillaWeaponsExpandedNonLethal_Settings.anestheticAffectsXMLDefined || !StaticCollections.unaffectedDefnames.Contains(pawn.def.defName))
                && !pawn.Dead && result.totalDamageDealt > 0f)
            {
                DamageInfo dinfo2 = dinfo;
                dinfo2.Def = DamageDefOf.Stun;
                dinfo2.SetAmount(45);
                pawn.TakeDamage(dinfo2);
            }
        }

       
    }
}