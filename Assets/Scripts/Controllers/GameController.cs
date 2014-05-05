using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;

	void Start()
	{
		SpawnWaves();
	}

	void SpawnWaves()
	{
		Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);

		// Adjust the forward vector to point toward -x
		Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(0.0f, 90.0f, 0.0f);

		Instantiate(hazard, spawnPosition, spawnRotation);
	}
}
