using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
	
	public delegate void UpdateAttackDamageDelegate(int damage);
	//public delegate void UpdateGetDamageDelegate(int damage);
	
	public event UpdateAttackDamageDelegate AttackDamageEvent;
	//public event UpdateAttackDamageDelegate GetDamageEvent;

	[SerializeField]
	private ScoreHandler _score;

	private PlayerData _playerData;
	private float _health;
	private bool _died = false;

	void Start(){
		_playerData = GetComponent<PlayerData>();
		AttackDamageEvent += GetDamage;
	}

	void Update(){
		_health = _playerData.health;

		if(_health <= 0){
			_died = true;
		}
	}

	public void TakeDamage(int value){
		if(AttackDamageEvent != null){
			AttackDamageEvent(value);
		}
	}
	
	void Dead(){
		PlayerPrefs.SetInt(Prefs.LAST_SCORE, _score.score);
		if(_score.score > PlayerPrefs.GetInt(Prefs.SCORE)){
			PlayerPrefs.SetInt(Prefs.SCORE, _score.score);
			Application.LoadLevel(Levels.HIGHSCORE);
		} else 
			Application.LoadLevel(Levels.MAIN_MENU);
	}

	void GetDamage(int value){
		_playerData.health -= value;
	}
	
	public bool died {
		get {
			return _died;
		}
		set {
			_died = value;
		}
	}
}
