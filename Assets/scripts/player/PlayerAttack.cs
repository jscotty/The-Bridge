using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	[SerializeField]
	private TGCConnectionController _tgcc;

	private bool _attack = false;

	void Start(){
		_tgcc.UpdateBlinkEvent += ReturnDelBlink;
	}

	void Update () {
		if(Input.GetButtonDown(Inputs.X)){
			_attack = true;
		}
	}

	void StopAttack(){
		_attack = false;
	}

	void ReturnDelBlink(int value){
		_attack = true;
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
