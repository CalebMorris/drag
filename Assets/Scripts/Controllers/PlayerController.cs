using UnityEngine;
using System.Collections;

[System.Serializable]
public sealed class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
	public Boundary boundary;
	public float maxDistance = 10.0f;
	public float maxVelocity = 10.0f;

	void Update()
	{
		if (rigidbody.position.x < boundary.xMin)
		{
			Debug.Log("xMin");
			rigidbody.position = new Vector3(boundary.xMin, rigidbody.position.y, rigidbody.position.z);
			rigidbody.velocity = Vector3.zero;
			return;
		}
		else if (rigidbody.position.x > boundary.xMax)
		{
			Debug.Log("xMax");
			rigidbody.position = new Vector3(boundary.xMax, rigidbody.position.y, rigidbody.position.z);
			rigidbody.velocity = Vector3.zero;
			return;
		}
		if (rigidbody.position.y < boundary.yMin)
		{
			Debug.Log("yMin");
			rigidbody.position = new Vector3(rigidbody.position.x, boundary.yMin, rigidbody.position.z);
			rigidbody.velocity = Vector3.zero;
			return;
		}
		else if (rigidbody.position.y > boundary.yMax)
		{
			Debug.Log("yMax");
			rigidbody.position = new Vector3(rigidbody.position.x, boundary.yMax, rigidbody.position.z);
			rigidbody.velocity = Vector3.zero;
			return;
		}

		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch(0);
			
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
				// If the finger is on the screen, move the object smoothly to the touch position
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
				float dist = Vector3.Distance(touchPosition, rigidbody.position);
				Debug.Log(touchPosition.ToString());
				rigidbody.velocity = (maxVelocity * (1.0f - dist / maxDistance)) * (touchPosition - transform.position).normalized;
				Debug.Log(string.Format("velocity:{0}", rigidbody.velocity.ToString()));
				////transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime);
			}
		}
	}
}
