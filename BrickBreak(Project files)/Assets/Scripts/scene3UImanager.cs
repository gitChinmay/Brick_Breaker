using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class scene3UImanager : MonoBehaviour {

	public Text hitNum;
	public Text scoreText;
	public GameObject ball;
	Ball refBall;

	public Animator shipControlAnim;
	public Animator gameOverPanel;
	// Use this for initialization
	void Awake(){
		refBall = ball.GetComponent<Ball> ();
	}
	void Start () {
		shipControlAnim.SetBool ("levelON", true);
		shipControlAnim.SetBool ("levelOver",false);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + refBall.score;
	}
	
	public void updateHitCount(){
		hitNum.text = refBall.hitCount.ToString ();
	}

	public void gameOver(){
		shipControlAnim.SetBool ("levelOver",true);
		shipControlAnim.SetBool ("levelON",false);
		gameOverPanel.SetBool ("gameOver", true);
	}

	public void goHome(){
		gameOverPanel.SetBool ("gameStart", true);
		gameOverPanel.SetBool ("gameOver", false);
		Application.LoadLevel("scene01");
	}

	public void restartLevel(){
		gameOverPanel.SetBool ("gameStart", true);
		gameOverPanel.SetBool ("gameOver", false);
		Application.LoadLevel (Application.loadedLevel);
	}
}
