﻿using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

	public GUIManager guiManager;

	public int _score = 0;
	public int Score {
		get { return _score; }
		set { _score = value; }
	}

	void Start () {
		guiManager.DrawGUILayout += DrawScoreGUI;
	}


	void DrawScoreGUI() {
		GUILayout.Label (string.Format("Score: {0}", Score));
	}
}
