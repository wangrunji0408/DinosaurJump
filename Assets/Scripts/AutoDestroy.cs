using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
