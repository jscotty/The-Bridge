using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour {

	[SerializeField]
	private GameObject[] _dots;
	[SerializeField]
	private Image[] _buttons;
	[SerializeField]
	private Sprite[] _images;
	[SerializeField]
	private int _maxCount = 5;

	private int _count;
	private int _activeCount = 1;

	private enum Buttons{PLAY = 1,CREDITS = 2,OPTIONS = 3,EXIT = 4};
	private Buttons _button;

	private enum ButtonsTexture{PLAY = 0,PLAY_ACTIVE = 1,CREDITS = 2,CREDITS_ACTIVE = 3,OPTIONS = 4,OPTIONS_ACTIVE = 5,
								EXIT = 6, EXIT_ACTIVE = 7};

	void Start(){
		_button = Buttons.PLAY;
	}

	void Update(){
		if(Input.GetAxis(Inputs.VERTICAL) < 0f){
			_count ++;
			if(_count >= 10){
				_activeCount ++;
				_button ++;
				_count = 0;
			}
		} else if(Input.GetAxis(Inputs.VERTICAL) > 0f){
			_count ++;
			if(_count >= 10){
				_activeCount --;
				_button --;
				_count = 0;
			}
		} else {
			_count = 9;
		}
		if(_activeCount >= _maxCount){
			_activeCount = 1;
			_button = Buttons.PLAY;
		} else if(_activeCount <= 0){
			_activeCount = 4;
			_button = Buttons.EXIT;
		}

		ActivateButton();
	}

	void ActivateButton(){
		if(_button == Buttons.PLAY){
			_dots[0].SetActive(true);
			_dots[1].SetActive(false);
			_dots[2].SetActive(false);
			_dots[3].SetActive(false);

			_buttons[0].sprite =_images[1];
			_buttons[1].sprite =_images[2];
			_buttons[2].sprite =_images[4];
			_buttons[3].sprite =_images[6];

		} else if(_button == Buttons.CREDITS){
			_dots[0].SetActive(false);
			_dots[1].SetActive(true);
			_dots[2].SetActive(false);
			_dots[3].SetActive(false);
			
			_buttons[0].sprite =_images[0];
			_buttons[1].sprite =_images[3];
			_buttons[2].sprite =_images[4];
			_buttons[3].sprite =_images[6];

		} else if(_button == Buttons.OPTIONS){
			_dots[0].SetActive(false);
			_dots[1].SetActive(false);
			_dots[2].SetActive(true);
			_dots[3].SetActive(false);
			
			_buttons[0].sprite =_images[0];
			_buttons[1].sprite =_images[2];
			_buttons[2].sprite =_images[5];
			_buttons[3].sprite =_images[6];

		} else if(_button == Buttons.EXIT){
			_dots[0].SetActive(false);
			_dots[1].SetActive(false);
			_dots[2].SetActive(false);
			_dots[3].SetActive(true);
			
			_buttons[0].sprite =_images[0];
			_buttons[1].sprite =_images[2];
			_buttons[2].sprite =_images[4];
			_buttons[3].sprite =_images[7];
			
		}

	}

	#region getter
	public int activeCount{
		get{
			return _activeCount;
		}
	}
	#endregion

}
