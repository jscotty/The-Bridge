using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

	public static bool isLoading = true;
	public GameObject loadScreen;

	void Start(){
	}

	void Update(){
		if (isLoading) {
			loadScreen.SetActive(true);
		} else {
			loadScreen.SetActive(false);
		}
	}
}
