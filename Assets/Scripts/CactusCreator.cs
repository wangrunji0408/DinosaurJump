using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusCreator : MonoBehaviour
{
	public GameObject Scene;
	public Sprite[] CactusSprites;
	public GameObject CactusPrefab;
	public Vector2 EmitPos;
	public float waitTime;

	private Vector2 offset = new Vector2(0.3f, 0);

	GameObject CreateCactusAt(Vector2 pos)
	{
		var cactus = Instantiate(CactusPrefab, Scene.transform);
		cactus.transform.position = pos;
		cactus.GetComponent<SpriteRenderer>().sprite = CactusSprites[Random.Range(0, CactusSprites.Length)];
		return cactus;
	}

	void Emit(int size)
	{
		for (int i = 0; i < size; ++i)
			CreateCactusAt(EmitPos + i * offset);
	}

	private void Start()
	{
		StartCoroutine("CreateCactus");
	}

	public void Stop()
	{
		StopCoroutine("CreateCactus");
	}

	IEnumerator CreateCactus()
	{
		while (true)
		{
			Emit(Random.Range(1, 4));
			yield return new WaitForSeconds(Random.Range(waitTime * 0.8f, waitTime * 1.2f));
		}
	}
}
