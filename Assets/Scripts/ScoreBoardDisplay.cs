using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ScoreBoard))]
public class ScoreBoardDisplay : MonoBehaviour {

	// The digits to use
	public Sprite[] digitTextures;

	// The sprites to display this score 
	public SpriteRenderer[] digits;

	// The last number displayed
	private int lastDisplay = -1;

	// The reference to the current score. 
	private ScoreBoard scoreBoard;


	void Start()
	{
		if (digits.Length == 0)
		{
			throw new System.InvalidOperationException("You must have at least one digit");
		}
		if (digitTextures.Length != 10) 
		{
			throw new System.InvalidOperationException ("You must have 10 digits set");
		}
		scoreBoard = GetComponent<ScoreBoard>();
	}


	void Update()
	{
		// Update the display only if different.
		if (lastDisplay != scoreBoard.Score)
		{
			lastDisplay = scoreBoard.Score;

			// Set each digit individually:
			// Convert the number to a string
			string numStr = lastDisplay.ToString();
			if (numStr.Length > digits.Length)
			{
				throw new System.IndexOutOfRangeException ("Score is too big");
			}

			//  
			int lengthDiff = digits.Length - numStr.Length;

			// Set the first digits to 0
			for ( int i=0; i<lengthDiff; i++ )
			{
				digits[i].sprite = digitTextures[0];
			}

			// Set remaining to whatever that digit should be
			for ( int i=0; i < numStr.Length; i++ )
			{
				int num = int.Parse( numStr[ i ].ToString() );
				int idx = i + lengthDiff;
				digits[ idx ].sprite = digitTextures[ num ];
			}

		}
	}
}
