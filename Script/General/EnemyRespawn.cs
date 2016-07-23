using UnityEngine;
using System.Collections;

public class EnemyRespawn : MonoBehaviour {

	public GameObject Enemy;
	float ran_second;
	bool create = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (create) {
			StartCoroutine (Respawn ());
		}
		
	}
	IEnumerator Respawn(){
		ran_second = Random.Range (3.5f, 4.5f);
		create = false;
		Instantiate (Enemy, transform.position, Quaternion.Euler (0, 0, 0));
		yield return new WaitForSeconds (ran_second);
		create = true;
	}
}
