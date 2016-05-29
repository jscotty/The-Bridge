using UnityEngine;
using System.Collections;

public class NeuroskyTest : MonoBehaviour {

	[SerializeField]
	private TGCConnectionController _neurosky;

	void Start(){
		//_neurosky.UpdateDeltaEvent += RawDataInt;
		//_neurosky.UpdateDeltaEvent += RawDataFloat;
	}

	void RawDataInt(int value){
		Debug.Log(value);
	}
	void RawDataFloat(float value){
		Debug.Log(value);
	}
}
