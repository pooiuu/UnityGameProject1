using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score_UI : MonoBehaviour {

	UILabel text;

	// Use this for initialization
	void Start () {
		text = GetComponent<UILabel> ();
	}
		
	// Update is called once per frame
	void Update () {
		text.text = GeneralScript.Score.ToString ();
	}
}
