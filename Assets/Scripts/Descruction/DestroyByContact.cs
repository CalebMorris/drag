using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		if (other.tag == "Player")
		{
			Destroy(GameObject.FindGameObjectWithTag("Tether"));
			foreach(GameObject gameObject in GameObject.FindGameObjectsWithTag("Rope"))
			{
				Destroy(gameObject);
			}
		}
		Destroy(other.gameObject);
	}
}
