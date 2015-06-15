using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
	
	public delegate void UpdateAttackDamageDelegate();
	
	public event UpdateAttackDamageDelegate AttackDamageEvent;

	void Start(){

	}

	public void TakeDamage(){
		if(AttackDamageEvent != null){
			AttackDamageEvent();
		}
	}
}
