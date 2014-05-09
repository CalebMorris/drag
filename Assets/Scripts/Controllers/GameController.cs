using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public Vector3 spawnValueOffsets;
	public int hazardCount;
	public float startWait;
	public float waveWait;
	public float spawnWaitLowerLimit;
	public float spawnWaitUpperLimit;

	public GUIText scoreText;
	public GUIText gameOverText;
	public GUIText gameOverScoreText;
	public GUIText restartText;
	int score;

	bool isGameOver;

	public void GameOver()
	{
		isGameOver = true;
		scoreText.text = "";
		gameOverText.text = "Game Over";
		gameOverScoreText.text = string.Format("Score: {0}", this.score);
		restartText.text = "Tap to Restart";
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void AddScore(int newScore)
	{
		if (isGameOver)
			return;
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
		gameOverScoreText.text = "";
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

		while (true)
		{
			for (int i = 0; i < hazardCount; ++i)
			{
				Vector3 spawnPosition = new Vector3(spawnValueOffsets.x + spawnValues.x,
				                                    spawnValueOffsets.y + Random.Range(-spawnValues.y, spawnValues.y),
				                                    spawnValueOffsets.z + spawnValues.z);

				Quaternion rotation = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));

				Instantiate(hazard, spawnPosition, Quaternion.identity);

				yield return new WaitForSeconds(Random.Range(spawnWaitLowerLimit, spawnWaitUpperLimit));
			}

			yield return new WaitForSeconds(waveWait);
		}
	}
}
