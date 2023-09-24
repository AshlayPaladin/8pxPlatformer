using Godot;
using System;
using System.Collections.Generic;

public partial class Player : CharacterBody2D
{	
	// Constants
	[Export] private string pathToJumpSfx = "res://content/Sound/sfx/Jump1.mp3";
	[Export] private string pathToDblJumpSfx = "res://content/Sound/sfx/Jump2.mp3";
	private const int SFX_ID_JUMP = 0;
	private const int SFX_ID_DBLJUMP = 1;
	
	// Private Members : Nodes
	private AnimatedSprite2D _animatedSprite;
	private Vector2 _respawnPoint;
	private RemoteTransform2D _remoteTransform2d;
	private AudioStreamPlayer2D _sfxPlayer;
	
	// Private Members : Collections
	private Dictionary<int,AudioStream> sfxLibrary = new Dictionary<int,AudioStream>();
	
	// Private Members
	private float MoveSpeed = 64.0f;
	private float JumpVelocity = -128.0f;
	private float DoubleJumpVelocity = -96.0f;
	private bool DoubleJumpUnlocked = true;
	private bool HasDoubleJumped = false;
	
	public override void _Ready() 
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("Player_AnimatedSprite2D");
		_animatedSprite.Play("browntop_walk");
		
		_remoteTransform2d = GetNode<RemoteTransform2D>("Player_RemoteTransform2D");
		
		_sfxPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		
		AudioStream jumpSfx = (AudioStream)ResourceLoader.Load(pathToJumpSfx);
		AudioStream dblJumpSfx = (AudioStream)ResourceLoader.Load(pathToDblJumpSfx);
		
		sfxLibrary.Add(SFX_ID_JUMP,jumpSfx);
		sfxLibrary.Add(SFX_ID_DBLJUMP,dblJumpSfx);
	}
	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{	
		if (Input.IsActionJustPressed("debug_respawn_test"))
		{
			Respawn();
		}
		
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("player_jump"))
			if(IsOnFloor()) {
				velocity.Y = JumpVelocity;
				HasDoubleJumped = false;
				_sfxPlayer.Stream = sfxLibrary[SFX_ID_JUMP];
				_sfxPlayer.Play();
			}
			else {
				if(DoubleJumpUnlocked && !HasDoubleJumped){
					velocity.Y = JumpVelocity;
					HasDoubleJumped = true;
					_sfxPlayer.Stream = sfxLibrary[SFX_ID_DBLJUMP];
					_sfxPlayer.Play();
				}
			}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("player_move_left", "player_move_right", "player_move_up", "player_move_down");
		if (direction != Vector2.Zero)
		{
			if(velocity.X > 0) {
				_animatedSprite.FlipH = false;
				_animatedSprite.Play("browntop_walk");
			}
			else if(velocity.X < 0){
				_animatedSprite.FlipH = true;
				_animatedSprite.Play("browntop_walk");
			}
			
			velocity.X = direction.X * MoveSpeed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, MoveSpeed);
			_animatedSprite.Play("browntop_idle");
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	
	public void LockCamera(NodePath camera)
	{
		_remoteTransform2d.RemotePath = camera;
	}
	
	public void SetRespawnPoint(Vector2 globalPosition)
	{
		_respawnPoint = globalPosition;
	}
	
	public void Respawn()
	{
		Position = _respawnPoint;
	}
}
