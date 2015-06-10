using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {
	[SerializeField]
	private float _health = 100f;
	[SerializeField]
	private float _damage = 100f;

	public float health{
		get{
			return _health;
		}
	}
	public float damage{
		get{
			return _damage;
		}
	}

}
