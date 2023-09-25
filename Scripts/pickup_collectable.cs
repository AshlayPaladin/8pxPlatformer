using Godot;
using System;

public partial class pickup_collectable : Node2D
{
	// Enumerations
	public enum FlowerType {
		Blue,
		White
	}
	
	// Private Members : Nodes
	private Area2D _area;
	private AnimatedSprite2D _animatedSprite;
	private AudioStreamPlayer2D _sfxPlayer;
	private AudioStream _pickupSfx;
	private GameManager gameManager;
	
	// Private Members
	[Export] private FlowerType flowerType = FlowerType.Blue;
	[Export] private string pathToPickupSfx = "res://content/Sound/sfx/Pickup1.ogg";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_area = GetNode<Area2D>("Area2D");
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_sfxPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		_pickupSfx = (AudioStream)ResourceLoader.Load(pathToPickupSfx);
		gameManager = GetNode<GameManager>("/root/GameManager");
		
		switch(flowerType) {
			case FlowerType.Blue:
				_animatedSprite.Play("blueflower_idle");
				break;
			case FlowerType.White:
				_animatedSprite.Play("whiteflower_idle");
				break;
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _on_area_2d_area_entered(Area2D area)
	{
	// Replace with function body.
	switch(flowerType) {
			case FlowerType.Blue:
				gameManager.PickupFlowers(5);
				break;
			case FlowerType.White:
				gameManager.PickupFlowers(10);
				break;
		}
	
		// Play SFX
		_sfxPlayer.Stream = _pickupSfx;
		_sfxPlayer.Play();
	
		// DESTROY
		Visible = false;
		_area.SetDeferred("Monitoring", false);
	}
	
	private void _on_audio_stream_player_2d_finished()
	{
		// Replace with function body.
		QueueFree();
	}
}


