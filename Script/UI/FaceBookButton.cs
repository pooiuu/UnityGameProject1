using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Facebook.Unity;

public class FaceBookButton : MonoBehaviour {
    
	public UILabel temp;
	public static AccessToken currentToken;
	string [] result;
	bool isThereWord = false;

	void Awake(){
		FB.Init (SetInit, OnHideUnity);
	}
	void SetInit(){
		if (FB.IsLoggedIn) {
			Debug.Log ("FB is logged in");	

		} else {
			Debug.Log ("FB is not logged in");
		}
	}
	void OnHideUnity(bool isGameShown){
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void FBlogin(){
		List<string> permissions = new List<string> ();
		permissions.Add ("public_profile");	
		FB.LogInWithReadPermissions (permissions, AuthCallBack);
	}

	void AuthCallBack(IResult result){
		if (result.Error != null) {
			Debug.Log (result.Error);	
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged in");
				currentToken = AccessToken.CurrentAccessToken;
				ToGameScene (3);
				Debug.Log (currentToken.UserId);
//				StartCoroutine (RequestServer ());

			} else {
				Debug.Log ("FB is not logged in");
			}
		}
	}

	void ToGameScene(int index){
		SceneManager.LoadScene (index);
	}

//	IEnumerator RequestServer(){
//		WWW serverWWW;
//		string FB_ID = AccessToken.CurrentAccessToken.UserId;
//		serverWWW = new WWW ("52.78.92.53:8080/Test/?ID="+FB_ID);
//		yield return serverWWW;
//		yield return StartCoroutine (ID_Check(serverWWW));
//	}
//
//	IEnumerator ID_Check(WWW serverWWW){
//		result = serverWWW.text.Split ('&');
//		yield return result;
//		temp.text = result [1];
//		isThereWord = result [1].Contains ("No Data");
//		if (string.IsNullOrEmpty (serverWWW.error)) {
//			if (!isThereWord) {	
//				ToGameScene (1);
//			} else {
//				ToGameScene (2);
//			}
//		} 
//	}

}
