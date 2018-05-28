using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheStrip : MonoBehaviour
{
	public Color color = new Color(0,0,0,1);
	public float maximumDistance = 0.0f;
	public Vector3 offsetDirection = new Vector3(0.05f, 0, 0);
	public Vector3 offsetScale = new Vector3(0, 1, 0);
	public float maximumScale = 20.0f;
	public bool dying = false;
	
	private Vector3 initialPos;
	private Vector3 initialScale;
	private bool sceneChanged = false;
	
	void Start()
	{
		initialPos = transform.position;
		initialScale = transform.localScale;
	}
	
	void Update()
	{
		foreach (Transform child in transform) {
			SpriteRenderer rend = child.gameObject.GetComponent<SpriteRenderer>();
			if (dying) {
				rend.color = Color.Lerp(Color.black, Color.white, Mathf.PingPong(Time.time, 1));
				if (!sceneChanged) {
					sceneChanged = true;
					Scene s = GameObject.Find("Scene").GetComponent<Scene>();
					s.SetStyle(Color.red, Color.red, Color.white, Color.black);
					s.PlaySubTrack();
				}
			}
			else
				rend.color = color;
		}

		transform.position += offsetDirection;
		if (Vector3.Distance(transform.position, initialPos) >= maximumDistance) {
			transform.position = initialPos;
		}

		transform.localScale += offsetScale;
		if (Vector3.Distance(transform.localScale, initialScale) >= maximumScale)
			transform.localScale = initialScale;
	}
}
