using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	//camera related vars
	public Camera cam;
	public float camShakeDuration=0.5f;
	float camShaketime=0.0f;

	Vector3 ballScreenPos;				//balls screen position
	Vector3 camOrgPos;					//camera original position

	bool isBallInPlay=false;			
	bool isCamShaking=false;

	public float maxBallSpeed=5f;		//max speed of ball

	BallPowerLook scriptRef;			//ref to the script

	public Material blueM;
	public Material greenM;
	public GameObject brickBlast;
	Rigidbody ballBody;

	public int hitCount=0;						//maintains continuous hit count
	float timeBetweenHits=0.0f;
	float holdTime=0.0f;

	public Animator comboAnim;

	public GameObject canvas;
	scene3UImanager scriptRefUI;

	float powerOnTime=0.0f;

	public int score=0;							//game score

	int brickCount=0;
	// Use this for initialization
	void Start () {
		ballScreenPos = cam.WorldToScreenPoint (transform.position);
		ballBody = GetComponent<Rigidbody> ();
		camOrgPos = cam.transform.position;
		scriptRef = GetComponent<BallPowerLook> ();
		scriptRefUI = canvas.GetComponent<scene3UImanager> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		camShaketime += Time.deltaTime;			//adding the time to check the duration of the shake
		timeBetweenHits += Time.deltaTime;		//adding time to check hits within time
		powerOnTime += Time.deltaTime;			//adding time to check power duration


		if (timeBetweenHits > 1f && ( hitCount == 1 || hitCount==2 )) {
			hitCount=0;
		}
		else if (timeBetweenHits > 1f && hitCount>2) {
			//do something
			scriptRefUI.updateHitCount();
			if(hitCount==3 || hitCount==4){
				if(scriptRef.isDefaultOn){
					scriptRef.icePowerLook();
					powerOnTime = 0.0f;
				}
			}
			else{
				if(scriptRef.isDefaultOn){
					scriptRef.firePowerLook();
					powerOnTime = 0.0f;
				}
			}
			score+=hitCount*10;
			comboAnim.SetBool("comboBool",true);

			holdTime=Time.realtimeSinceStartup;
		//	Time.timeScale=0.5f;
			hitCount=0;
		}
		//to let the combo animation get completed
		if ((Time.realtimeSinceStartup - holdTime) > 2) {
			comboAnim.SetBool("comboBool",false);
		}

		//power time up
		if (powerOnTime > 5.0f) {
			scriptRef.defaultOn();
		}

		//Debug.Log (timeBetweenHits);
		//initial touch and ball launch
		ballBody.velocity=	maxBallSpeed*(ballBody.velocity.normalized);
		if (!isBallInPlay && Input.GetMouseButtonDown (0) && Input.mousePosition.y> ballScreenPos.y) {
			transform.parent=null;
			Vector3 mouseTouchPos= cam.ScreenToWorldPoint(Input.mousePosition);
			mouseTouchPos.z=0;
			Vector3 forceDirection = mouseTouchPos-transform.position;
			forceDirection.Normalize();
			forceDirection.z=0;
			ballBody.AddForce(forceDirection*maxBallSpeed,ForceMode.Impulse);
			isBallInPlay=true;
		}

		//checking the conditions and camera shake for the duration
		if ((scriptRef.isFirePowerOn  || scriptRef.isIcePowerOn) && isCamShaking && camShaketime<camShakeDuration ) {
			cam.transform.localPosition=camOrgPos+Random.insideUnitSphere/30;

		}
	}

	void OnCollisionEnter(Collision col){
		//working is the same without foreach!
		//foreach (ContactPoint contact in col.contacts) {
			if (col.collider.tag=="ship") {
				float displacementValue= col.contacts[0].point.x - col.collider.transform.position.x;
				Vector3 newVel=new Vector3(0.0f,ballBody.velocity.y,0.0f);
				ballBody.velocity=newVel;
				ballBody.AddForce(600*displacementValue,50f,0.0f,ForceMode.Force);
			}
			else if(col.collider.tag=="LevelTwoBrick"){
				if(scriptRef.isFirePowerOn || scriptRef.isIcePowerOn){
					Instantiate(brickBlast,col.transform.position,Quaternion.identity);
					Destroy(col.gameObject);
					scoreUpdate();
					isCamShaking=true;
					camShaketime=0.0f;
				}
				else{
					col.collider.tag="LevelOneBrick";
					Renderer ren=col.gameObject.GetComponent<Renderer>();
					ren.material=greenM;
					isCamShaking=true;
					camShaketime=0.0f;
				}
				
			}
			else if(col.collider.tag=="LevelOneBrick"){
				if(scriptRef.isFirePowerOn || scriptRef.isIcePowerOn){
					Instantiate(brickBlast,col.transform.position,Quaternion.identity);
					Destroy(col.gameObject);
					scoreUpdate();
					isCamShaking=true;
					camShaketime=0.0f;
				}
				else{
					col.collider.tag="LevelZeroBrick";
					Renderer ren=col.gameObject.GetComponent<Renderer>();
					ren.material=blueM;
					isCamShaking=true;
					camShaketime=0.0f;
				}
				
			}
			else if(col.collider.tag=="LevelZeroBrick"){
				if(hitCount==0){
					timeBetweenHits=0.0f;
				}
				Instantiate(brickBlast,col.transform.position,Quaternion.identity);
				Destroy(col.gameObject);
				if(timeBetweenHits<=1f){
					hitCount++;
				}
				scoreUpdate();
			}
		//}
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "base") {
			scriptRefUI.gameOver();
		}
	}

	void scoreUpdate(){
		score += 10;
		brickCount++;
	}

}
