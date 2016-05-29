using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthText : MonoBehaviour {

	[SerializeField]
	private PlayerData _playerData;

	private Text _healthTxt;

	void Start(){
		_healthTxt = GetComponent<Text>();
	}

	void Update () {

		if(_playerData.health <= 45){
			_healthTxt.color = new Color32(225,50,50,225);
		}
		if(_playerData.health <= 0){
			_healthTxt.text = "you died...";
		} else 
			_healthTxt.text = "Health: "+_playerData.health;
	}
}
