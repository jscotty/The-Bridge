using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	[SerializeField]
	private PlayerHandler _playerHandler;
	[SerializeField]
	private int _shakeLenght;

	private int _shakecount;
	private bool _shake;

	void Start () {
		_playerHandler.AttackDamageEvent += Shake;
	}
	
	// Update is called once per frame
	void Update () {
		if(_shake){
			if (_shakecount <= 0) {
				_shakecount = _shakeLenght;	
				transform.position = new Vector3(0f, 0f, -10f);
				_shake = false;
			} else if( _shakecount > 0){
				float randomNmX = Random.Range(-0.2f,0.2f);
				float randomNmY = Random.Range(-0.2f,0.2f);
				float randomNmZ = Random.Range(-9.2f,-10.2f);
				transform.position = new Vector3(randomNmX, randomNmY, randomNmZ);
				_shakecount--;
			}
		}
	}

	void Shake(){
		_shake = true;
	}

}
