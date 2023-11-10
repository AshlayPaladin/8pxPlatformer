using Godot;
using System;

public partial class NetworkLobbyPlayerControl : Control
{
	private Label PlayerNameLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayerNameLabel = GetNode<Label>("PlayerNameLabel");
		PlayerNameLabel.Text = "_PLAYERNAME_";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_character_customize_control_on_texture_changed(string headColor, string bodyColor)
	{
		// Replace with function body.
		
	}
}
