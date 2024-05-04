using Godot;
using System;

public partial class Hp : Label
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Text = $"Health: {Game.PlayerHealth}";
	}
}
