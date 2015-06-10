using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {

	private Animator _anim;
	private EnemyAttack _enemyAttack;
	private EnemyMovement _enemyMovement;

	bool _attack;

	void Start () {
		_anim = GetComponent<Animator>();
		_enemyAttack = GetComponent<EnemyAttack>();
		_enemyMovement = GetComponent<EnemyMovement>();
	}

	void Update () {
		_attack = _enemyAttack.attack;

		if(_attack){
			_anim.SetBool("Attack", true);
		} else {
			_anim.SetBool("Attack", false);
		}
	}
}
