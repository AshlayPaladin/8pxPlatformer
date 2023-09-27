using Godot;
using System;

public partial class BgmAudioStreamPlayer : Node
{
	// Private Members
	private string bgmPath;
	
	// Private Members : Nodes
	private AudioStreamPlayer bgmPlayer;
	private AudioStream bgm;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bgmPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		bgmPath = "";
	}
	
	public void Play(string path)
	{
		if(path != "" && bgmPath != path)
		{
			bgmPath = path;
			bgm = (AudioStream)ResourceLoader.Load(bgmPath);
			bgmPlayer.Stream = bgm;
			bgmPlayer.Play();
		}
	}
}
