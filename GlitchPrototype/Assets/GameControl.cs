using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance; 
	public GameObject gameOverText;
	public bool gameOver = false; 
	public float scrollSpeed =  -100f; 
	public int score; 
	public Text ScoreText;

	AudioSource PlayerAs;
	public AudioClip playerGem; 
	// Use this for initialization
	void Awake () {

		PlayerAs = GetComponent<AudioSource> ();
		if (instance == null) {
			
			instance = this; 
		} 

		else if(instance != this) 
		{
			Destroy (gameObject);
		}

	}

	void Start(){

		if (gameOver != true) {

			InvokeRepeating("playerScore", 1.0f, 0.20f);


		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
			CancelInvoke();
		}

		if (gameOver == true && Input.GetKey("space")) {

			SceneManager.LoadScene("Main");
		
//			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} 

	

	}

	public void playerScore(){
		PlayerAs.clip = playerGem;
		PlayerAs.volume = 0.25f;
//		PlayerAs.pitch = Random.Range(1f, 2f);
		PlayerAs.Play ();
		score = (score + 1);
		ScoreText.text = "Score : " + score.ToString ();
	}
	public void playerDoubleScore(){
		score = score  * 2;
		ScoreText.text = "Score : " + score.ToString ();
	}
	public void PlayerDied()
	{
		gameOverText.SetActive (true);
		gameOver = true;
	}
}
