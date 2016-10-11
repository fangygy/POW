using UnityEngine;
using System.Collections;

public class JustShakeIt : MonoBehaviour {

	// Use this for initialization
	// For Calendar Shake
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnLevelWasLoaded()
	{
		StartCoroutine("DropAndShake");
	}
	IEnumerator DropAndShake()
	{ 
		while (Vector3.Distance(transform.position, new Vector3(512f, 700f, 0f)) > 0.01)
		{
			float step = 150 * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(512f, 700f, 0f), step);
			yield return null;
		}
		int i = 3;
		while (i >0)
		{
			while (Vector3.Distance(transform.position, new Vector3(512f, 700-i*2, 0f)) > 0.01)
			{
				float step = (i*40) * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(512f, 700-i*2, 0f), step);
				yield return null;
			}
			while (Vector3.Distance(transform.position, new Vector3(512f, 700+i*2, 0f)) > 0.01)
			{
				float step = (i*40) * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(512f, 700+i*2, 0f), step);
				yield return null;
			}
			i--;
			//yield return null;
		}

	}
}
