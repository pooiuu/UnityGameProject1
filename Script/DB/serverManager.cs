using UnityEngine;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.Networking;


public class serverManager : MonoBehaviour {


	string [] result;
	// Use this for initialization
	void Start () {
		StartCoroutine (RequestServer ());
	}
	
	// Update is called once per frame
	void Update () {
	 
	}
	IEnumerator RequestServer(){
		string ID = "pooiuu";
		string url = "52.78.92.53:8080/Test/?ID=" + ID;
		WWW serverWWW = new WWW (url);
		yield return serverWWW;
		string text = serverWWW.text;
		result = text.Split ('&');
		if (string.IsNullOrEmpty (serverWWW.error)) {
			Debug.Log (result[1]);


		} else {
			Debug.Log(serverWWW.error);
		}
	}

}
