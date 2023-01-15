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
        [HarmonyPostfix]
        [HarmonyPatch(MethodType.Constructor)]
        public static void Constructor(CompGatherSpot __instance)
        {
            // __instance.active = false;
            FieldInfo fi = AccessTools.Field(typeof(CompGatherSpot),"active");
            fi.SetValue(__instance, false);
        }
    }
}
