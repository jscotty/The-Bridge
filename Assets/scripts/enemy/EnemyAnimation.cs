using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {

	private Animator _anim;
	private EnemyAttack _enemyAttack;
	private EnemyMovement _enemyMovement;
	private EnemyHandler _enemyHandler;
	private CircleCollider2D _collider;
	private Rigidbody2D _body;

	private bool _attack;
	private bool _died = false;

	void Start () {
		_anim = GetComponent<Animator>();
		_enemyAttack = GetComponent<EnemyAttack>();
		_enemyMovement = GetComponent<EnemyMovement>();
		_enemyHandler = GetComponent<EnemyHandler>();
		_collider = GetComponent<CircleCollider2D>();
		_body = GetComponent<Rigidbody2D>();

		_enemyHandler.GetDamageEvent += Die;
	}

	void Update () {
		if(_died){

		} else {
			_attack = _enemyAttack.attack;
			
			if(_attack){
				_anim.SetBool(Animations.ATTACK, true);
			} else {
				_anim.SetBool(Animations.ATTACK, false);
			}
		}
	}

	void Die(){
		_died = true;
		int ranNmr = Mathf.FloorToInt(Random.Range(0,10));
		
		if (ranNmr <= 8) {
			_anim.SetBool(Animations.DEAD, true);
			_body.isKinematic = true;
		} else {
			_anim.SetBool(Animations.DEAD_FALLING, true);
		}
		_enemyMovement.stopMove = true;
		_collider.isTrigger = true;
	}
}
