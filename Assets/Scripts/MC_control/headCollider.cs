using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headCollider : MonoBehaviour {

	
	public float DameRate = 0.0f;
	// Use this for initialization
	private void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log("cham du" );
		MC_control.instance.lostHP (10*DameRate);
		//Debug.Log("dau" );
	}
}
