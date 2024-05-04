using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	
	public int Health = 100;
	public AnimationPlayer Anim;
	public AnimatedSprite2D AnimSprite;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready() {
		Anim = GetNode<AnimationPlayer>("AnimationPlayer");
		AnimSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

	}

	public override void _PhysicsProcess(double delta)
	{
		
		Vector2 velocity = Velocity;
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor()){
			velocity.Y = JumpVelocity;
			Anim.Play("Jump");
		}
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if(direction.X == 1){
			AnimSprite.FlipH = false;
		}
		if(direction.X == -1){
			AnimSprite.FlipH = true;
		}
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			if(velocity.Y == 0){
				Anim.Play("Run");
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			if(velocity.Y == 0){
				Anim.Play("Idle");
			}
		}
		if(velocity.Y > 0){
			Anim.Play("Fall");
		}
		Velocity = velocity;
		MoveAndSlide();

		if(Game.PlayerHealth <= 0){
			Game.PlayerHealth = 100;
			Game.PlayerGold = 0;
			Utils.SaveGame();
			QueueFree();
			GetTree().ChangeSceneToFile("res://main.tscn");
		}

	}
}
