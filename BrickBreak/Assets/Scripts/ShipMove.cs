using UnityEngine;
using System.Collections;

public class ShipMove : MonoBehaviour {
	public float xSpeed=10.0f;
	public Camera cam;
	public GameObject wall;
	public GameObject upperWall;
	public GameObject lowerWall;


	bool moveRight=false;
	bool moveLeft=false;

	float direction=0.0f;

	float maxWidth;

	// Use this for initialization
	void Start () {
		//finding world co-ordinates
		Vector3 upperPoint = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperPoint);
		maxWidth = targetWidth.x-(transform.localScale.x/2);

		//setting side walls
		wall.transform.localScale = new Vector3 (wall.transform.localScale.x, targetWidth.y*2, wall.transform.localScale.z);
		wall.transform.position = new Vector3 (-targetWidth.x-(wall.transform.localScale.x/2),wall.transform.position.y,wall.transform.position.z);
		Instantiate (wall, new Vector3 (targetWidth.x + (wall.transform.localScale.x / 2), wall.transform.position.y, wall.transform.position.z), Quaternion.identity);

		upperWall.transform.localScale = new Vector3 (upperWall.transform.localScale.x, targetWidth.x * 2, upperWall.transform.localScale.z);
		upperWall.transform.position = new Vector3 (upperWall.transform.position.x, targetWidth.y + (upperWall.transform.localScale.x / 2), upperWall.transform.position.z);

		lowerWall.transform.localScale = new Vector3 (lowerWall.transform.localScale.x, targetWidth.x * 2, lowerWall.transform.localScale.z);
		lowerWall.transform.position = new Vector3 (lowerWall.transform.position.x,-targetWidth.y - (lowerWall.transform.localScale.x / 2), lowerWall.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		if (moveLeft) {
			direction -=0.03f;
		} else if (moveRight) {
			direction += 0.03f;
		}
		float xMove = Mathf.Clamp(direction,-1.0f,1.0f) * xSpeed * Time.deltaTime;
		float xPos = transform.position.x + xMove;
		Vector3 changedPos = new Vector3 (Mathf.Clamp (xPos, -maxWidth, maxWidth), transform.position.y, 0.0f);
		transform.position = changedPos;
	}

	public void setLeftBool(){
		moveLeft = true;
	}
	public void setRightBool(){
		moveRight = true;
	}
	public void resetLeftBool(){
		moveLeft = false;
		direction = 0.0f;
	}
	public void resetRightBool(){
		moveRight = false;
		direction = 0.0f;
	}
}
