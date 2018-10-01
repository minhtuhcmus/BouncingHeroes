using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backCollider : MonoBehaviour {

	public float DameRate = 1.5f;
	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("lung va cham");
			MC_control.instance.lostHP (10*DameRate);
	}
}
