using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using System;
public class GameManager: MonoBehaviour
{
	public TextAsset peterFile;
	public TextAsset edwardFile;
	public TextAsset jamesFile;
	public TextAsset log_file;
	private List<string> peterData;
	private List<string> edwardData;
	private List<string> jamesData;
	private List<string> game_log;
	private List<GameObject> reported_list;
	//player value
	private int inmate_val;
	private int watcher_val;
	private int hunger_val;

	private int day_num;
	private string jsonString;
	private TaskBoardManager tbm;
	public string saveFileName;

	public GameObject inter_box;
	public Text todaysTask;
	public Text task_list;
	private int task_count;
	public Text context;
	public Text profile;
	public Text playerStats_display;
	public Text day_display;
	private GameObject Lieutenant;
	public GameObject ReportBoard;
	public Text reportContent;
	public Text rewardContent;
	private bool boardHidden;
	private bool jamesFound;
	private bool skullFound;
	private bool chairFound;
	private bool peterFound;

	//for verticalslice
	// the initialization has to be placed in Awake() because we want to make sure when each prisoner calls
	// getPrisonerDataOf() to get their own data, the corresponding data has already been loaded. If we put
	// this in Start(), we can't guarantee the loading order.
	[System.Serializable]
	public class Interactions
	{
		public List<string> objs;
		public List<string> per_prefs;
	}
	public Interactions inter;
	private static GameManager instance = null;
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

