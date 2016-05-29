using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	[SerializeField]
	private int _speed;
	[SerializeField]
	private GameObject _player;
	[SerializeField]
	private float _range = 1.2f;

	private float _difX;
	private float _dir = 1;
	private float _scal;
	private Rigidbody2D _body;
	private bool _stopMove;

	void Start () {
		_body = GetComponent<Rigidbody2D>();
		_scal = transform.localScale.x;

		if(_player == null){
			_player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
		}
	}

	void Update () {
		FollowPlayer();

	}

	void FollowPlayer(){
		_difX = transform.position.x - _player.transform.position.x;

		Vector2 moveVel = _body.velocity;
		moveVel.y = 0f;

		//print("difx( " + _difX + " ) range( " + _range + " )");
		if(_difX > _range){
			_dir = -1f;
		} else if(_difX < -_range){
			_dir = 1f;
		} else {
			_dir = 0f;
		}
		if(_stopMove){
			_dir = 0f;
		}

		moveVel.x = _dir;

		_body.velocity = moveVel * _speed;

		Rotate(moveVel.x);
	}

	void Rotate(float dir){
		Vector2 scale = new Vector2(transform.localScale.x,transform.localScale.y);
		if(dir > 0f){
			scale.x = _scal;
		} else if (dir < 0f){
			scale.x = -_scal;
		}
		transform.localScale = scale;
	}

	#region
	public float dir{
		get{
			return _dir;
		}
		set{
			_dir = value;
		}
	}
	public float difX{
		get{
			return _difX;
		}
	}
	public float range{
		get{
			return _range;
		}
	}
	
	public bool stopMove{
		set{
			_stopMove = value;
		}
	}
	#endregion
}
