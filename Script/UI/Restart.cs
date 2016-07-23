using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Facebook.Unity;
public class Restart : MonoBehaviour {
	public UILabel label;
	void Start(){
		label.text = GeneralScript.Score.ToString();
		if (FB.IsLoggedIn) {
			StartCoroutine (RequestServer ());
		}
	}
	public void Click(){

		SceneManager.LoadScene (1);

	}
	IEnumerator RequestServer(){
		string FB_ID = FaceBookButton.currentToken.UserId;
		//마지막 플레이 시간을 나타낸다.
		System.DateTime end_time = System.DateTime.Now;         
		string date = end_time.ToString ("yyyy-MM-dd");
		string HMS = end_time.ToString ("HH:mm:ss");
		WWW serverWWW = new WWW ("http://52.78.92.53:8080/Test/gameover.jsp?ID=" + FB_ID + "&date=" + date + "&hour=" + HMS + "&score=" + GeneralScript.Score);
		yield return serverWWW;
		if (string.IsNullOrEmpty (serverWWW.error)) {
			SceneManager.LoadScene (1);
		} else {
			Debug.Log (serverWWW.error);
		}
	}
}
