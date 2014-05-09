using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;

	void Start()
	{
		rigidbody2D.velocity = new Vector2(speed, 0);
	}
}
