using UnityEngine;
using System.Collections;

public class Grav : MonoBehaviour
{
	public float accel = -9.8f;

	void Start ()
	{
		Physics.gravity = new Vector3(accel, 0f, 0f);
	}
}
