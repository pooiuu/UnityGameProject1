using UnityEngine;
using System.Collections;

public class GeneralScript : MonoBehaviour {

	private static GeneralScript generalInstance;
	private GeneralScript(){}

	public static int Score;
	void Start(){
		Score = 0;
	}
}
