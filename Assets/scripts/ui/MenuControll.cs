using UnityEngine;
using System.Collections;

public class MenuControll : MonoBehaviour {

	[SerializeField]
	private TGCConnectionController _tgcc;

	private MenuHandler _menuHandler;
	private int _activeCount;

	void Start(){
		LoadingScreen.isLoading = true;
		_menuHandler = GetComponent<MenuHandler>();

		_tgcc.UpdateBlinkEvent += ReturnDelBlink;
	}

	void Update(){
		_activeCount = _menuHandler.activeCount;
		if(Input.GetButton(Inputs.A)){
			if(_activeCount == 1){
				LoadingScreen.isLoading = true;
				Application.LoadLevel(Levels.GAME_JUSTIN);
			}
		}
	}

	void ReturnDelBlink(int value){
		if(_activeCount == 1){
			//LoadingScreen.isLoading = true;
			//Application.LoadLevel(Levels.GAME_JUSTIN);
			_tgcc.UpdateBlinkEvent -= ReturnDelBlink;
		}
	}
}
