using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private Animator _anim;
	private PlayerAttack _playerAttack;
	private PlayerMovement _playerMovement;
	private PlayerHandler _playerHandler;

	private bool _attack;
	private bool _attack2;
	private bool _died;
	private bool _isJumping;

	void Start () {
		_anim = GetComponent<Animator>();
		_playerAttack = GetComponent<PlayerAttack>();
		_playerMovement = GetComponent<PlayerMovement>();
		_playerHandler = GetComponent<PlayerHandler>();
	}

	void Update () {
		_attack = _playerAttack.attack;
		_attack2 = _playerAttack.attack2;
		_isJumping = _playerMovement.isJumping;
		_died = _playerHandler.died;

		if(_attack){
			_anim.SetBool(Animations.ATTACK, true);
			_anim.SetBool(Animations.ATTACK2, false);
			_playerMovement.isMoving = false;
		} else if(!_attack){
			_anim.SetBool(Animations.ATTACK, false);
			_playerMovement.isMoving = true;
		}

		if(_attack2){
			_anim.SetBool(Animations.ATTACK2, true);
			_anim.SetBool(Animations.ATTACK, false);
			_playerMovement.isMoving = false;
		} else if(!_attack2){
			_anim.SetBool(Animations.ATTACK2, false);
		}

		if(Input.GetAxis(Inputs.HORIZONTAL) == 0){
			_anim.SetBool(Animations.IDLE, true);
			_anim.SetBool(Animations.WALK, false);
			_playerMovement.isMoving = true;
		} else {
			_anim.SetBool(Animations.WALK, true);
			_anim.SetBool(Animations.IDLE, false);
		}

		if(_isJumping){
			_anim.SetBool(Animations.JUMP, true);
		}else{
			_anim.SetBool(Animations.JUMP, false);
		}
		if(_died){
			_anim.SetBool(Animations.DEAD, true);
		}
	}
}
