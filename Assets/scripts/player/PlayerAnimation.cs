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
			_anim.SetBool(Animations.ATTACK, true);
		} else if(!_attack){
			_anim.SetBool(Animations.ATTACK, false);
		}

		if(Input.GetAxis(Inputs.HORIZONTAL) == 0){
			_anim.SetBool(Animations.IDLE, true);
			_anim.SetBool(Animations.WALK, false);
		} else {
			_anim.SetBool(Animations.WALK, true);
			_anim.SetBool(Animations.IDLE, false);
		}

		if(_isJumping){
			_anim.SetBool(Animations.JUMP, true);
		}else{
			_anim.SetBool(Animations.JUMP, false);
		}
	}
}
