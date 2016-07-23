using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	GameObject coll_obj;
	Rigidbody2D rigid2D;
	bool limit = false;
	Quaternion rotate;
	Vector3 pos;
	float m_speed;

	// Use this for initialization
	void Start () {

		rigid2D = GetComponent<Rigidbody2D> ();
		rigid2D.constraints = RigidbodyConstraints2D.None;
		pos = transform.position;
		rotate = transform.rotation;
	}
	
	void FixedUpdate () {
	

		if (limit == false) {
			pos = transform.position;
			rotate = transform.rotation;
			Vector3 target;
			target.x = rigid2D.velocity.x;
			target.y = rigid2D.velocity.y;
			target.z = 0;
			Vector3 dir = target - transform.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		} else {
			if(coll_obj != null){
				m_speed = coll_obj.GetComponent<Normal_Ememy>().speed;
				Debug.Log(m_speed);
			}
			rigid2D.constraints = RigidbodyConstraints2D.FreezeAll;
			transform.Translate(Vector3.left * m_speed * Time.deltaTime, Space.World);
			StartCoroutine(banish());
		}
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.transform.tag != "Arrow" && !limit) {
			limit = true;
			if(coll.transform.tag == "HitPoint"){
				coll_obj = coll.gameObject;

			}

		}

	}
	IEnumerator banish(){
		yield return new WaitForSeconds(1f);
		Destroy (transform.gameObject);
	}
}
