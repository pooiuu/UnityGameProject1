using UnityEngine;
using System.Collections;
using Spine.Unity;
public class ShootArrow : MonoBehaviour {
	public GameObject aim;
	public GameObject spine;
	public GameObject arrow;
	public GameObject Gun;
	public float Power = 0;
	public SkeletonAnimation skel;
	string cur_anim = " ";
	Vector3 target_Pos;
	bool Reload = false;

	bool touch_start = false;
	bool ready_shoot = false;
	bool shooting = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			touch_start = true;
		} else if (Input.touchCount == 0) {
			touch_start = false;
		}

		if (touch_start) {
			if (Input.GetTouch (1).phase == TouchPhase.Began) {
				ready_shoot = true;
			}
		} else {
			ready_shoot = false;
			Power = 0;
		}

		if (ready_shoot && !Reload) {
			if(Power < 2500){
				Power += 100;
			}
			if(Input.GetTouch(1).phase == TouchPhase.Ended){
				shooting = true;
			}
		}
	}
	void FixedUpdate(){
		if (touch_start) {
			Vector3 aim_pos = aim.transform.position;
			Vector2 temp_pos = Input.GetTouch (0).position;
			target_Pos = new Vector3 (temp_pos.x, temp_pos.y, 0);
			Vector3 cam_pos = Camera.main.ScreenToWorldPoint (target_Pos);

			float dy, dx, degree;
			dy = cam_pos.y - aim_pos.y;
			dx = cam_pos.x - aim_pos.x;
			degree = Mathf.Atan2 (dy, dx) * Mathf.Rad2Deg;
			spine.transform.rotation = Quaternion.Euler (0, 0f, degree);
			if (ready_shoot && shooting && !Reload) {
				GameObject clone;
				setAnimation ("Shot",false);
				clone = (GameObject)Instantiate (arrow, Gun.transform.position, Quaternion.Euler (0, 0f, degree));
				Vector2 shoot_dir = new Vector2 (dx, dy);
				shoot_dir = shoot_dir.normalized;
				clone.GetComponent<Rigidbody2D> ().AddForce (shoot_dir * Power);
				Power = 0;
				Reload = true;
				ready_shoot = false;
				shooting = false;
				StartCoroutine (arrowReload ());

			}
		}


	}
	IEnumerator arrowReload(){
		yield return new WaitForSeconds(1);
		setAnimation ("Idle", true);
		Reload = false;
	}
	void setAnimation(string name, bool loop){
		if (cur_anim == name) {
			return;
		} else {
			skel.state.SetAnimation (0, name, loop);
			cur_anim = name;
		}
	}
}
