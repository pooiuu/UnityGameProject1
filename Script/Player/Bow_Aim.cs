using UnityEngine;
using System.Collections;

public class Bow_Aim : MonoBehaviour {

	public Transform arrowHead;
	//배
	public Transform spine2;

	Vector3 Mouse_pos;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Mouse_pos = Input.mousePosition;
		Vector3 cam_pos = Camera.main.ScreenToWorldPoint (Mouse_pos);
		float dx = cam_pos.x - arrowHead.position.x;
		float dy = cam_pos.y - arrowHead.position.y;
		float degree = Mathf.Atan2 (dy, dx) * Mathf.Rad2Deg;
		Debug.Log (degree);
		float temp_z = 0;
		if (degree <= 70 && degree >= -30) {
			spine2.rotation = Quaternion.Euler (0, 0, degree);
		}
	}
	void FixedUpdate(){


	}
}
