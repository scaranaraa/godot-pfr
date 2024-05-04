using Godot;
using System;



public partial class Collectables : Node2D
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
	
	public void _on_timer_timeout(){
		Node2D cherry = ResourceLoader.Load<PackedScene>("res://Collectables/Cherry.tscn").Instantiate<Node2D>(); 
		RandomNumberGenerator rng = new();
		int xCord = rng.RandiRange(20,1500);
		cherry.Position = new Vector2(xCord,296);
		AddChild(cherry);
	}

}
