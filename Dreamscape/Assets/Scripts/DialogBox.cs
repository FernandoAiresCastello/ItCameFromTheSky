using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour {

	void Start () {
		Hide();
	}
	
	void Update () {
	}
	
	public void Hide() {
		transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	public void Show() {
		transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}
}
