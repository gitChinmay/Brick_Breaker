using UnityEngine;
using System.Collections;

public class BallPowerLook : MonoBehaviour {

	public GameObject defaultTail;
	public GameObject iceTail;
	public GameObject fireTail;

	GameObject iceTailGO;

	public bool isIcePowerOn = false;
	public bool isFirePowerOn = false;
	public bool isDefaultOn = false;

	//float holdTime=0.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	//	holdTime += Time.deltaTime;
	}

	public void icePowerLook(){
		isIcePowerOn = true;
		isFirePowerOn = false;
		isDefaultOn = false;

		iceTail.SetActive (true);
		fireTail.SetActive (false);
		defaultTail.SetActive (false);
	}

	public void firePowerLook(){
		isFirePowerOn = true;
		isIcePowerOn = false;
		isDefaultOn = false;

		fireTail.SetActive (true);
		iceTail.SetActive (false);
		defaultTail.SetActive (false);
	}

	public void defaultOn(){
		isDefaultOn = true;
		isIcePowerOn = false;
		isFirePowerOn = false;

		defaultTail.SetActive (true);
		fireTail.SetActive (false);
		iceTail.SetActive (false);

	}
}
