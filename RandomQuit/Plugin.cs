using System;
using System.ComponentModel;
using System.Threading;
using BepInEx;
using UnityEngine;
using Utilla;

namespace RandomQuit;

[Description("HauntedModMenu")]
[BepInPlugin("gorillatag.randomquit", "RandomQuit", "1.0.0")]
[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
[ModdedGamemode]
public class Plugin : BaseUnityPlugin
{
	private bool inRoom;

	public int seconds2 = 200;

	private bool waitdone = false;

	public int seconds;

	private bool on = false;

	private void Start()
	{
		Events.GameInitialized += OnGameInitialized;
	}

	private void OnEnable()
	{
		on = true;
		HarmonyPatches.ApplyHarmonyPatches();
	}

	private void OnDisable()
	{
		on = false;
		HarmonyPatches.RemoveHarmonyPatches();
	}

	private void newrandom(object o)
	{
		Random random = new Random();
		seconds = random.Next(1000, 3930000);
	}

	private void OnGameInitialized(object sender, EventArgs e)
	{
		newrandom(null);
		System.Threading.Timer timer = new System.Threading.Timer(newrandom, null, 0, seconds2);
		System.Threading.Timer timer2 = new System.Threading.Timer(Quit, null, 0, seconds);
	}

	private void Quit(object o)
	{
		Application.Quit();
	}

	private void Update()
	{
	}

	[ModdedGamemodeJoin]
	public void OnJoin(string gamemode)
	{
		inRoom = true;
	}

	[ModdedGamemodeLeave]
	public void OnLeave(string gamemode)
	{
		inRoom = false;
	}
}