		peterData = new List<string>(peterFile.text.Split('\n'));
		edwardData = new List<string>(edwardFile.text.Split('\n'));
		jamesData = new List<string>(jamesFile.text.Split('\n'));
		//leave game_log as strings for flexibilities, even though it only has ints for now
		game_log = new List<string>();
		game_log.Add("0");	// day count
		game_log.Add("50");	// cellmate perception, ranged 0~100
		game_log.Add("50");	// watcher perception, ranged 0~100
		game_log.Add("50");	// hunger level, ranged 0~100
	
			
		inter = new Interactions();
		inter.objs = new List<string>();
		inter.per_prefs = new List<string>();
	}
	private string comment1 = "I am impressed by your excellent effort, lieutenant. " +
							  "Thanks to your work we were able to find out who stole the food from our kitchen. " +
							  "James will be punished for what he has done. An act like this is not tolerable in my camp. " +
							  "The execution will take place next week, all prisoners will be required to watch. " +
							  "I hope this will teach them some discipline.\n\n" +
							  "Well, here's some of my gift to you, in appreciation of your effort. " +
							  "See, it's not that hard to make your life better, right? ";
	private string reward1 = "Apple          x  2\n" +
							 "Sausage          x  1\n" +
							 "Penicillin          x  1";
	private string comment2 = "I am very disappoited by your performance today, lieutenant. " +
		"What have you been doing all day? " +
		"'There's always a human skull in a video game. I'll write it down anyway.'...What the hell is this? " +
		"I'm warning you, lieutenant, that if you keep fooling us around like this, you will regret it. " +
		"I hope you will show us something more interesting tomorrow.";
	private string reward2 = "Rotten Apple          x   1";
	private string comment3 = "I am very disappoited by your performance today, lieutenant. " +
		"What have you been doing all day? " +
		"'It's just a chair, what am I going to write about it?'...What the hell is this? " +
		"I'm warning you, lieutenant, that if you keep fooling us around like this, you will regret it. " +
		"I hope you will show us something more interesting tomorrow.";
	private string reward3 = "Rotten Apple          x   1";
	private string comment4 = "I am very disappoited by your performance today, lieutenant. " +
		"What have you been doing all day? " +
		"'Peter doesn't seem to be involved in this.'...Well I want to know who IS involved in this, not who ISN'T. " +
		"I'm warning you, lieutenant, that if you keep fooling us around like this, you will regret it. " +
		"I hope you will show us something more interesting tomorrow.";
	private string reward4 = "Rotten Apple          x   1";
	private string comment5 = "I am very disappoited by your performance today, lieutenant. " +
		"What have you been doing all day? " +
		"Your recorded nothing but useless information. " +
		"I'm warning you, lieutenant, that if you keep fooling us around like this, you will regret it. " +
		"I hope you will show us something more interesting tomorrow. ";
	private string reward5 = "Rotten Apple          x   1";
	IEnumerator ShowReportBoard(){
		//512, 1134,
		//512, 384
		boardHidden = false;
		ReportBoard.SetActive (true);
		reportContent.text = comment5;
		rewardContent.text = reward5;
		if (chairFound) {
			reportContent.text = comment3;
			rewardContent.text = reward3;
		}if (peterFound) {
			reportContent.text = comment4;
			rewardContent.text = reward4;
		}if (skullFound) {
			reportContent.text = comment2;
			rewardContent.text = reward2;
		}if (jamesFound) {
			reportContent.text = comment1;
			rewardContent.text = reward1;
		}

		while (Vector3.Distance(ReportBoard.transform.position, new Vector3(512f,384f,0f)) > 0.01)
		{
			float step = 1500 * Time.deltaTime;
			ReportBoard.transform.position = Vector3.MoveTowards(ReportBoard.transform.position, new Vector3(512f, 384, 0f),step);
			yield return null;
		}

	}
	void Start()
	{
		
		task_count = 0;
		inter_box.SetActive(false);
		reported_list = new List<GameObject>();

		try
		{
			day_num = Int32.Parse(game_log[0]);
			inmate_val = Int32.Parse(game_log[1]);
			watcher_val = Int32.Parse(game_log[2]);
			hunger_val = Int32.Parse(game_log[3]);
		}catch(FormatException e)
		{ 
			Debug.Log(e.Message);
		}
		tbm = GameObject.Find("Tasks").GetComponent<TaskBoardManager>();
		//Debug.Log(inter.per_prefs.Count);

		//Hardcoded events;
		//should it do in another script to make it more expandable
	}


	public void DeleteTaskAt(int index)
	{
		task_count--;
		Debug.Log("index is " + index);
		Debug.Log("task count is " + task_count);
		inter.objs.RemoveAt(index);
		inter.per_prefs.RemoveAt(index);
		reported_list.RemoveAt(index);
		tbm.deleteButtons[task_count].SetActive(false);
		for (int i = 0; i < task_count; i++)
		{
			tbm.tasks[i].show = true;
			tbm.tasks[i].task.GetComponentInChildren<Text>().text = reported_list[i].name;
			if(i>=index&&i<4)
				tbm.subTasks[i].show = tbm.subTasks[i + 1].show;
			tbm.subTasks[i].task.GetComponentInChildren<Text>().text=reported_list[i].GetComponent<InteractableObjects>().recordContent;;
		}

		tbm.tasks[task_count].show = false;
		tbm.tasks[task_count].task.GetComponentInChildren<Text>().text = "";
		tbm.subTasks[task_count].show = false;
		tbm.subTasks[task_count].task.GetComponentInChildren<Text>().text = "";
	

	//reported_list.RemoveAt(index);
}

	void Update()
	{
		if (Lieutenant == null)
		{
			Lieutenant = GameObject.Find("Lieutenant");
		}
		if (Input.GetKeyDown(KeyCode.Space) && Lieutenant.GetComponent<CharacterController>().GetContact())
		{
			inter_box.SetActive(true);
		
			if(Lieutenant.GetComponent<CharacterController>().GetOtherObject().GetComponent<Item>())
				context.text = Lieutenant.GetComponent<CharacterController>().GetOtherObject().GetComponent<InteractableObjects>().context + "\n\nTake item?";
			else
				context.text = Lieutenant.GetComponent<CharacterController>().GetOtherObject().GetComponent<InteractableObjects>().context + "\n\nWrite it down in the Journal?";
			Lieutenant.GetComponent<CharacterController>().SetMoveEnable(false);
		}

		int display_num = day_num + 1;
		playerStats_display.text = inmate_val + "," + watcher_val + "," + hunger_val;
		day_display.text = "Day\n" + display_num;
		if (Input.GetKeyDown(KeyCode.P))
		{
			task_count = 0;
			reported_list.Clear();
			StartCoroutine("FadeToNextDay");
		}
		if (task_count >= 5)
		{
			task_count = 0;
			reported_list.Clear();
			StartCoroutine("FadeToNextDay");
		//	GoToNextDay();
		}

	}
	void UpdatePerPref()
	{
		string temp_name = "";
		for (int i = 0; i < inter.per_prefs.Count; i++)
		{
			if (i % 2 == 0)
			{
				temp_name = inter.per_prefs[i];
			}
			else
			{
				GameObject.Find(temp_name).GetComponent<InteractableObjects>().personal_pref = Int32.Parse(inter.per_prefs[i]); 
			}

		}
	}
	IEnumerator FadeToNextDay()
	{
		GameObject.Find("FadeLayer").GetComponent<FadeManager>().FadeToBlack();
		GameObject.Find("FadeLayer").GetComponent<FadeManager>().animationSpeed = 0.5f;
		yield return new WaitForSeconds(3f);
		StartCoroutine("ShowReportBoard");
		yield return new WaitUntil(()=>boardHidden);
		yield return new WaitForSeconds(1.5f);
		GoToNextDay();
		GameObject.Find("FadeLayer").GetComponent<FadeManager>().FadeFromBlack();
		GameObject.Find("FadeLayer").GetComponent<FadeManager>().animationSpeed = 0.5f;
	
	}
	// each prisoner will call this function in Start() to have their own data loaded
	public List<string> getPrisonerDataOf(string prisonerName)
	{
		// a placeholder in case we got a non-existent prosoner name somehow
		string[] emptyPrisoner = { "0", "Pepe", "18", "General", "Pepe is a frog that brings fun to people", "Healthy" };

		// hard-coded for prototype; will develop a better organized structure in the real game
		switch (prisonerName)
		{
			case "Peter":
				return peterData;
			case "Edward":
				return edwardData;
			case "James":
				return jamesData;
			default:
				return new List<string>(emptyPrisoner);
		}
	}
	//adders
	public void AddInmateVal(int val)
	{
		inmate_val += val;
	}
	public void AddWatcherVal(int val)
	{
		watcher_val += val;
	}
	public void AddHungerVal(int val)
	{
		hunger_val += val;
	}
	public void AddPersonalVal(InteractableObjects io)
	{
		io.personal_pref += io.personalImpact;
	}
	public int GetDay()
	{
		return day_num;
	}
	// hard-coded for prototype; will develop a better organized structure in the real game
	public void LastPage(){
		if (profile.text [0].Equals('2')) {	// if at page 2 then scroll to page 1
			profile.text = peterData[0]+'\n'
				+"<b>Name: </b>"+peterData[1]+'\n'
				+"<b>Age: </b>"+peterData[2]+'\n'
				+"<b>Rank: </b>"+peterData[3]+'\n'
				+"<b>Info: </b>"+peterData[4]+'\n'
				+"<b>Health Condition: </b>"+peterData[5]+'\n';
		} else if (profile.text [0].Equals('3')) {	// if at page 3 then scroll to page 2
			profile.text = edwardData[0]+'\n'
				+"<b>Name: </b>"+edwardData[1]+'\n'
				+"<b>Age: </b>"+edwardData[2]+'\n'
				+"<b>Rank: </b>"+edwardData[3]+'\n'
				+"<b>Info: </b>"+edwardData[4]+'\n'
				+"<b>Health Condition: </b>"+edwardData[5]+'\n';
		}
	}

	// hard-coded for prototype; will develop a better organized structure in the real game
	public void NextPage(){
		if (profile.text [0].Equals('2')) {	// if at page 2 then scroll to page 3
			profile.text = jamesData[0]+'\n'
				+"<b>Name: </b>"+jamesData[1]+'\n'
				+"<b>Age: </b>"+jamesData[2]+'\n'
				+"<b>Rank: </b>"+jamesData[3]+'\n'
				+"<b>Info: </b>"+jamesData[4]+'\n'
				+"<b>Health Condition: </b>"+jamesData[5]+'\n';
		} else if (profile.text [0].Equals('1')) {	// if at page 1 then scroll to page 2
			profile.text = edwardData[0]+'\n'
				+"<b>Name: </b>"+edwardData[1]+'\n'
				+"<b>Age: </b>"+edwardData[2]+'\n'
				+"<b>Rank: </b>"+edwardData[3]+'\n'
				+"<b>Info: </b>"+edwardData[4]+'\n'
				+"<b>Health Condition: </b>"+edwardData[5]+'\n';
		}
	}
	void GoToNextDay()
	{
	//	jsonString = JsonUtility.ToJson(inter);//StreamWriter sw = File.CreateText(saveFileName);
	//	StreamWriter sw = new System.IO.StreamWriter(Application.persistentDataPath + "/" + saveFileName);
	//	sw.WriteLine(jsonString);
	//	sw.Close();
		day_num++;
		//task_list.text = "";
		if (day_num == 1) {
			todaysTask.text = "Some prisoners are planning on escaping. Find out some evidences.";
		} else if (day_num == 2) {
			todaysTask.text = "Report any suspicious activities.";
		} else {
			todaysTask.text = "";
		}

		game_log[0] = day_num.ToString();
		game_log[1] = inmate_val.ToString();
		game_log[2] = watcher_val.ToString();
		game_log[3] = hunger_val.ToString();

		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
		tbm.ResetTaskBoard();
	}

	public void OnNoButtonClicked()
	{
		Lieutenant.GetComponent<CharacterController>().SetMoveEnable(true);
		inter_box.SetActive(false);
	}
	public void OnYesButtonClicked()
	{
		GameObject other_obj = Lieutenant.GetComponent<CharacterController>().GetOtherObject();
		InteractableObjects obj_inter = other_obj.GetComponent<InteractableObjects>();
		if (other_obj.GetComponent<Item>())
		{
			GameObject.Find("Slots").GetComponent<Inventory>().AddItem(other_obj.name);
		}
		else if (other_obj&&!reported_list.Contains(other_obj))
		{
			AddHungerVal(obj_inter.hungerImpact);
			AddInmateVal(obj_inter.inmateImpact);
			AddWatcherVal(obj_inter.watcherImpact);
			AddPersonalVal(obj_inter);
			tbm.tasks[task_count].show = true;
			tbm.tasks[task_count].task.GetComponentInChildren<Text>().text = other_obj.name;
			tbm.subTasks[task_count].task.GetComponentInChildren<Text>().text = obj_inter.recordContent;
			tbm.UpdateTaskBoard();
			task_count++;
				//	task_list.text += "\n" + task_count + ". " + other_obj.GetComponent<InteractableObjects>().recordContent;
			reported_list.Add(other_obj);
			inter.objs.Add(obj_inter.name);
			inter.objs.Add(obj_inter.context);
			inter.objs.Add(obj_inter.inmateImpact.ToString());
			inter.objs.Add(obj_inter.watcherImpact.ToString());
			inter.objs.Add(obj_inter.hungerImpact.ToString());
			inter.per_prefs.Add(obj_inter.name);
			inter.per_prefs.Add(obj_inter.personal_pref.ToString());
			if (obj_inter.name == "Peter") {
				peterFound = true;
			}if (obj_inter.name == "James") {
				jamesFound = true;
			}if (obj_inter.name == "Chair") {
				chairFound = true;
			}if (obj_inter.name == "Skull") {
				skullFound = true;
			}
		}
		Lieutenant.GetComponent<CharacterController>().SetMoveEnable(true);
		inter_box.SetActive(false);
	}

	public void hideReportBoard(){
		//ReportBoard.SetActive (false);
		boardHidden = true;
		StartCoroutine("HideBoard");
	}

	IEnumerator HideBoard()
	{
		while (Vector3.Distance(ReportBoard.transform.position, new Vector3(512f, 1134f, 0f)) > 0.01)
		{
			float step = 1500 * Time.deltaTime;
			ReportBoard.transform.position = Vector3.MoveTowards(ReportBoard.transform.position, new Vector3(512f, 1134f, 0f), step);
			yield return null;
		}
	}
}


