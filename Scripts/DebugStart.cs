using Godot;
using System;

public partial class DebugStart : Node2D
{
	private GameManager gameManager;
	private SceneManager sceneManager;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameManager = GetNode<GameManager>("/root/GameManager");
		sceneManager = GetNode<SceneManager>("/root/SceneManager");
		//GetTree().Root.ContentScaleFactor = 1.0f;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void _on_start_button_pressed()
	{
		sceneManager.GotoScene("res://Scenes/Stages/Forest100_GameStage.tscn", "HouseSpawn");
		//GetTree().Root.ContentScaleFactor = 4.0f;
	}	
	
	private void _on_exit_button_pressed()
	{
		GetTree().Quit();
	}
}
