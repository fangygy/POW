using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UpdateWorld : MonoBehaviour {
	private List<string> per_pref;
	// Use this for initialization
	void Start () {
		/*
		per_pref = GameObject.Find("GameManager").GetComponent<GameManager>().inter.per_prefs;
		foreach (string obj in per_pref)
		{
			if (obj == "Cigarette")
			{
				GameObject.Find("Cigarette").SetActive(false);
				GameObject.Find("James").SetActive(false);
			}
			if (obj == "Skull")
			{
				GameObject.Find(obj).GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameManager").GetComponent<GameManager>().pepe;
			}
			if (obj == "Chair")
			{
				GameObject.Find(obj).transform.position = new Vector3(-13.5f, 5.8f, 0.0f);
			}
			if (obj == "Toilet")
			{
				GameObject.Find(obj).GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameManager").GetComponent<GameManager>().hole;
				GameObject.Find(obj).GetComponent<InteractableObjects>().context = "The toilet is gone! But there's a hole on the floor!";
			}

		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
