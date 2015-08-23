using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour {
	Image img;
	Sprite[] playButtonSprite;
	int frameNum=0;
	int spriteIndex=0;
	// Use this for initialization
	void Start () {
		playButtonSprite=Resources.LoadAll<Sprite>("newSpriteWithoutPlay");
		img = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (frameNum % 3 == 0) {
			img.sprite = playButtonSprite [(spriteIndex++) % 30];
		}
		frameNum += 1;
	}
}
