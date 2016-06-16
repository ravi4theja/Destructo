using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {


	public float speed;
	private float startPosition;
	private float distance;
	private int switchExpression;
	// Use this for initialization
	void Start () {

		startPosition = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < 5) {
			switchExpression = 0;
		}


		switch (switchExpression) {
		case 0:
			speed *= 1;
			transform.position = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y);
			break;
		case 1:
			speed *= -1;
			transform.position = new Vector2 (transform.position.x, transform.position.y + speed * Time.deltaTime);
			break;
		case 2:
			speed *= -1;
			transform.position = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y);
			break;
		case 3:
			speed *= 1;
			transform.position = new Vector2 (transform.position.x, transform.position.y + speed * Time.deltaTime);
			break;
		}		
	}
}
