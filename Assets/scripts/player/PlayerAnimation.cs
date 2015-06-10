using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private Animator _anim;
	private PlayerAttack _playerAttack;
	private PlayerMovement _playerMovement;

	private bool _attack;
	private bool _isJumping;

	void Start () {
		_anim = GetComponent<Animator>();
		_playerAttack = GetComponent<PlayerAttack>();
		_playerMovement = GetComponent<PlayerMovement>();
	}

	void Update () {
		_attack = _playerAttack.attack;
		_isJumping = _playerMovement.isJumping;

		if(_attack){
			_anim.SetBool("Attack", true);
		} else if(!_attack){
			_anim.SetBool("Attack", false);
		}

		if(Input.GetAxis(Inputs.HORIZONTAL) == 0){
			_anim.SetBool("Idle", true);
			_anim.SetBool("Walk", false);
		} else {
			_anim.SetBool("Walk", true);
			_anim.SetBool("Idle", false);
		}

		if(_isJumping){
			_anim.SetBool("Jump", true);
		}else{
			_anim.SetBool("Jump", false);
		}
	}
}
