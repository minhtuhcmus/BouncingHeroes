using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

using UnityEngine.SceneManagement;

public class MC_control : MonoBehaviour {

	public GameObject GameoverBtn;
	public GameObject hpBar;
	
	// Use this for initialization
	public static MC_control instance;
	//public scriptA  hpBar;
	private Rigidbody2D rb2d;
	
	//private var temp;
	
	void Start () {
		 
		rb2d = GetComponent<Rigidbody2D>();
		
		GameoverBtn.SetActive (false);
	}
	
	// Update is called once per frame
	void Awake()
	{
		
		if (instance == null)
			instance = this;
		
	}
	
	public void lostHP(float dame)
	{
		Debug.Log("vao MC control");
		if(hpBar.GetComponent<HPbar>().lostHP(dame) == 0)
			gameOver();
		
	}
	public void gameOver(){
		
		
		rb2d.gravityScale = 1;
		InputControl.gameOver=true;
		
		GameoverBtn.SetActive(true);
		
	}
	public void tryAgain(){
		InputControl.gameOver=false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
