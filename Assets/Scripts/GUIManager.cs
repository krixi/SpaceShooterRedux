using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour 
{
	public Rect guiArea;

	public event System.Action DrawGUILayout;

	void OnGUI () {
		if (DrawGUILayout != null) {
			GUILayout.BeginArea (guiArea);
			DrawGUILayout ();
			GUILayout.EndArea ();
		}
	}
}
