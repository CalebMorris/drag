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

	public GUIText scoreText;
	public GUIText gameOverText;
	public GUIText restartText;
	public int score;

	bool isGameOver;

	public void GameOver()
	{
		isGameOver = true;
		gameOverText.text = "Game Over";
		restartText.text = "Tap to Restart";
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void AddScore(int newScore)
	{
		score += newScore;
		UpdateScore();
	}

	void UpdateScore()
	{
		scoreText.text = string.Format("Score: {0}", score);
	}

	void Start()
	{
		gameOverText.text = "";
		restartText.text = "";
		AddScore(0);
		StartCoroutine(SpawnWaves());
	}

	void Update()
	{
		if (isGameOver && Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				Restart();
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);

		while (!isGameOver)
		{
			for (int i = 0; i < hazardCount; ++i)
			{
				Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);

				// Adjust the forward vector to point toward -x
				Quaternion spawnRotation = Quaternion.identity * Quaternion.Euler(0.0f, 90.0f, 0.0f);

				Instantiate(hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds(Random.Range(spawnWaitLowerLimit, spawnWaitUpperLimit));

				if (isGameOver)
					break;
			}

			yield return new WaitForSeconds(waveWait);
		}
	}
}
