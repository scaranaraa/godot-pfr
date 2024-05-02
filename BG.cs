using Godot;
using System;

public partial class BG : ParallaxBackground
{
	public int ScrollSpeed = -100;

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		ScrollOffset = new Vector2(ScrollOffset.X + ScrollSpeed * (float)delta, ScrollOffset.Y);
	}
}
