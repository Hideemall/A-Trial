using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

	public static PlatformManager Instance = null;

	[SerializeField]
	GameObject kopia;

	void Awake()
	{
		if (Instance == null) 
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);
		
	}
	// Use this for initialization
	


	IEnumerator SpawnPlatform(Vector2 spawnPosition)
	{
		yield return new WaitForSeconds (6f);
		Instantiate (kopia, spawnPosition, kopia.transform.rotation);
	}

}
