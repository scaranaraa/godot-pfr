using Godot;
using System;

public partial class main : Node2D
{
	public override void _Ready()
	{
		//Utils.SaveGame();
		Utils.LoadGame();
	}

	public override void _Process(double delta)
	{
	}
	public void _on_quit_pressed(){
		GetTree().Quit();
	}

	public void _on_play_pressed(){
		GetTree().ChangeSceneToFile("res://world.tscn");
	}	
}

