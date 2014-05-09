using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;

	void Start()
	{
		rigidbody.velocity = new Vector3(speed, 0f, 0f);
	}
}
