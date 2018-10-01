using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyCollider : MonoBehaviour {

	public float DameRate = 1.0f;
	private void OnCollisionEnter2D(Collision2D other)
	{
			MC_control.instance.lostHP (10*DameRate);
	}
}
