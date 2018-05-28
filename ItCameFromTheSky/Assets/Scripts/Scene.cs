using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class Scene : MonoBehaviour
{
	public string title = "Undefined";
	public Color foreColor = new Color(1,1,1,1);
	public Color backColor = new Color(0,0,0,1);
	public Color spriteColor = new Color(1,1,1,1);
	public Color fogColor = new Color(0,0,0,1);
	public AudioClip mainTrack;
	public AudioClip subTrack;
	
	private Camera camera;
	private AudioSource audioSource;
	
	void Awake()
	{
		camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		audioSource = GetComponent<AudioSource>();
	}
	
	void Start()
	{
		StyleScene();
		
		if (Application.isPlaying) {
			audioSource.loop = true;
			audioSource.clip = mainTrack;
			audioSource.Play();
		}
	}
	
	void StyleScene()
	{
		var titleText = GameObject.Find("TitleText");
		if (titleText != null)
			titleText.GetComponent<Text>().text = title;
		
		SetStyle(foreColor, backColor, fogColor, spriteColor);

	}
	
	public void SetStyle(Color foreColor, Color backColor, Color fogColor, Color spriteColor)
	{
		RenderSettings.ambientMode = AmbientMode.Flat;
		RenderSettings.skybox = null;
		RenderSettings.fog = true;
		RenderSettings.ambientLight = foreColor;
		RenderSettings.fogColor = fogColor;
		camera.backgroundColor = backColor;
		
		var objs = FindObjectsOfType<GameObject>();
		foreach (var obj in objs) {
			var spriteRenderer = obj.GetComponent<SpriteRenderer>();
			if (spriteRenderer != null) {
				spriteRenderer.color = spriteColor;
			}
		}
	}
	
	public void PlaySubTrack()
	{
		audioSource.Stop();
		audioSource.clip = subTrack;
		audioSource.Play();
	}
}
