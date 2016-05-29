using UnityEngine;
using System.Collections;

public class MenuControll : MonoBehaviour {

	[SerializeField]
	private TGCConnectionController _tgcc;

	[SerializeField]
	private GameObject _credits;
	[SerializeField]
	private GameObject _buttons;

	private MenuHandler _menuHandler;
	private int _activeCount;

	void Start(){
		LoadingScreen.isLoading = true;
		_menuHandler = GetComponent<MenuHandler>();

		_tgcc.UpdateBlinkEvent += ReturnDelBlink;
		_tgcc.UpdatePoorSignalEvent += ReturnSignal;
	}

	void Update(){
		_activeCount = _menuHandler.activeCount;
		if(Input.GetButton(Inputs.A)){
			if(_activeCount == 1){
				LoadingScreen.isLoading = true;
				Application.LoadLevel(Levels.GAME_JUSTIN);
			} else if(_activeCount == 2){
				_credits.SetActive(true);
				_buttons.SetActive(false);
			} else if(_activeCount == 4){
				LoadingScreen.isLoading = true;
				print("quit");
				Application.Quit();
			}
		} else if(Input.GetButton(Inputs.B)){
			_credits.SetActive(false);
			_buttons.SetActive(true);
		}
	}

	void ReturnDelBlink(int value){
		if(_activeCount == 1){
			//LoadingScreen.isLoading = true;
			//Application.LoadLevel(Levels.GAME_JUSTIN);
			_tgcc.UpdateBlinkEvent -= ReturnDelBlink;
		}
	}

	void ReturnSignal(int value){
		Debug.Log(value);
	}
}
