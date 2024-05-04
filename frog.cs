using Godot;
using System;

public partial class frog : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public Boolean chase = false;
	public Node2D player;
	public override void _Ready()
	{
	}
public const float Speed = 100.0f;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_player_detection_body_entered(Node2D body){

		if(body.Name == "Player"){
			chase = true;
		}
	}

	public override void _PhysicsProcess(double delta)
	{

		Vector2 velocity = Velocity;
		player = GetNode<Node2D>("../../Player/Player");
		Vector2 direction = (player.Position - this.Position).Normalized();
		if(chase == true)
		{			
			if(GetNode<AnimatedSprite2D>("AnimatedSprite2D").Animation != "Death")
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Jump");
			velocity.X = direction.X * Speed;
		}
		else{
			if(GetNode<AnimatedSprite2D>("AnimatedSprite2D").Animation != "Death")
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Idle");
			velocity.X = Mathf.MoveToward(velocity.X, 0, Speed);
		}
		if(direction.X > 0){
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
		}
		else{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
		}
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;
	
		Velocity = velocity;
		MoveAndSlide();	
	}

	public void _on_player_detection_body_exited(Node2D body){
		if(body.Name == "Player"){
			chase = false;
		}
	}

	public void _on_player_death_body_entered(Node2D body){
		if(body.Name == "Player"){
			this.Death();
		}
	}

	public void _on_player_collision_body_entered(Node2D body){
		if(body.Name == "Player"){
			Game.PlayerHealth -= 20;
			this.Death();
		}
	}

	public async void Death(){
		Game.PlayerGold += 50;
		Utils.SaveGame();
		chase = false;
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Death");
		await ToSignal(GetNode<AnimatedSprite2D>("AnimatedSprite2D"), "animation_finished");
		this.QueueFree();
	}

}
