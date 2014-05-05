using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameController gameController;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (!gameControllerObject.Equals(null))
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		if (other.tag == "Player")
		{
			gameController.GameOver();
			Destroy(GameObject.FindGameObjectWithTag("Tether"));
			foreach(GameObject gameObject in GameObject.FindGameObjectsWithTag("Rope"))
			{
				Destroy(gameObject);
			}
		}
		Destroy(other.gameObject);
	}
}
