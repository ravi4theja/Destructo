using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	private int dir;
	private Transform myTransform;
	public float bulletSpeed;
	void Start () {

		myTransform = transform;
		//initial position of the bullet

	}
	
	// Update is called once per frame
	void Update () {
		//if it goes off the screen destroy it
		switch (dir) {
		case 1:
			myTransform.Translate (Vector3.up * bulletSpeed * Time.deltaTime);
			break;
		case 2:
			myTransform.Translate (Vector3.down * bulletSpeed * Time.deltaTime);
			break;
		case 3:
			myTransform.Translate (Vector3.right * bulletSpeed * Time.deltaTime);
			break;
		case 4:
			myTransform.Translate (Vector3.left * bulletSpeed * Time.deltaTime);
			break;
		default:
			myTransform.Translate (Vector3.up * bulletSpeed * Time.deltaTime);
			break;

		}
		if(myTransform.position.y > 5) {
			Destroy(gameObject);
		}
		

	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.CompareTag("Enemy")){
			PlayerControl.score += 50;
			Destroy(this.gameObject);
		}
	
	}

	public void setDirection(int sdir) {
		dir = sdir;
	}
}
