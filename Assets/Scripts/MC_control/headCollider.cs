using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headCollider : MonoBehaviour {

	
	public float DameRate = 1.0f;
	// Use this for initialization
	private void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log("cham du" );
		if(MC_control.instance.startBlinking)
			return;
		MC_control.instance.lostHP (other,DameRate);
		//Debug.Log("dau" );
	}
}
