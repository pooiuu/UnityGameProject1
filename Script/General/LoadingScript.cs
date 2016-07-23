using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {
	string [] result;
	bool isThereWord;
	public UILabel label;


	void Start(){
		StartCoroutine (RequestServer ());

	}


	IEnumerator RequestServer(){
		
		string FB_ID = FaceBookButton.currentToken.UserId;
		string url = "http://52.78.92.53:8080/Test/?ID=" + FB_ID;
		WWW serverWWW = new WWW (url);
		yield return serverWWW;
//		yield return StartCoroutine (ID_Check(serverWWW));
		result = serverWWW.text.Split ('&');
		isThereWord = result [1].Contains ("No Data");
		yield return isThereWord;
		if (string.IsNullOrEmpty (serverWWW.error)) {
			if (!isThereWord) {	
				ToGameScene (1);
			} else {
				ToGameScene (2);
			}
		} 
	}

//	IEnumerator ID_Check(WWW serverWWW){
//		result = serverWWW.text.Split ('&');
//		yield return result;
//		isThereWord = result [1].Contains ("No Data");
//		if (string.IsNullOrEmpty (serverWWW.error)) {
//			if (!isThereWord) {	
//				ToGameScene (1);
//			} else {
//				ToGameScene (2);
//			}
//		} 
//	}
//
	void ToGameScene(int index){
		Application.LoadLevel (index);
	}

}
