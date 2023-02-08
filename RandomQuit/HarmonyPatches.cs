using System.Reflection;
using HarmonyLib;

namespace RandomQuit;

public class HarmonyPatches
{
	private static Harmony instance;

	public const string InstanceId = "gorillatag.randomquit";

	public static bool IsPatched { get; private set; }

	internal static void ApplyHarmonyPatches()
	{
		if (!IsPatched)
		{
			if (instance == null)
			{
				instance = new Harmony("gorillatag.randomquit");
			}
			instance.PatchAll(Assembly.GetExecutingAssembly());
			IsPatched = true;
		}
	}

	internal static void RemoveHarmonyPatches()
	{
		if (instance != null && IsPatched)
		{
			instance.UnpatchSelf();
			IsPatched = false;
		}
	}
}
