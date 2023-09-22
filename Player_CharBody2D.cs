using Godot;
using System;

public partial class Player_CharBody2D : CharacterBody2D
{	
	private AnimatedSprite2D _animatedSprite;
	
	[Export]
	private float MoveSpeed = 64.0f;
	
	[Export]
	private float JumpVelocity = -128.0f;
	
	[Export]
	private float DoubleJumpVelocity = -96.0f;
	
	[Export]
	private bool DoubleJumpUnlocked = true;
	
	[Export]
	private bool HasDoubleJumped = false;
	
	public override void _Ready() 
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("Player_AnimatedSprite2D");
		_animatedSprite.Play("idle");
	}
	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("player_jump"))
			if(IsOnFloor()) {
				velocity.Y = JumpVelocity;
				HasDoubleJumped = false;
			}
			else {
				if(DoubleJumpUnlocked && !HasDoubleJumped){
					velocity.Y = JumpVelocity;
					HasDoubleJumped = true;
				}
			}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("player_move_left", "player_move_right", "player_move_up", "player_move_down");
		if (direction != Vector2.Zero)
		{
			if(velocity.X > 0) {
				_animatedSprite.FlipH = false;
			}
			else if(velocity.X < 0){
				_animatedSprite.FlipH = true;
			}
			
			velocity.X = direction.X * MoveSpeed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, MoveSpeed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
