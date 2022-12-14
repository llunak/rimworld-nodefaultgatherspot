using HarmonyLib;
using RimWorld;
using Verse;
using System;
using System.Reflection;

namespace NoDefaultGatherSpot
{
    [StaticConstructorOnStartup]
    public class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("llunak.NoDefaultGatherSpot");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(CompGatherSpot))]
    public static class CompGatherSpot_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(PostSpawnSetup))]
        public static void PostSpawnSetup(CompGatherSpot __instance, bool respawningAfterLoad)
        {
            if (!respawningAfterLoad)
            {
                // __instance.active = false;
                FieldInfo fi = AccessTools.Field(typeof(CompGatherSpot),"active");
                fi.SetValue(__instance, false);
            }
        }
    }
}
