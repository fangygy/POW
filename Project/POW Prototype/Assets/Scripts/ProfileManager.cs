using UnityEngine;
using System.Collections;

public class ProfileManager : MonoBehaviour {
	private bool show;
	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		show = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			show = !show;
			gameObject.SetActive(show);
		}
	}
}
