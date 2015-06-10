using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	[SerializeField]
	private TGCConnectionController _tgcc;

	private SpriteRenderer _spriteRen;

	private float r = 1f,g = 1f,b = 1f;
	private int _mediCount,_attentionCount,_count;

	void Start () {
		_spriteRen = GetComponent<SpriteRenderer>();
		if(_tgcc != null){
			_tgcc.UpdateAttentionEvent += ReturnDelAttention;
		}
	}

	void Update () {
		if(_tgcc != null){

			if(_count < _attentionCount){
				_count ++;
				r += 0.03f;
				g += 0.03f;
				b += 0.03f;
			} else if(_count > _attentionCount){
				_count --;
				r -= 0.03f;
				g -= 0.03f;
				b -= 0.03f;
			} else if(_count == _attentionCount){

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
		_attentionCount = value;
	}
}
