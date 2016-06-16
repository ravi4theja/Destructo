using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {

	void OnGUI(){
		GUI.Box (new Rect (50, 50, 1000, 100), "Score:" + PlayerControl.score + "  Lives:" + PlayerControl.playerLives );
	}
}
