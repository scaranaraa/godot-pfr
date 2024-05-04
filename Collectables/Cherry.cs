using Godot;
using System;

public partial class Cherry : Area2D
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public void _on_body_entered(Node2D body)
	{
		if(body.Name == "Player"){
			Game.PlayerGold += 50;
			Tween TweenPos = GetTree().CreateTween();
			Tween TweenMod = GetTree().CreateTween();

			TweenPos.TweenProperty(this, "position", Position - new Vector2(0, 35), 0.35f);
			TweenMod.TweenProperty(this, "modulate:a", 0, 0.25f);

			TweenPos.TweenCallback(Callable.From(QueueFree));
		}
	}
}

