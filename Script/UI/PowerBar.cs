using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

	public Scrollbar powerBar;
	ShootArrow shoot_arrow;
	// Use this for initialization
	void Start () {
		shoot_arrow = GetComponent<ShootArrow> ();
	}
	
	// Update is called once per frame
	void Update () {
		powerBar.size = shoot_arrow.Power / 2500f;
	}
}
