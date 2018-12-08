using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
	
	public static door instance;
	public bool isDestroyed;
	public BoxCollider2D myCollider;
	public GameObject  key;
	
	public bool outLock = false;
	public int hpDoor = 2 ;
	
	public int numKeyNeed = 10;
	//cac vi tri x y nay phai dua tren vi tri cac key spaw ra khi chay. keo cac key spaw toi cac vi tri de biet dia diem x, y
	public float xMin;
	public float xmax;
	public float yMin;
	public float yMax;
	
	void Start(){
		isDestroyed = false;
		myCollider = GetComponent<BoxCollider2D>();
		if(numKeyNeed>0 && !outLock)
			spawnKey(numKeyNeed);
	}

	void Awake(){
		if (instance == null)
			instance = this;
	}
	
	public void spawnKey(int numOfkey){
		for(int i=0;i < numOfkey ; i++){
			Vector3 positionSpaw = new Vector3(Random.Range(xMin, xmax), Random.Range(yMin, yMax),0f);
			if(checkKeyRandom.instance.checkKey(positionSpaw))
			{
				Instantiate(key , positionSpaw,Quaternion.identity);
			}
			else
				i--;
		}
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
