using Godot;
using System;

public partial class SceneManager : Node
{
	[Export] private PackedScene initialPackedScene;
	private Node2D CurrentSceneNode;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Node2D startingScene = (Node2D)initialPackedScene.Instantiate();
		//GetTree().Root.ContentScaleFactor = 1.0f;
		AddChild(startingScene);
		CurrentSceneNode = (Node2D)GetChildren()[0];
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
		public void GotoScene(string path, string markerId)
	{
		CallDeferred(nameof(DeferredGotoScene), path, markerId);
	}
	
	public void DeferredGotoScene(string path, string markerId)
	{
		RemoveChild(CurrentSceneNode);
		CurrentSceneNode.QueueFree();
		
		PackedScene newScene = (PackedScene)ResourceLoader.Load(path);
		Node2D newStageNode = (Node2D)newScene.Instantiate();
		
		CurrentSceneNode = newStageNode;
		AddChild(CurrentSceneNode);
		
		GameStage newStage = (GameStage)newStageNode;
		newStage.SpawnPlayerAtMarker(markerId);
	}
}
