using Godot;
using System;

public partial class RoomTransition : Node2D
{
	[Export] private string pathToDestinationScene;
	[Export] private string destinationMarkerId;
	private Node stageNode;
	private GameManager gameManager;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameManager = GetNode<GameManager>("/root/GameManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _on_area_2d_area_entered(Area2D area)
	{
		// TRANSITION TO NEW ROOM
		gameManager.GotoScene(pathToDestinationScene, destinationMarkerId);
	}
}
