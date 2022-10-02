using System;
using HarmonyLib;
using UnityEngine;
    
namespace PickupLock.Patches;

[HarmonyPatch(typeof(TileObject), "canBePickedUp")]
internal class PatchPickUp
{
    [HarmonyPostfix]
    private static void PostfixGetMyTemplate(ref TileObject __instance, ref bool __result)
    {
        if (!getPickupEnabled())
        {
            Console.WriteLine("Fixing pickup status for :" + __instance.name);
            __result = false;
        }
    }

    public static bool getPickupEnabled()
    {
        var plugin = Plugin.Instance;
        return plugin.GetIsEnabled();
    }
}