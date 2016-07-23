using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class createHunter : MonoBehaviour {


	public UILabel nick_field;
	public UILabel warning_field;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ButtonClick(){
		StartCoroutine (RequestServer());
	}
	IEnumerator RequestServer(){
		string FB_ID = FaceBookButton.currentToken.UserId;
		string nick_name = nick_field.text;
		string[] result;
		System.DateTime time = System.DateTime.Now;
		string date = time.ToString ("yyyy-MM-dd");
		string HMS = time.ToString ("HH:mm:ss");
		Debug.Log (FB_ID + " " + nick_name + " " + date);
		WWW serverWWW = new WWW ("http://52.78.92.53:8080/Test/create.jsp?id="+FB_ID+"&nick="+nick_name+"&date=" + date +"&time="+HMS);
		yield return serverWWW;
		result = serverWWW.text.Split ('&');
		Debug.Log (result [1]);
		if (string.IsNullOrEmpty (serverWWW.error)) {
			Debug.Log ("연결됨");
			if(result[1].Contains("Overlap data")){
				warning_field.text = "Name is already taken!";
			}else{
				SceneManager.LoadScene (1);
			}
		} else {
			Debug.Log (serverWWW.error);
		}

	}

}
