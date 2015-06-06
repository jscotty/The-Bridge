using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private Animator _anim;
	private PlayerAttack _playerAttack;

	private bool _attack;

	void Start () {
		_anim = GetComponent<Animator>();
		_playerAttack = GetComponent<PlayerAttack>();
	}

	void Update () {
		_attack = _playerAttack.attack;

		if(_attack){
			_anim.SetBool("Attack", true);
		} else if(!_attack){
			_anim.SetBool("Attack", false);
		}
	}
}
