﻿using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	
	public float levelTime = 60f;

	public string playerTag = "Player";

	public string nextLevel = "";

	public float delayBeforeNextLevel = 6f;

	public GUIManager guiManager;

	bool levelComplete = false;

	protected Player player;

	float startTime = 0f;

	public float TimeElapsed {
		get {
			return Time.time - startTime;
		}
	}

	public float TimeRemaining {
		get {
			return levelTime - TimeElapsed;
		}
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		startTime = Time.time;
		guiManager.DrawGUILayout += DrawLevelGUI;

		// Get the player.
		GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
		player = playerObj.GetComponent<Player>();
		if (player == null) {
			throw new System.InvalidOperationException ("Cannot find object with tag: " + playerTag);
		}
	}

	// Update is called once per frame.
	void Update ()
	{
		// Monitor the player. If it becomes null, they died, so stop the game.
		if (player == null) {
			Time.timeScale = 0f;
		} else {
			// Check if there is any time remaining.
			if (TimeRemaining <= 0f) {
				// Time is up - player is still alive. End level.
				Time.timeScale = 0f;
				levelComplete = true;
			}
		}
	}

	void OnGUI ()
	{
		if (player != null) 
		{
			if (levelComplete) 
			{
				if (GUI.Button (new Rect (Screen.width/2f - 100f/2f, Screen.height/2f, 100f, 50f), "Next Level") ) 
				{
					Application.LoadLevel (nextLevel);
				}
			} 
		} 
		else 
		{
			if (GUI.Button (new Rect (Screen.width/2f - 100f/2f, Screen.height/2f, 100f, 50f), "Restart") ) 
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	void DrawLevelGUI() 
	{
		if (player != null) 
		{
			if (levelComplete) 
			{
				GUILayout.Label ("Level Complete!");
			} 
			else 
			{
				GUILayout.Label (string.Format ("Time left: {0:F1}", TimeRemaining));
			}
		} 
		else 
		{
			GUILayout.Label (string.Format ("You Died!\nTime left: {0:F1}", TimeRemaining));
		}
	}
}
