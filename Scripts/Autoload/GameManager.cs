using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
	private int _maxPlayers = 4;
	
	public PackedScene PlayerScene;
	
	public int FlowersCollected = 0;
	public List<Player> Players = new List<Player>();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayerScene = (PackedScene)ResourceLoader.Load("res://Scenes/Entities/Player.tscn");
		
		Viewport root = GetTree().Root;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	public void AddPlayer(Player player)
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
	
	public void PickupFlowers(int count)
	{
		FlowersCollected += count;
	}
	
}
