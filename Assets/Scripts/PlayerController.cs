using UnityEngine;
using System.Collections;

[System.Serializable]
public sealed class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
	void Update()
	{
		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch(0);
			
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
				// If the finger is on the screen, move the object smoothly to the touch position
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
				Debug.Log(touchPosition.ToString());
				transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime);
			}
		}
	}
}
