using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

	[SerializeField]
	private float _speed = 0.1f;
	[SerializeField]
	private float _maxRange = 12.5f;

	private Rigidbody2D _body;

	void Start () {
		_body = GetComponent<Rigidbody2D>();
	}

	void Update () {
		Move();
		TransformDetect();
	}

	private void Move(){
		Vector2 moveVel = _body.velocity;
		moveVel.x = 1;
		moveVel.y = 0;
		_body.velocity = moveVel * _speed;
	}

	private void TransformDetect(){
		if(transform.position.x >= _maxRange){
			float y = Random.Range(-3f,4f);
			print(y);
			transform.position = new Vector2(-_maxRange,y);
		}
	}
}
