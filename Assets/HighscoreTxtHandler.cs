using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoreTxtHandler : MonoBehaviour {

	[SerializeField]
	private int _type;

	private Text _txt;

	void Start () {
		_txt = GetComponent<Text>();

		if(_type == 1){
			_txt.text = "Highscore: " + PlayerPrefs.GetInt(Prefs.SCORE);
		} else if(_type == 2){
			_txt.text = "by: " + PlayerPrefs.GetString(Prefs.NAME);
		} else if(_type == 3){
			print(Application.persistentDataPath);
			_txt.text = "Last: " + PlayerPrefs.GetInt(Prefs.LAST_SCORE);
		}
	}

}
