using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour {

	public SpriteRenderer hpBar;
	public float max_hp;
	private float hp;
	public  Vector2 sizeMax;
	// Use this for initialization
	void Start () {
		hp = max_hp;
		hpBar = GetComponent<SpriteRenderer>();
		sizeMax = hpBar.size;
		//hpBar.size= new Vector2(0, sizeMax.y);
	}
	

	
	public float lostHP(float dame)
	{
		Debug.Log("da vao hpBar");
		hp -= dame;
		
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
