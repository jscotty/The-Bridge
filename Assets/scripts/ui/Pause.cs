using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public static bool isPaused;

	[SerializeField]
	private GameObject _pausedScreen;

	private int _count;

	void Update(){
		if(Input.GetButton(Inputs.START)){
			_count++;
			if(_count == 1){
				if(isPaused){
					isPaused = false;
					Time.timeScale = 1;
					_pausedScreen.SetActive(false);
				} else {
					isPaused = true;
					Time.timeScale = 0;
					_pausedScreen.SetActive(true);
				}
			}
		} else {
			_count = 0;
		}
	}
}
