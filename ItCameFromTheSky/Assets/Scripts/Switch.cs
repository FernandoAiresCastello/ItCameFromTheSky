using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
	public Texture switchedTexture;
	public bool disabled = false;
	
	private bool switched = false;
	private AudioSource audioSource;
	private Material mat;
	private SwitchManager mgr;
	
	public bool IsActive
	{
		get { return disabled || switched; }
	}
	
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		mat = GetComponent<Renderer>().material;
		mgr = transform.parent.gameObject.GetComponent<SwitchManager>();
	}
	
	void OnCollisionEnter(Collision col)
	{
		Activate();
	}
	
	void Activate()
	{
		if (!switched) {
			audioSource.Play();
			mat.mainTexture = switchedTexture;
			switched = true;
		}
	}
}
