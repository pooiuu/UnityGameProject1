using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Spine.Unity;
public class Normal_Ememy : MonoBehaviour {

	public SkeletonAnimation skel;
	string cur_anim = "";
	public enum MonsterState{
		Walk, Death, Hit
	}
	public 
	MonsterState m_State;
	public int health = 4;
	public float speed = 10;
	// Use this for initialization
	void Start () {
		m_State = MonsterState.Walk;
	}
	
	// Update is called once per frame
	void Update () {

		if (m_State != MonsterState.Death) {
			setAnimation ("Walk", true);
			if (m_State == MonsterState.Hit) {
				health--;
				if (health > 0) {
					m_State = MonsterState.Walk;
				} else {
					m_State = MonsterState.Death;
				}
			} else {
				m_State = MonsterState.Walk;
			}
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		} else {
			speed = 0;
			setAnimation ("Death", false);
			StartCoroutine(getScore());
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		Debug.Log (transform.tag);
		if (coll.transform.tag == "Arrow" && m_State != MonsterState.Death) {
			m_State = MonsterState.Hit;
		}
		if (coll.transform.tag == "Player" && m_State != MonsterState.Death) {
			SceneManager.LoadScene (4);
		}
	}
	IEnumerator getScore(){
		
		yield return StartCoroutine (banish());
	}
	IEnumerator banish(){

		yield return new WaitForSeconds (1.5f);
		GeneralScript.Score += 10;
		Destroy (this.gameObject);
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
