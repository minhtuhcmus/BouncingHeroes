using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D  other){
		//Destroy(this.gameObject);
		//Debug.Log("KEYyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy");
		if(other.gameObject.CompareTag("MC")){
			Destroy(this.gameObject);
			MC_control.instance.hasKey = true;
			door.instance.setIsTrigger();
			//this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			
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
