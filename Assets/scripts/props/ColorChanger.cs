using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	[SerializeField]
	private TGCConnectionController _tgcc;

	private SpriteRenderer _spriteRen;

	private float r = 1f,g = 1f,b = 1f;
	private int _meditationCount, _count;

	private bool menu;

	void Start () {
		_spriteRen = GetComponent<SpriteRenderer>();
		if(_tgcc != null){
			_tgcc.UpdateAttentionEvent += ReturnDelAttention;
		}
	}

	void Update () {
		if(_tgcc != null){

			/*if(_count < _meditationCount){
				_count ++;
				r += 0.02f;
				g += 0.02f;
				b += 0.02f;
			} else if(_count > _meditationCount){
				_count --;
				r -= 0.02f;
				g -= 0.02f;
				b -= 0.02f;
			} else if(_count == _meditationCount){

			}	*/
			//print("ac: "+_meditationCount);
			if(_meditationCount >= 50){
				r += 0.01f;
				g += 0.01f;
				b += 0.01f;
			} else if(_meditationCount < 50){
				r -= 0.01f;
				g -= 0.01f;
				b -= 0.01f;
			} else if(_count == _meditationCount){
				
			}	
			//print("count (" + _count + ") | attention: " + _attentionCount);
		}
		if(Input.GetKey(KeyCode.I)){
			r -= 0.01f;
			g -= 0.01f;
			b -= 0.01f;
		} else if(Input.GetKey(KeyCode.K)){
			r += 0.01f;
			g += 0.01f;
			b += 0.01f;
		}

		if(r <= 0f){
			r = 0f; g = 0f; b = 0f;
		} else if(r >= 1f){
			r = 1f; g = 1f; b = 1f;
		}
		if(_count <= 0){
			_count = 0;
		} else if(_count >= 100){
			_count = 100;
		}
		
		Color32 color = new Color(r,g,b,225f);
		_spriteRen.color = color;


	}

	void ReturnDelAttention(int value){
		_meditationCount = value;
		//print("attention: " + value);
	}
	
	public int meditationCount {
		get {
			return _meditationCount;
		}
		set {
			_meditationCount = value;
		}
	}
}
