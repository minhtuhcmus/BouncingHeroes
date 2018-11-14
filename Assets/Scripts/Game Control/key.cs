using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {
	
	private bool check = true;

	void OnTriggerExit2D(Collider2D  other){
		//Destroy(this.gameObject);
		//Debug.Log("KEYyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy");
		if(other.gameObject.CompareTag("MC") && check){
			check = false;
			Destroy(this.gameObject);
			//MC_control.instance.hasKey = true;
			door.instance.hitKey();
			//this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			
		}
	}
	

}
