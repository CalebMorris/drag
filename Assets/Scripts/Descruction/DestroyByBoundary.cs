using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
	public GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (!gameControllerObject.Equals(null))
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
	}

	void OnTriggerExit(Collider other)
	{
		gameController.AddScore(1);
		Destroy(other.gameObject);
	}
}
