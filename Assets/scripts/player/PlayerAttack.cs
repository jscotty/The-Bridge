using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private bool _attack = false;

	void Update () {
		if(Input.GetButtonDown(Inputs.A)){
			_attack = true;
		}
	}

	void StopAttack(){
		_attack = false;
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
	#endregion
}
