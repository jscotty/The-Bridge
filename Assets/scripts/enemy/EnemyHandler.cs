using UnityEngine;
using System.Collections;

public class EnemyHandler : MonoBehaviour {

	public delegate void UpdateGetDamageDelegate();
	
	public event UpdateGetDamageDelegate GetDamageEvent;

	public void GetDamage(){
		if(GetDamageEvent != null){
			GetDamageEvent();
		}
	}
}
