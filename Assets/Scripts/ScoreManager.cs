using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public Text ScoreText;

	private float _score;
	public float Score
	{
		get { return _score; }
		set
		{
			_score = value;
			if(ScoreText)
				ScoreText.text = "Score: " + Score;
		}
	}

	IEnumerator AddScoreByTime(float amount, float time)
	{
		while (true)
		{
			Score += amount;
			yield return new WaitForSeconds(time);
		}
	}

	private Coroutine cor;

	public void StartScoring()
	{
		Score = 0;
		cor = StartCoroutine(AddScoreByTime(1, 0.1f));
	}

	public void StopScoring()
	{
		StopCoroutine(cor);
	}
}
