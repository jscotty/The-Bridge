using UnityEngine;
using System.Collections;

public class EnemyHandler : MonoBehaviour {

	public delegate void UpdateGetDamageDelegate();
	
	public event UpdateGetDamageDelegate GetDamageEvent;

	private bool _died = false;

	public bool died {
		get {
			return _died;
		}
		set {
			_died = value;
		}
	}

	public void GetDamage(){
		_died = true;
		if(GetDamageEvent != null){
			GetDamageEvent();
		}
	}
}
