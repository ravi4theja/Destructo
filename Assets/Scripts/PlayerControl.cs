using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	// Use this for initialization
	public Transform myTransform;
	public float speed;
	private Vector3 position;
	public static int playerLives = 3;
	public static int score = 0;
	float timer = 0f;
	//need a reference to the prefab bullet gameobject
	public GameObject Bullet;

	void Start () {
		myTransform = transform;
		//starting position of the player after hitting the play
		myTransform.position = new Vector3 (-1, -2, 0);
	
	}
	
	// Update is called once per frame
	void Update () {

		myTransform.Translate (Vector3.right * Input.GetAxis ("Horizontal") * speed * Time.deltaTime);
		myTransform.Translate (Vector3.up * Input.GetAxis ("Vertical") * speed * Time.deltaTime);

		//this is how you wrap the player around
		// x axis
		if (myTransform.position.x >= 10) {
			myTransform.position = new Vector3(-10,myTransform.position.y, myTransform.position.z);
		}
		else if(myTransform.position.x <= -10){
			myTransform.position  = new Vector3(10, myTransform.position.y, myTransform.position.z);
		}
		// y axis
		if (myTransform.position.y >= 5) {
			myTransform.position = new Vector3(myTransform.position.x,-5, myTransform.position.z);
		}
		else if(myTransform.position.y <= -5){
			myTransform.position  = new Vector3(myTransform.position.x,5, myTransform.position.z);
		}

		//Press space to fire
		//Basically pressing the space button makes the gameobject fire
		if(Input.GetKeyDown(KeyCode.Space)){ 
			position = new Vector3(myTransform.position.x, myTransform.position.y+ 1.5f, myTransform.position.z);


			Instantiate(Bullet, position, Quaternion.identity);

		}

		if (Time.time - timer > 1) {
			GetComponent<Renderer>().enabled = true;
		}

		print ("Lives:" + playerLives + "  Score:" + score);


	}
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.CompareTag("Enemy") || collider.gameObject.CompareTag("Enemy2") || collider.gameObject.CompareTag("Bullet")){
			GetComponent<Renderer>().enabled = false;
			timer = Time.time;
			playerLives--;
			if(playerLives < 1){
				Destroy(this.gameObject);
			
			}
		}
	}
}
