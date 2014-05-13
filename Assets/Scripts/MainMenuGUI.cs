using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour
{
	void OnGUI()
	{
		var buttonWidth = 100;
		var buttonHeight = 50;
		
		var buttonX = ( Screen.width - buttonWidth ) / 2.0f;
		var buttonY = ( Screen.height - buttonHeight ) / 2.0f;

		// Draw a button control in the center of the screen.
		if ( GUI.Button(
			new Rect(buttonX, buttonY, buttonWidth, buttonHeight),
			"Play" ) )
		{
			// Print some text to the debug console
			Application.LoadLevel("Main");
		}
	}
}
