using UnityEngine;
using System.Collections;

public class ServerTest : MonoBehaviour {
	public UILabel temp;
	void Start(){
		StartCoroutine (RequestServer ());
	}
	IEnumerator RequestServer(){
		WWW serverWWW = new WWW ("http://52.78.92.53:8080/Test/");
		yield return serverWWW;
		if (string.IsNullOrEmpty (serverWWW.error)) {
			temp.text = serverWWW.text;
		} else {
			temp.text = serverWWW.error;
		}

	}
}
