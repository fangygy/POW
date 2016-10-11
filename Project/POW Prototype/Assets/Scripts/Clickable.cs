using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
public class Clickable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnMouseOver()
	{
		transform.localScale = new Vector3(0.2f, 0.84f, 0.84f);
	}
	void OnMouseExit()
	{ 
	}
	public void OnButtonClick()
	{
		if (gameObject.name.Substring(0, gameObject.name.Length - 1) == "Task")
		{
			int index = Int32.Parse(gameObject.name.Substring(gameObject.name.Length - 1));
			GetComponentInParent<TaskBoardManager>().Toggle(index);
			GetComponentInParent<TaskBoardManager>().UpdateTaskBoard();
		}
	
		//GetComponentInParent<TaskBoardManager>().tasks
	}
	public void OnDeleteClick()
	{
		int index = Int32.Parse(gameObject.name.Substring(gameObject.name.Length - 1));
		GetComponentInParent<TaskBoardManager>().DeleteTask(index);
	}
}
