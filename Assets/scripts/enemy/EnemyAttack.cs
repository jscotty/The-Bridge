using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAttack : MonoBehaviour {

	private PlayerHandler _playerHandler;

	private EnemyMovement _enemyMovement;
	private EnemyData _enemyData;

	private float _dir;
	private float _difX;
	private float _range;

	private bool _attack = false;

	void Start () {
		_enemyMovement = GetComponent<EnemyMovement>();
		_enemyData = GetComponent<EnemyData>();
		_range = _enemyMovement.range;

			GameObject player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
			_playerHandler = player.GetComponent<PlayerHandler>();

	}

	void Update () {
		_dir = _enemyMovement.dir; _difX = _enemyMovement.difX;

		if(_dir == 0){
			_attack = true;
			_enemyMovement.stopMove = true;
		} else {
			_enemyMovement.stopMove = false;
		}
		


	}

	public void Damage(){

		float range = _range * transform.localScale.x;
		//print("range("+range+") dif("+_difX+")");

		if(range == _range){
			if(_difX >= 0f){
			} else if(_difX > -_range){
				_playerHandler.TakeDamage(_enemyData.damage);
			}
		} else if(range == -_range){
			if(_difX < _range){
				_playerHandler.TakeDamage(_enemyData.damage);
			} else if(_difX <= 0f){
			}
		}

	}

	public void StopAttack(){
		_enemyMovement.stopMove = false;
		_enemyMovement.dir = 1;
		_attack = false;
	}

	#region getter
	
	public bool attack {
		get {
			return _attack;
		}
	}

	#endregion
}
