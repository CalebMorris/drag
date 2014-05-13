using UnityEngine;
using System.Collections;

[System.Serializable]
public sealed class Boundary
{
	public float yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
	public Boundary boundary;
	public float maxDistance = 10.0f;
	public float maxVelocity = 10.0f;
	float xMin;

	void Start()
	{
		xMin = Camera.main.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(new Vector3(8f, 0f, 0f)) - new Vector3(Screen.width / 2, 0f, 0f)).x;
		Debug.Log(string.Format("xMin:{0}",xMin));
	}

	void Update()
	{
#region 3D
		if (rigidbody.position.x < xMin)
		{
			rigidbody.position = new Vector3(xMin, rigidbody.position.y, rigidbody.position.z);
			rigidbody.velocity = Vector3.zero;
			return;
		}
		if (rigidbody.position.y < boundary.yMin)
		{
			rigidbody.position = new Vector3(rigidbody.position.x, boundary.yMin, rigidbody.position.z);
			rigidbody.velocity = Vector3.zero;
			return;
		}
		else if (rigidbody.position.y > boundary.yMax)
		{
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
#endregion
	}
}
