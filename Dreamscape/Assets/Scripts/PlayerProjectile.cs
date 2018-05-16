using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
	
	public float speed = 0.4f;
	public float maxDistance = 10.0f;
	public List<Sprite> sprites;
	
	private Vector3 initialPosition;
	private AudioSource audioSource;
	private int spriteIndex = 0;
	private SpriteRenderer rend;

	void Awake() {
		initialPosition = transform.position;
		rend = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}
	
	void Update () {
		rend.sprite = sprites[spriteIndex++];
		if (spriteIndex >= sprites.Count) {
			spriteIndex = 0;
		}
		transform.Translate(0, 0, speed);
		float dist = Vector3.Distance(initialPosition, transform.position);
		if (dist > maxDistance) {
			Destroy(gameObject);
		}
	}
}
