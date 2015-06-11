using UnityEngine;
using System.Collections;

public class EnemyData : MonoBehaviour {
	
	[SerializeField]
	private int _health;
	[SerializeField]
	private int _damage;


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

}
