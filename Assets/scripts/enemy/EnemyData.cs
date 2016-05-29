using UnityEngine;
using System.Collections;

public class EnemyData : MonoBehaviour {
	
	[SerializeField]
	private int _health;
	[SerializeField]
	private int _damage;
	[SerializeField]
	private int _score;


	public int damage {
		get {
			return _damage;
		}
		set {
			_damage = value;
		}
	}
	
	public int health {
		get {
			return _health;
		}
		set {
			_health = value;
		}
	}
	
	public int score {
		get {
			return _score;
		}
		set {
			_score = value;
		}
	}

}
