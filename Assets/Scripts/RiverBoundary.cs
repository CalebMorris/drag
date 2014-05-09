using UnityEngine;
using System.Collections;

public class RiverBoundary : MonoBehaviour
{
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player")
		{
			other.rigidbody.velocity = -1 * other.rigidbody.velocity;
		}
	}
}
