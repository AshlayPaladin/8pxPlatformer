using Godot;
using System;

public partial class Forest100_GameStage : GameStage
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddSpawnPoint(GetNode<SpawnMarker>("HouseSpawn"));
		AddSpawnPoint(GetNode<SpawnMarker>("CaveDoorSpawn"));
		
		gameManager = GetNode<GameManager>("/root/GameManager");
		bgmPlayer = GetNode<BgmAudioStreamPlayer>("/root/BgmAudioStreamPlayer");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
