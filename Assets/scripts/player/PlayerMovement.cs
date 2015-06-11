using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private int _speed;

	private Rigidbody2D _body;
	
	private int _jumpSpeed = 2;
	private int _jumpCount;
	private bool _isJumping = false;

	void Start () {
		_body = GetComponent<Rigidbody2D>();LoadingScreen.isLoading = false;
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

		if(Input.GetButton(Inputs.A)){
			moveVel.y = _jumpSpeed;
			_isJumping = true;
			_jumpCount++;
			Jump();
		}
		_body.velocity = moveVel * _speed;
	}
	private void Jump(){
		if(_jumpCount >= 11 || Input.GetButtonUp(Inputs.A)){
			_jumpSpeed = 0;
			_isJumping = false;
		}
	}
	private void OnCollisionEnter2D(Collision2D other){
		_jumpCount = 0;
		_jumpSpeed = 2;
		_isJumping = false;
	}
	private void Rotate(){
		if(!Pause.isPaused){
			Vector2 rot = new Vector2(transform.localScale.x,transform.localScale.y);
			rot.y = 1f;
			
			float x = Input.GetAxisRaw(Inputs.HORIZONTAL);
			
			if(x > 0f){
				rot.x = 1f;
			} else if(x < 0f){
				rot.x = -1f;
			}
			
			transform.localScale = rot;
		}
	}

	#region getters and setters
	public bool isJumping{
		get{
			return _isJumping;
		}
	}
	#endregion
}
