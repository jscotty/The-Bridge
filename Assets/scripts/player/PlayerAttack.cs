using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	[SerializeField]
	private TGCConnectionController _tgcc;
	[SerializeField]
	private ScoreHandler _score;
	[SerializeField]
	private float _range = 1.2f;
	[SerializeField]
	private AudioClip _attackAudio;
	
	private AudioSource _audio;

	private bool _attack = false;
	private bool _attack2 = false;

	void Start(){
		_tgcc.UpdateBlinkEvent += ReturnDelBlink;
		_audio = GetComponent<AudioSource>();
	}

	void Update () {
		if(Input.GetButtonDown(Inputs.X)){
			if( _attack2 == true){

			} else
				_attack = true;
		}



	}
	
	void StopAttack(){
		_attack = false;
		_attack2 = false;
	}

	void Attack2(){
		if(Input.GetButton(Inputs.X)){
			_attack2 = true;
			_attack = false;
		}
	}

	void Damage(){

		_audio.PlayOneShot(_attackAudio, 1f);
		
		GameObject[] enemys = GameObject.FindGameObjectsWithTag(Tags.ENEMY);
		float range = _range * transform.localScale.x;
		//print(enemys[0].transform.position.x + " e2 xpos" + enemys[1].transform.position.x);
		for (int i = 0; i < enemys.Length; i++) {
			float dif = transform.position.x - enemys[i].transform.position.x;
			//print("dif("+dif+"|range"+-_range);
			EnemyHandler enemyHandler = enemys[i].GetComponent<EnemyHandler>();

			int score = enemys[i].GetComponent<EnemyData>().score;
			if(range == _range){
				if(dif >= 0f){
				} else if(dif > -_range){
					if(!enemyHandler.died)
						_score.score += score;

					enemyHandler.GetDamage();
				}
			} else if(range == -_range){
				if(dif <= 0f){
				} else if(dif < _range){
					if(!enemyHandler.died)
						_score.score += score;

					enemyHandler.GetDamage();
				}
			}
		}
	}

	void ReturnDelBlink(int value){
		//_attack = true;
		//print("blink: " + value);
	}


	#region Getter and Setter
	public bool attack{
		get{
			return _attack;
		}
		set{
			_attack = value;
		}
	}
	public bool attack2{
		get{
			return _attack2;
		}
		set{
			_attack2 = value;
		}
	}
	#endregion
}
