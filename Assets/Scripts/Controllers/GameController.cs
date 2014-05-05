using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float startWait;
	public float waveWait;
	public float spawnWaitLowerLimit;
	public float spawnWaitUpperLimit;

	void Start()
	{
		StartCoroutine(SpawnWaves());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);

		while (true)
		{
			for (int i = 0; i < hazardCount; ++i)
			{
				Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);

				// Adjust the forward vector to point toward -x
				Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(0.0f, 90.0f, 0.0f);

				Instantiate(hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds(Random.Range(spawnWaitLowerLimit, spawnWaitUpperLimit));
			}

			yield return new WaitForSeconds(waveWait);
		}
	}
}
