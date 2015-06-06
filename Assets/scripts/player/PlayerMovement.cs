using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private int _speed;

	private Rigidbody2D _body;
	
	private int _jumpSpeed = 2;
	private int _jumpCount;

	void Start () {
		_body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Rotate();
	}

	private void Move(){
		Vector2 moveVel = _body.velocity;
		moveVel.x = Input.GetAxis(Inputs.HORIZONTAL);
		moveVel.y = 0;


		if(Input.GetButton(Inputs.Y)){
			moveVel.y = _jumpSpeed;
			_jumpCount++;
			Jump();
		}
		_body.velocity = moveVel * _speed;
	}
	private void Jump(){
		if(_jumpCount >= 13 || Input.GetButtonUp(Inputs.Y)){
			_jumpSpeed = 0;
		}
	}
	private void OnCollisionEnter2D(Collision2D other){
		_jumpCount = 0;
		_jumpSpeed = 2;
	}
	private void Rotate(){
		Vector2 rot = new Vector2(transform.localScale.x,transform.localScale.y);
		rot.y = 0.3f;

		float x = Input.GetAxisRaw(Inputs.HORIZONTAL);

		if(x > 0f){
			rot.x = 0.3f;
		} else if(x < 0f){
			rot.x = -0.3f;
		}

		transform.localScale = rot;
	}
}
