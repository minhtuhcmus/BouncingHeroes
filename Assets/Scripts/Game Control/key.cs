using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D  other){
		
		//Debug.Log("KEYyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy");
		if(other.gameObject.CompareTag("MC")){
			MC_control.instance.hasKey = true;
			//this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy(this.gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag == "MC"){
			MC_control.instance.hasKey = true;
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
		
	}
}
