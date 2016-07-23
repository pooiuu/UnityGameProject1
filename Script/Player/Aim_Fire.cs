using UnityEngine;
using System.Collections;

public class Aim_Fire : MonoBehaviour {
	public GameObject aim;
	public GameObject arrow;
	public GameObject Gun;
	public float Power = 0;
	Vector3 target_Pos;

	bool Reload = false;
	bool buttonDown = false;
	bool buttonUp = false;
	// Use this for initialization
	void Start () {
	}

	void Update(){
		if (!Reload) {
			if (Input.GetMouseButton (0)) {
				buttonDown = true;
				buttonUp = false;
			}
			if (Input.GetMouseButton(1)) {
				if(Power < 2500){
					Power += 100;
				}

			}else if(Input.GetMouseButtonUp(1)){
				buttonDown = false;
				buttonUp = true;
			}
		}
		Debug.Log (Power);
	}
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 aim_pos = aim.transform.position;
		target_Pos = Input.mousePosition;
		target_Pos.z = aim_pos.z;
		Vector3 cam_pos = Camera.main.ScreenToWorldPoint (target_Pos);

		float dy;
		float dx;
		float degree;
		
		dy = cam_pos.y - aim_pos.y;
		dx = cam_pos.x - aim_pos.x;
		degree = Mathf.Atan2 (dy, dx) * Mathf.Rad2Deg;
		aim.transform.rotation = Quaternion.Euler (0, 0f, degree);
		if (buttonDown) {


//			if (Power < 2500)
//				Power += 100;

		} 
		else if (buttonUp) {
			GameObject clone;

			clone = (GameObject)Instantiate (arrow, Gun.transform.position, Quaternion.Euler (0, 0f, degree));
			Vector2 shoot_dir = new Vector2(dx,dy);
			shoot_dir = shoot_dir.normalized;
			clone.GetComponent<Rigidbody2D> ().AddForce (shoot_dir * Power);
			Power = 0;
			Reload = true;
			buttonUp = false;
			StartCoroutine (arrowReload ());
		}

	}
	IEnumerator arrowReload(){
		yield return new WaitForSeconds(1);
		Reload = false;
	}
}

