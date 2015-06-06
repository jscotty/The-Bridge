using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	private SpriteRenderer _spriteRen;

	private float r = 1f,g = 1f,b = 1f;

	void Start () {
		_spriteRen = GetComponent<SpriteRenderer>();
	}

	void Update () {
		if(Input.GetKey(KeyCode.I)){
			r -= 0.01f;
			g -= 0.01f;
			b -= 0.01f;
		} else if(Input.GetKey(KeyCode.K)){
			r += 0.01f;
			g += 0.01f;
			b += 0.01f;
		}
		
		Color32 color = new Color(r,g,b,225f);
		_spriteRen.color = color;


	}
}
