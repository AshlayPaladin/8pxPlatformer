using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{
	private AnimatedSprite2D _animatedSprite;
	
	public enum PickupType{
		BlueFlower,
		WhiteFlower
	}
	
	[Export]
	private PickupType ItemType = PickupType.BlueFlower;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
		switch (ItemType)
		{
			case PickupType.BlueFlower:
				_animatedSprite.Play("blueflower_idle");
				break;
			case PickupType.WhiteFlower:
				_animatedSprite.Play("whiteflower_idle");
				break;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
