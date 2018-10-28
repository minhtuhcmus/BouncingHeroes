using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D  other){
		
		if(other.gameObject.CompareTag("MC")){
			if(MC_control.instance.hasKey ){
				Destroy(this.gameObject);
				// Khoa goi ham chuyen map o day
				
			}
			
			
		}
	}
}
