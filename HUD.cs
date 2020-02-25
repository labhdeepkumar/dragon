using Godot;
using System;

public class HUD : CanvasLayer
{
	[Signal]
	public delegate void StartGame();
	
	public override void _Ready()
	{
		
	}
	public void ShowMessage(string text)
	{
	var messageLabel = GetNode<Label>("MessageLabel");
	messageLabel.Text = text;
	messageLabel.Show();

	GetNode<Timer>("MessageTimer").Start();
	}
	async public void ShowGameOver()
	{
	ShowMessage("Game Over");

	var messageTimer = GetNode<Timer>("MessageTimer");
	await ToSignal(messageTimer, "timeout");

	var messageLabel = GetNode<Label>("MessageLabel");
	messageLabel.Text = "Dodge the\nCreeps!";
	messageLabel.Show();

	GetNode<Button>("StartButton").Show();
	}
	public void UpdateScore(int score)
	{
	GetNode<Label>("ScoreLabel").Text = score.ToString();
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	
	private void OnStartButtonPressed()
	{
		GetNode<Button>("StartButton").Hide();
		EmitSignal("StartGame");
		
	}
	private void _on_MessageTimer_timeout()
	{
		GetNode<Label>("MessageLabel").Hide();
	}
}












