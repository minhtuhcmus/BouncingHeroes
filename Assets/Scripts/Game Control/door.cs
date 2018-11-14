using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
	
	public static door instance;
	public bool isDestroyed;
	public BoxCollider2D myCollider;
	
	
	public bool outLock = false;
	public int hpDoor = 2 ;
	
	public int numKeyNeed = 1;
	
	
	void Start(){
		isDestroyed = false;
		myCollider = GetComponent<BoxCollider2D>();
		
	}

	void Awake(){
		if (instance == null)
			instance = this;
	}

	void Update(){
		
	}

	public void setIsTrigger(){
		myCollider.isTrigger = true;
		//GetComponent<Collider>();
		//Destroy(this.gameObject);
		//isDestroyed = true;
	}
	
	public void hitKey(){
		numKeyNeed -=1;
		if(numKeyNeed <= 0)
			setIsTrigger();
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
			if(numKeyNeed <= 0 ){
				Destroy(this.gameObject);
				isDestroyed = true;
                // Khoa goi ham chuyen map o day
                //CameraControl.instance.Transition();

            }
			
			
		}
	}
}
