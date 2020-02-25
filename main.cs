using Godot;
using System;

public class main : Node2D
{
	// Don't forget to rebuild the project so the editor knows about the new export variable.
	[Export]
	public PackedScene Mob;
	
	private int _score;

	// We use 'System.Random' as an alternative to GDScript's random methods.
	private Random _random = new Random();
	
	public override void _Ready()
	{
		
	}

	private float RandRange(float min, float max)
	{
		return (float)_random.NextDouble() * (max - min) + min;
	}
		
	public void NewGame()
	{
		_score = 0;
	
	
		var player = GetNode<Dragon>("Player");
		var startPosition = GetNode<Position2D>("StartPosition");
		player.Start(startPosition.Position);
		var hud = GetNode<HUD>("HUD");
		hud.UpdateScore(_score);
		hud.ShowMessage("Get Ready!");
	
		GetNode<Timer>("StartTimer").Start();
		
		
	}
	
	
	private void game_over()
		{
			GetNode<Timer>("MobTimer").Stop();
			GetNode<Timer>("ScoreTimer").Stop();
			GetNode<HUD>("HUD").ShowGameOver();
		}
	private void _on_MobTimer_timeout()
	{
			// Choose a random location on Path2D.
	var mobSpawnLocation = GetNode<PathFollow2D>("mobPath/mobspawnlocation");
	mobSpawnLocation.SetOffset(_random.Next());

	// Create a Mob instance and add it to the scene.
	var mobInstance = (RigidBody2D)Mob.Instance();
	AddChild(mobInstance);

	// Set the mob's direction perpendicular to the path direction.
	float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;

	// Set the mob's position to a random location.
	mobInstance.Position = mobSpawnLocation.Position;

	// Add some randomness to the direction.
	direction += RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
	mobInstance.Rotation = direction;

	// Choose the velocity.
	mobInstance.SetLinearVelocity(new Vector2(RandRange(150f, 250f), 0).Rotated(direction));
	
	}
	
	private void _on_ScoreTimer_timeout()
	{
	   _score++;
	
		GetNode<HUD>("HUD").UpdateScore(_score);
	}


	private void _on_StrartTimer_timeout()
	{
		GetNode<Timer>("MobTimer").Start();
		GetNode<Timer>("ScoreTimer").Start();
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

}


