using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {
	[SerializeField]
	private int _health = 100;
	[SerializeField]
	private float _damage = 100f;

	public int health{
		get{
			return _health;
		}
		set{
			_health = value;
		}
	}
	public float damage{
		get{
			return _damage;
		}
	}

}
