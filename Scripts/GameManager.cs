using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
	private static int _maxPlayers = 4;
	
	public static PackedScene PlayerScene;
	public static int FlowersCollected = 0;
	public static List<Player> Players = new List<Player>();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayerScene = (PackedScene)ResourceLoader.Load("res://Scenes/Player.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public static void AddPlayer(Player player)
	{
		if(Players.Count <= _maxPlayers)
		{
			Players.Add(player);
		}
		else
		{
			// Players is Full, no new player can join
		}
	}
	
	public static void PickupFlowers(int count)
	{
		FlowersCollected += count;
	}
}
