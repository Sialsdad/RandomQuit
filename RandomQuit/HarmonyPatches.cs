using System.Reflection;
using HarmonyLib;

namespace RandomQuit;

public class HarmonyPatches
{
	private static Harmony instance;

	public const string InstanceId = "com.depromo.gorillatag.randomquit";

	public static bool IsPatched { get; private set; }

	internal static void ApplyHarmonyPatches()
	{
		if (!IsPatched)
		{
			if (instance == null)
			{
				instance = new Harmony("com.depromo.gorillatag.randomquit");
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
