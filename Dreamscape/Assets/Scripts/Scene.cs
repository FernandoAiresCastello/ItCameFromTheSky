using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Scene : MonoBehaviour
{
	public string title = "Undefined";
	public Color foreColor = new Color(1,1,1,1);
	public Color backColor = new Color(0,0,0,1);
	public Color spriteColor = new Color(1,1,1,1);
	
	void Start()
	{
		UpdateLevel();
	}
	
	void UpdateLevel()
	{
		var titleText = GameObject.Find("TitleText").GetComponent<Text>();
		titleText.text = title;
		var camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		camera.backgroundColor = backColor;
		RenderSettings.ambientLight = foreColor;
		var objs = FindObjectsOfType<GameObject>();
		foreach (var obj in objs) {
			var spriteRenderer = obj.GetComponent<SpriteRenderer>();
			if (spriteRenderer != null) {
				spriteRenderer.color = spriteColor;
			}
		}
	}
}
