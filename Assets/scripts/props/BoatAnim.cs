using UnityEngine;
using System.Collections;

public class BoatAnim : MonoBehaviour {

	[SerializeField]
	private float _speed;
	
	[SerializeField]
	private float _moveX = 1;

	private Rigidbody2D _body;

	void Start () {
		_body = GetComponent<Rigidbody2D>();
	}

	void Update () {
		Move();
	}

	private void Move(){
		//boat movement with moveVelocity
		Vector2 moveVel = _body.velocity; 
		moveVel.x = _moveX;
		moveVel.y = 0;
		_body.velocity = moveVel * _speed * 0.5f;

		Rotate();
	}
	private void Rotate(){
		if(transform.position.x >= 5.9f){
			_moveX -= 0.01f;
		} else if(transform.position.x <= -6.5f){
			_moveX += 0.01f;
			
		}

		Scale();
	}
	
	private void Scale(){

		if(_moveX > 0){ // face right (scaleX -1)
			transform.localScale = new Vector2(-1f,1f);
		} else if(_moveX < 0){ // face left (scale 1)
			transform.localScale = new Vector2(1f,1f);
		}
	}
}
