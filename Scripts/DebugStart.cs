using Godot;
using System;

public partial class DebugStart : Node2D
{
	private GameManager gameManager;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameManager = (GameManager)GetNode("/root/GameManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionPressed("player_jump"))
		{
			gameManager.GotoScene("res://Scenes/Stages/Forest100_GameStage.tscn", "HouseSpawn");
		}
	}
}
