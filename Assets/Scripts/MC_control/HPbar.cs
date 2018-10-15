using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour {

	public SpriteRenderer hpBar;
	public float max_hp;
	private float hp;
	public  Vector2 sizeMax;
	

	
	public float dameSaw =1;
	// Use this for initialization
	void Start () {
		hp = max_hp;
		hpBar = GetComponent<SpriteRenderer>();
		sizeMax = hpBar.size;
		//hpBar.size= new Vector2(0, sizeMax.y);
	}
	
	private float getDame(Collision2D other){
		
		if(other.collider.tag == "saw"){
			
			MC_control.instance.hurt();
			return dameSaw;
		}
			
		return 0f;
	}

	
	public float lostHP(Collision2D other, float DameRate)
	{
		float dame=getDame(other);
		
		
		hp -= dame*DameRate;
		
		if(hp < 0)
			hp =0;
		updateHPbar();
		return hp;
	}
	public void updateHPbar(){
		float  phantram = hp/max_hp;

		hpBar.size=  new Vector2(sizeMax.x*phantram, sizeMax.y);
		Debug.Log("mau````````` :"+hpBar.size.ToString("F2"));
	}
	
}
