using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public ScoreBoard board;

	public int value = 1;

	void Start() {
		if (board == null) {
			GameObject obj = GameObject.FindGameObjectWithTag("ScoreBoard");
			board = obj.GetComponent<ScoreBoard>();
		}
		if (board == null) {
			throw new System.InvalidOperationException("Cannot find ScoreBoard!");
		}
	}

	void OnDestroy() {
		if (board != null) {
			board.Score += value;
		}
	}
}
