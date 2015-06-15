using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	[SerializeField]
	private TGCConnectionController _tgcc;
	[SerializeField]
	private float _range = 1.2f;

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
	void Damage(){
		
		GameObject[] enemys = GameObject.FindGameObjectsWithTag(Tags.ENEMY);
		float range = _range * transform.localScale.x;
		//print(enemys[0].transform.position.x + " e2 xpos" + enemys[1].transform.position.x);
		for (int i = 0; i < enemys.Length; i++) {
			float dif = transform.position.x - enemys[i].transform.position.x;
			//print("dif("+dif+"|range"+-_range);
			EnemyHandler enemyHandler = enemys[i].GetComponent<EnemyHandler>();
			
			if(range == _range){
				if(dif >= 0f){
				} else if(dif > -_range){
					enemyHandler.GetDamage();
				}
			} else if(range == -_range){
				if(dif <= 0f){
				} else if(dif < _range){
					enemyHandler.GetDamage();
				}
			}
		}
	}

	void ReturnDelBlink(int value){
		_attack = true;
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
	#endregion
}
