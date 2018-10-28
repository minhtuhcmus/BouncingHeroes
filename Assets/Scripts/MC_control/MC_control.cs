using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

using UnityEngine.SceneManagement;

public class MC_control : MonoBehaviour {

	public GameObject GameoverBtn;
	public GameObject hpBar;
	public GameObject arrow;
	public Collider2D headCollider;

	public bool hasKey = false;
	
	public float headBouncing;
	
	


	
	public Collider2D headCollider;

	public float headBouncing;

	
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
		//resetBoucing(headBouncing);
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
		
		//Debug.Log("hurt");
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
		//Debug.Log(" tryAgain");
		InputControl.gameOver=false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


	private void resetBoucing(float headBouncingNum){
			headCollider.sharedMaterial.bounciness = headBouncingNum;
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

	public void ArrowScale(float fDistance){
		arrow.GetComponent<Arrow>().Scale(fDistance);
	}

	public void ArrowScaleBack(){
		arrow.GetComponent<Arrow>().ScaleBack();
	}
}
