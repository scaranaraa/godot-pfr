using Godot;
using System;

public partial class Gold : Label
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Text = $"Gold: {Game.PlayerGold}";
	}
}
