using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float lifeTime;
	private float dieTime;

	void OnEnable () 
	{
		dieTime = Time.time + lifeTime;
	}

	void Update()
	{
		if ( Time.time >= dieTime )
			//Destroy ( gameObject );
			gameObject.SetActive(false);
	}
}
