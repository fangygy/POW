using UnityEngine;
using System.Collections;

public class JustToKeepUIAlive : MonoBehaviour {
	private static JustToKeepUIAlive instance = null;
	// Use this for initialization
	void Awake()
	{ 
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(this.gameObject);
			return;
		}


	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
