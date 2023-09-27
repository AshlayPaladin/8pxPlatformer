using Godot;
using System;
using System.Collections.Generic;

public partial class GameStage : Node2D
{
	// Private Members
	[Export] protected string stageId;
	[Export] protected string pathToBGMFile;

	// Private Members : Nodes
	protected NodePath cameraPath = "../../Camera2D";
	protected GameManager gameManager;
	protected BgmAudioStreamPlayer bgmPlayer;

	// Private Members : Collections
	protected List<SpawnMarker> spawnPoints = new List<SpawnMarker>();
	protected List<RoomTransition> roomTransitions = new List<RoomTransition>();
	
	// Public Properties
	public string StageID
	{
		get { return stageId; }
	}
	
	public void SpawnPlayerAtMarker(string spawnMarkerId)
	{
		SpawnPlayerAtPoint(spawnMarkerId);
		bgmPlayer.Play(pathToBGMFile);
	}

	public void AddSpawnPoint(SpawnMarker spawnMarker) 
	{
		spawnPoints.Add(spawnMarker);
	}

	public void SpawnPlayerAtPoint(string spawnPointId)
	{
		SpawnMarker _marker = GetSpawnPointById(spawnPointId);
		Player newPlayer = (Player)gameManager.PlayerScene.Instantiate();
		newPlayer.SetRespawnPoint(_marker.GetMarkerGlobalPosition());
		newPlayer.Respawn();
		AddChild(newPlayer);
		newPlayer.LockCamera(cameraPath);
	}

	protected SpawnMarker GetSpawnPointById(string id)
	{
		foreach(SpawnMarker s in spawnPoints)
		{
			if(s.MarkerID == id)
			{
				return s;
			}
		}

		return null;
	}
}
