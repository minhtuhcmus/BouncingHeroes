using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backCollider : MonoBehaviour {

	public float DameRate = 4.0f;
	private void OnCollisionEnter2D(Collision2D other)
	{
		if(MC_control.instance.startBlinking)
			return;
		MC_control.instance.lostHP (other,DameRate);
	}
}
