﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

using UnityEngine.SceneManagement;

public class MC_control : MonoBehaviour {

	public GameObject GameoverBtn;
	public GameObject hpBar;
	
	public Collider2D headCollider;
	public Collider2D bodyCollider;
	public Collider2D backCollider;
	
	public float headBouncing;
	public float bodyBouncing;
	public float backBouncing;
	
	// Use this for initialization
	public static MC_control instance;
	//public scriptA  hpBar;
	private Rigidbody2D rb2d;
	
	//private var temp;
	
	
	
	public float spriteBlinkingTimer = 0.0f;
	public float spriteBlinkingMiniDuration = 0.1f;
	public float spriteBlinkingTotalTimer = 0.0f;
	public float spriteBlinkingTotalDuration = 1.0f;
	public bool startBlinking = false;
	//public bool test =false;
	
	private Transform character;

	void Start () {
		resetBoucing(headBouncing,bodyBouncing,backBouncing);
		
		
		rb2d = GetComponent<Rigidbody2D>();
		character = GetComponent<Transform>();
		GameoverBtn.SetActive (false);
	}
	
	// Update is called once per frame
	void Update()
    { 
         if(startBlinking == true)
         { 
             SpriteBlinkingEffect();
         }
		 
			
    }

	void Awake()
	{
		
		if (instance == null)
			instance = this;
		
	}
	
	public void lostHP(Collision2D other, float DameRate)
	{
		
		//Debug.Log("vao MC control");
		
		if(hpBar.GetComponent<HPbar>().lostHP(other,DameRate) == 0)
			gameOver();
		
	}
	public void hurt(){
		
		Debug.Log("hurt");
		float angle;
		Vector3 axis = Vector3.zero;
		axis = character.rotation.eulerAngles;
		angle = Mathf.Abs( axis.x) +Mathf.Abs( axis.y )+ axis.z;
		
		//Debug.Log("goc quay = "+ angle+"  "+ axis);
		angle *= Mathf.Deg2Rad;
		rb2d.velocity = new Vector2(Mathf.Sin(angle) *2, Mathf.Cos(angle) * 2);
		//rb2d.velocity = axis;
		startBlinking = true;
		
		
	}
	public void gameOver(){
		
		
		rb2d.gravityScale = 1;
		InputControl.gameOver=true;
		
		GameoverBtn.SetActive(true);
		
	}
	public void tryAgain(){
		Debug.Log(" tryAgain");
		InputControl.gameOver=false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	private void resetBoucing(float a, float b, float c){
			headCollider.sharedMaterial.bounciness = a;
			bodyCollider.sharedMaterial.bounciness = b;
			backCollider.sharedMaterial.bounciness = c;
	}
	private void SpriteBlinkingEffect()
    {
		
        spriteBlinkingTotalTimer += Time.deltaTime;
        if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
			//Debug.Log(" het nhap nhay");
              startBlinking = false;
             spriteBlinkingTotalTimer = 0.0f;
             this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   // according to 
                      //your sprite
			resetBoucing(headBouncing,bodyBouncing,backBouncing);
					  
					  
			
             return;
        }
     
		spriteBlinkingTimer += Time.deltaTime;
		if(spriteBlinkingTimer >= spriteBlinkingMiniDuration)
		{
			//Debug.Log("nhap nhay");
			spriteBlinkingTimer = 0.0f;
			if (this.gameObject.GetComponent<SpriteRenderer> ().enabled == true) {
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;  //make changes
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   //make changes
			}
		}
	}
}