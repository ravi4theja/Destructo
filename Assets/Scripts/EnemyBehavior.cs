using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	// Use this for initialization
	/*(space Shooter)private Transform myTransform;
	public float maxSpeed = 10.0f;
	public float minSpeed = 5.0f;
	int x, y, z;
	public float currentSpeed; */
	private Transform myTransform;
	public Transform[] patrolPoints;
	public float enemySpeed;
	private int currentPoint;
	private Vector3 position, playerPosition;


	public GameObject bullet;
	GameObject Player;
	bool spawn;




	void Start () {
		/* (Space Shooter)myTransform = transform;
		x = Random.Range (-7, 7);
		y = 5;
		z = 0;
		myTransform.position = new Vector3 (x, y, z);
		currentSpeed = Random.Range(minSpeed, maxSpeed); */

	
		//starting position of the enemy
		//DDmyTransform.position = new Vector3 (-7, 4, 0);
		myTransform = transform;
		myTransform.position = patrolPoints[0].position;
		currentPoint = 0;


		//getting position from the player
		Player = GameObject.Find ("Player");
		spawn = false;



	}
	
	// Update is called once per frame
	void Update () {
		//Move it in a set path
		//starting from -7,4 to 7,4 to 7,-4 to -7,-4 to -7,4

		if(myTransform.position == patrolPoints[currentPoint].position)
		{
			currentPoint++;
		}
		if (currentPoint >= patrolPoints.Length) {
			currentPoint = 0;
		}
		myTransform.position = Vector3.MoveTowards (myTransform.position, patrolPoints[currentPoint].position, enemySpeed * Time.deltaTime);


		//if the x or y coordinate of player and enemy matches instanstiate bullet from the enemy
		//the direction of the bullet be in the direction of player
		if (Player == null)
			return;

		if (spawn && (Mathf.Abs (myTransform.position.x - Player.transform.position.x) > 0.2f && Mathf.Abs (myTransform.position.y - Player.transform.position.y) > 0.2f)) {
			spawn = false;
		
		}

		if (!spawn){
			
		
			
			if(Mathf.Abs(myTransform.position.x- Player.transform.position.x)<0.1f) {
				
				if((myTransform.position.y- Player.transform.position.y)<0 ){

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






		/*  (Space Shooter)x = Random.Range (-7, 7);
		myTransform.Translate (Vector3.down * currentSpeed * Time.deltaTime);
		if (myTransform.position.y < -5) {
			currentSpeed = Random.Range(minSpeed,maxSpeed);
			x = Random.Range(-7,7);
			myTransform.position = new Vector3(x, y, z);
		}*/
		
	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.CompareTag("Bullet"))
		   Destroy(this.gameObject);

	}
}
