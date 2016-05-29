using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndType : MonoBehaviour {

	[SerializeField]
	private Text _txt;

	private string _val;

	public void End(){
		_val = _txt.text;
		PlayerPrefs.SetString(Prefs.NAME, _val);

		Application.LoadLevel(Levels.MAIN_MENU);
	}
}
