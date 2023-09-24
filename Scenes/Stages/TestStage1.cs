using Godot;
using System;

public partial class TestStage1 : Node2D
{
	RichTextLabel flowersLabel;
	NodePath cameraPath;
	Marker2D spawnMarker;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		flowersLabel = GetNode<RichTextLabel>("FlowersCollected_Label");
		flowersLabel.Text = $"x{GameManager.FlowersCollected}";
		
		spawnMarker = GetNode<Marker2D>("PlayerSpawn_Marker2D");
		
		// Initialization Setup
		Player newPlayer = (Player)GameManager.PlayerScene.Instantiate();
		newPlayer.SetRespawnPoint(spawnMarker.GlobalPosition);
		newPlayer.Respawn();
		AddChild(newPlayer);
		newPlayer.LockCamera("../../Camera2D");
		GameManager.AddPlayer(newPlayer);
	}
	
	public override void _Process(double delta)
	{
		flowersLabel.Text = $"x{GameManager.FlowersCollected}";
	}
}
