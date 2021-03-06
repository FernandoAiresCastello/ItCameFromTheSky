﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPouch : MonoBehaviour
{
	public int gold = 100;
	
	private AudioSource audioSource;
	
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	void Start()
	{
	}

	void Update()
	{
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Player")) {
			Player player = col.gameObject.GetComponent<Player>();
			player.gold += gold;
			DestroySelf();
		}
	}

	void DestroySelf()
	{
		audioSource.Play();
		GetComponent<Collider>().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
		Destroy(gameObject, audioSource.clip.length);
	}
}
