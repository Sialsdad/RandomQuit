using System;
using GorillaLocomotion;
using HarmonyLib;

namespace RandomQuit.Patches;

[HarmonyPatch(typeof(Player))]
[HarmonyPatch("Awake", MethodType.Normal)]
internal class ExamplePatch
{
	private static void Postfix(Player __instance)
	{
		Console.WriteLine(__instance.maxJumpSpeed);
	}
}
