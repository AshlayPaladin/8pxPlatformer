using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class CharacterCustomizeControl : Control
{
	// Private Fields
	private int _selectedBody = 0;
	private int _selectedHead = 0;

	private int _lastBodyIndex;
	private int _lastHeadIndex;

	// Collections
	private List<string> _bodies = new List<string>() { "Brown", "White", "Purple" };
	private List<string> _heads = new List<string>() { "Red", "Blue", "Green" };

	// Properties
	public string Body;
	public string Head;

	// Objects
	private Texture2D _headTexture;
	private Texture2D _bodyTexture;
	private TextureRect _headTextureRect;
	private TextureRect _bodyTextureRect;

	// Signal Delegates
	[Signal]
	public delegate void OnTextureChangedEventHandler(string headColor, string bodyColor);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Body = _bodies.ElementAt(_selectedBody);
		Head = _heads.ElementAt(_selectedHead);

		_lastBodyIndex = _bodies.Count - 1;
		_lastHeadIndex = _heads.Count - 1;

		_headTextureRect = GetNode<TextureRect>("HeadTextureRect");
		_bodyTextureRect = GetNode<TextureRect>("BodyTextureRect");

		UpdateTextures();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_next_head_button_pressed()
	{
		// Advance in list of Head options, looping back to first at end
		_selectedHead = _selectedHead + 1;

		if(_selectedHead > _lastHeadIndex)
		{
			_selectedHead = 0;
		}

		Head = _heads.ElementAt(_selectedHead);
		UpdateTextures();
	}


	private void _on_next_body_button_pressed()
	{
		// Advance in list of Body options, looping back to first at end
		_selectedBody = _selectedBody + 1;

		if(_selectedBody > _lastBodyIndex)
		{
			_selectedBody = 0;
		}

		Body = _bodies.ElementAt(_selectedBody);
		UpdateTextures();
	}


	private void _on_previous_head_button_pressed()
	{
		// Return to previous Head option, going to last option if no previous exists
		_selectedHead = _selectedHead - 1;

		if(_selectedHead < 0)
		{
			_selectedHead = _lastHeadIndex;
		}

		Head = _heads.ElementAt(_selectedHead);
		UpdateTextures();
	}


	private void _on_previous_body_button_pressed()
	{
		// Return to previous Body option, going to last option if no previous exists
		_selectedBody = _selectedBody - 1;

		if(_selectedBody < 0)
		{
			_selectedBody = _lastBodyIndex;
		}

		Body = _bodies.ElementAt(_selectedBody);
		UpdateTextures();
	}

	private void UpdateTextures()
	{
		// Set Body and Head TextureRect Textures based on Body and Head properties
		string _bodyFileName = $"Body_{Body}.png";
		string _headFileName = $"Head_{Head}.png";

		_bodyTexture = GD.Load<Texture2D>($"res://content/Textures/sprites/{_bodyFileName}");
		_headTexture = GD.Load<Texture2D>($"res://content/Textures/sprites/{_headFileName}");

		_headTextureRect.Texture = _headTexture;
		_bodyTextureRect.Texture = _bodyTexture;

		EmitSignal(SignalName.OnTextureChanged, Head, Body);
	}
}
