using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
	
	public static door instance;
	public bool isDestroyed;
	
	public bool outLock = false;
	public int hpDoor = 2 ;
	
	void Start(){
		isDestroyed = false;
		
		
	}

	void Awake(){
		if (instance == null)
			instance = this;
	}

	void Update(){
		
	}

	public void setIsTrigger(){
		GetComponent<Collider>().isTrigger = true;
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(outLock){
			hpDoor -=1;
			if(hpDoor <= 0){
				Destroy(this.gameObject);
				isDestroyed = true;				
			}

		}
	}
	
	void OnTriggerEnter2D(Collider2D  other){
		
		if(other.gameObject.CompareTag("MC")){
			if(MC_control.instance.hasKey ){
				Destroy(this.gameObject);
				isDestroyed = true;
                // Khoa goi ham chuyen map o day
                //CameraControl.instance.Transition();

            }
			
			
		}
	}
}
