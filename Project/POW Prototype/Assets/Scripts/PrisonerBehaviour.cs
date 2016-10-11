using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PrisonerBehaviour : MonoBehaviour {

	public GameObject journal;
	public Text profile;
	public string PrisonerName;
	public GameObject GameManager;
	private bool hidingJournal = false;	// this is for resolving the animation confliction
	private List<string> prisonerData;

	// Use this for initialization
	void Start()
	{
		/*if (prisonerData == null)
		{
			prisonerData = new List<string>();
		}*/

		if( GameManager!=null)
			prisonerData = GameManager.GetComponent<GameManager>().getPrisonerDataOf(PrisonerName);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (journal == null)
			journal = GameObject.Find("Journal");
		if (profile == null)
			profile = GameObject.Find("Profile").GetComponent<Text>();
		if (GameManager == null)
		{
			
			GameManager = GameObject.Find("GameManager");
			if (prisonerData == null)
			{
				prisonerData = GameManager.GetComponent<GameManager>().getPrisonerDataOf(PrisonerName);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		
			hidingJournal = false;
		profile.text = "<b>Prisoner#: </b>"+prisonerData[0]+'\n'
				+"<b>Name: </b>"+prisonerData[1]+'\n'
				+"<b>Age: </b>"+prisonerData[2]+'\n'
				+"<b>Rank: </b>"+prisonerData[3]+'\n'
				+"<b>Info: </b>"+prisonerData[4]+'\n'
				+"<b>Health Condition: </b>"+prisonerData[5]+'\n';
			StartCoroutine("ShowJournal");

	}

	void OnTriggerExit2D(Collider2D other){
		hidingJournal = true;
		StartCoroutine("HideJournal");
	}

	IEnumerator ShowJournal(){
		while (journal.transform.position.y < 200f && !hidingJournal) {
			journal.transform.Translate(0,100f,0);
			yield return null;
		}
	}

	IEnumerator HideJournal(){
		while (journal.transform.position.y > -200f) {
			journal.transform.Translate(0,-100f,0);
			yield return null;
		}
	}
}
