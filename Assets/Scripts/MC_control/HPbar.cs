using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour {

	public SpriteRenderer hpBar;
	public float max_hp;
	private float hp;
	public  Vector2 sizeMax;
	

	
	
	// dame of Enemy
	// tag object Eneme for Calculate HP
	public float dameSaw =1;
	public float dameElectric =1;
	public float dameGun =1;
	public float dameRocket =1;
	public float dameNormalEnemy = 1;
	
	// Use this for initialization
	void Start () {
		hp = max_hp;
		hpBar = GetComponent<SpriteRenderer>();
		sizeMax = hpBar.size;
		
	}
	
	private float getDame(Collision2D other){
		
		if(other.collider.tag == "saw"){
			// sau nay lấy từ mc.acset
			MC_control.instance.hurt();
			return dameSaw;
		}
		if(other.collider.tag == "Electric"){
			MC_control.instance.hurt();
			return dameElectric;
		}
		if(other.collider.tag == "gun"){
			MC_control.instance.hurt();
			return dameGun;
		}
		if(other.collider.tag == "rocket"){
			MC_control.instance.hurt();
			return dameRocket;
		}
		if(other.collider.tag == "Enemy"){
			MC_control.instance.hurt();
			return dameNormalEnemy;
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
		//Debug.Log("mau````````` :"+hpBar.size.ToString("F2"));
	}
	
}
