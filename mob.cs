using Godot;
using System;

public class mob : RigidBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	private Random _random = new Random();
	[Export]
	public int MinSpeed = 150; // Minimum speed range.

	[Export]
	public int MaxSpeed = 250; // Maximum speed range.

	private String[] _mobTypes = {"walk", "swim", "fly"};
	
	public override void _Ready()
	{
		GetNode<AnimatedSprite>("AnimatedSprite").Animation = _mobTypes[_random.Next(0, _mobTypes.Length)];
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	public void OnVisibilityScreenExited()
	{
		QueueFree();
	}
}



