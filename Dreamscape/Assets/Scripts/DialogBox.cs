using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {
	
	public bool startHidden = true;

	private Text dialogText;
	
	void Awake()
	{
		dialogText = GameObject.Find("DialogText").GetComponent<Text>();
	}
	
	void Start()
	{
		if (startHidden)
			Hide();
	}
	
	void Update()
	{
	}
	
	public void Hide()
	{
		transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	public void Show()
	{
		transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}
	
	public void Show(string text)
	{
		SetText(text);
		Show();
	}
	
	public void Show(string text, Color color)
	{
		SetColor(color);
		Show(text);
	}
	
	public void SetText(string text)
	{
		dialogText.text = text;
	}
	
	public void Clear()
	{
		GameObject.Find("DialogText").GetComponent<Text>().text = "";
	}
	
	public void SetColor(Color color)
	{
		dialogText.color = color;
	}
}
