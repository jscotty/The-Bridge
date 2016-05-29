using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHandler : MonoBehaviour {

	private Text _txt;
	private int _score = 0;

	void Start () {
		_txt = GetComponent<Text>();
	}

	void Update () {
		_txt.text = "Score: " + _score;
	}

	public int score {
		get {
			return _score;
		}
		set {
			_score = value;
		}
	}
}
