using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttentionLevel : MonoBehaviour {

	[SerializeField]
	private ColorChanger _color;

	private Text _txt;

	void Start () {
		_txt = GetComponent<Text>();
	}


	void Update () {
		_txt.text = "Attention level:" + _color.meditationCount;
	}
}
