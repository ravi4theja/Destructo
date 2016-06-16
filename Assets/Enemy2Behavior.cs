using UnityEngine;
using System.Collections;

public class Enemy2Behavior : MonoBehaviour {

	// Use this for initialization
	private Transform myTransform;
	public Transform[] patrolPoints2;
	public float enemy2Speed;
	private int currentPoint;
	public GameObject bullet;
	GameObject Player;
	bool spawn;
	Vector3 position;




	void Start () {
		myTransform = transform;
		myTransform.position = patrolPoints2[0].position;
		currentPoint = 0;

		Player = GameObject.Find ("Player");
		spawn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(myTransform.position == patrolPoints2[currentPoint].position)
		{
			currentPoint++;
		}
		if (currentPoint >= patrolPoints2.Length) {
			currentPoint = 0;
		}
		myTransform.position = Vector3.MoveTowards (myTransform.position, patrolPoints2[currentPoint].position, enemy2Speed * Time.deltaTime);




		//shooting
		if (Player == null)
			return;
		if (spawn && (Mathf.Abs (myTransform.position.x - Player.transform.position.x) > 0.2f && Mathf.Abs (myTransform.position.y - Player.transform.position.y) > 0.2f)) {
			spawn = false;
			Debug.Log ("No");
		}
		
		if (!spawn){
			
			Debug.Log("gg");
			
			if(Mathf.Abs(myTransform.position.x- Player.transform.position.x)<0.1f) {
				
				if((myTransform.position.y- Player.transform.position.y)<0 ){
					Debug.Log("bullgg");
					position = new Vector3(myTransform.position.x, myTransform.position.y+1.5f, myTransform.position.z);
					
					GameObject bull = (Instantiate (bullet, position, Quaternion.identity)) as GameObject;
					Debug.Log(bull);
					bull.GetComponent<Bullet>().setDirection(1);
				}
				else{
					position = new Vector3(myTransform.position.x, myTransform.position.y-1.5f, myTransform.position.z);
					GameObject bull = (GameObject)(Instantiate (bullet, position, Quaternion.identity));
					bull.GetComponent<Bullet>().setDirection(2);
				}
				spawn = true;
				
			}
			
			if(Mathf.Abs(myTransform.position.y-Player.transform.position.y) < 0.1f){
				
				if((myTransform.position.x- Player.transform.position.x)<0 ){
					position = new Vector3(myTransform.position.x+ 1.5f, myTransform.position.y, myTransform.position.z);
					GameObject bull = (GameObject)(Instantiate (bullet, position, Quaternion.identity));
					bull.GetComponent<Bullet>().setDirection(3);
				}
				else{
					position = new Vector3(myTransform.position.x-1.5f, myTransform.position.y, myTransform.position.z);
					GameObject bull = (GameObject)(Instantiate (bullet, position, Quaternion.identity));
					bull.GetComponent<Bullet>().setDirection(4);
				}
				spawn = true;
				
			}
			
		}


	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.CompareTag ("Bullet"))
			Destroy (this.gameObject);
	}
}
