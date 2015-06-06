using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	[SerializeField]
	private int _speed;
	[SerializeField]
	private GameObject _player;

	private float _difX;
	private float _range = 1.2f;
	private Rigidbody2D _body;

	void Start () {
		_body = GetComponent<Rigidbody2D>();
	}

	void Update () {
		FollowPlayer();

	}

	void FollowPlayer(){
		_difX = transform.position.x - _player.transform.position.x;

		Vector2 moveVel = _body.velocity;
		moveVel.y = 0f;

		if(_difX > _range){
			moveVel.x = -1f;
		} else if(_difX < -_range){
			moveVel.x = 1f;
		} else {
			moveVel.x = 0f;
		}

		_body.velocity = moveVel * _speed;

		Rotate(moveVel.x);
	}

	void Rotate(float dir){
		Vector2 scale = new Vector2(transform.localScale.x,transform.localScale.y);
		if(dir > 0f){
			scale.x = 0.3f;
		} else if (dir < 0f){
			scale.x = -0.3f;
		}
		transform.localScale = scale;
	}
}
