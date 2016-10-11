using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class startbutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnStartClick()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
}
