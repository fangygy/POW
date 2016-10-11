using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Conversation : MonoBehaviour {
	public GameObject Watcher;
	public GameObject Lieutenant;
	public GameObject DialogBox;
	public GameObject WatcherImage, LieutenantImage, MajorImage;
	public Text Dialog;
	public Button OK;
	public Text todaysTask;

	private int currentDialog = 0;
	private int currentProgress = 0;
	private float mTimer = 0f;

	// Use this for initialization
	void Start () {
		if (GetComponent<GameManager>().GetDay() == 0)
		{
			Lieutenant.GetComponent<CharacterController>().SetMoveEnable(false);
			ShowWatcherDialog(currentDialog);
			currentDialog++;
		}
		else
		{
			Lieutenant.GetComponent<CharacterController>().SetMoveEnable(true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<GameManager>().GetDay() != 0)
		{
			DialogBox.SetActive(false);
		}
	
	}

	public void OnOKClicked(){
		switch (currentProgress) {
		case 0:
			currentProgress++;
			ShowLieutenantDialog (currentDialog);
			currentDialog++;
			break;
		case 1:
			currentProgress++;
			ShowWatcherDialog (currentDialog);
			currentDialog++;
			break;
		case 2:
			currentProgress++;
			StartCoroutine ("PlayAnimation0");
			break;
		case 3:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 4:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 5:
			currentProgress++;
			StartCoroutine ("PlayAnimation1");
			break;
		case 6:
			currentProgress++;
			ShowLieutenantDialog (currentDialog);
			currentDialog++;
			break;
		case 7:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 8:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 9:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 10:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 11:
			currentProgress++;
			ShowLieutenantDialog (currentDialog);
			currentDialog++;
			break;
		case 12:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 13:
			currentProgress++;
			ShowLieutenantDialog (currentDialog);
			currentDialog++;
			break;
		case 14:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 15:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 16:
			currentProgress++;
			ShowLieutenantDialog (currentDialog);
			currentDialog++;
			break;
		case 17:
			currentProgress++;
			ShowLieutenantDialog (currentDialog);
			currentDialog++;
			break;
		case 18:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 19:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 20:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 21:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 22:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 23:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 24:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 25:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 26:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 27:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 28:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 29:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 30:
			currentProgress++;
			ShowLieutenantDialog (currentDialog);
			currentDialog++;
			break;
		case 31:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 32:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 33:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 34:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 35:
			currentProgress++;
			ShowLieutenantDialog (currentDialog);
			currentDialog++;
			break;
		case 36:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 37:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 38:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 39:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 40:
			currentProgress++;
			ShowLieutenantDialog (currentDialog);
			currentDialog++;
			break;
		case 41:
			currentProgress++;
			ShowLieutenantDialog (currentDialog);
			currentDialog++;
			break;
		case 42:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 43:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 44:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 45:
			currentProgress++;
			ShowMajorDialog (currentDialog);
			currentDialog++;
			break;
		case 46:
			currentProgress++;
			StartCoroutine ("PlayAnimation2");
			break;
		default:
			break;
		}
	}

	IEnumerator PlayAnimation0(){
		Lieutenant.GetComponent<CharacterController>().SetMoveEnable(false);
		DialogBox.SetActive (false);
		while (Lieutenant.GetComponent<RectTransform>().localPosition.y<=-300f) {
			Watcher.transform.Translate(0,0.05f,0);
			Lieutenant.transform.Translate(0,0.05f,0);
			mTimer += Time.deltaTime;
			yield return null;
		}
		while (Lieutenant.GetComponent<RectTransform>().localPosition.x>=-1001f) { 
			Watcher.transform.Translate(-0.05f,0,0);
			Lieutenant.transform.Translate(-0.05f,0,0);
			mTimer += Time.deltaTime;
			yield return null;
		}
		while (Lieutenant.GetComponent<RectTransform>().localPosition.y<=206f) { 
			Watcher.transform.Translate(0,0.05f,0);
			Lieutenant.transform.Translate(0,0.05f,0);
			mTimer += Time.deltaTime;
			yield return null;
		}
		ShowWatcherDialog (currentDialog);
		currentDialog++;
	}
	IEnumerator PlayAnimation1(){
		DialogBox.SetActive (false);
		while (Lieutenant.GetComponent<RectTransform>().localPosition.y<=616f) {
			Lieutenant.transform.Translate(0,0.05f,0);
			mTimer += Time.deltaTime;
			yield return null;
		}
		ShowMajorDialog (currentDialog);
		currentDialog++;
	}
	IEnumerator PlayAnimation2(){
		DialogBox.SetActive (false);
		while (mTimer <= 13f) {
			Lieutenant.transform.Translate(0,-0.05f,0);
			mTimer += Time.deltaTime;
			yield return null;
		}
		Lieutenant.GetComponent<CharacterController>().SetMoveEnable(true);
		todaysTask.text = "Find out who stole the potatoes from kitchen.";
	}

	void ShowMajorDialog(int i){
		DialogBox.SetActive (true);
		MajorImage.SetActive (true);
		LieutenantImage.SetActive (false);
		WatcherImage.SetActive (false);
		Dialog.text = dialogContent [i];
	}

	void ShowLieutenantDialog(int i){
		DialogBox.SetActive (true);
		MajorImage.SetActive (false);
		LieutenantImage.SetActive (true);
		WatcherImage.SetActive (false);
		Dialog.text = dialogContent [i];
	}

	void ShowWatcherDialog(int i){
		DialogBox.SetActive (true);
		MajorImage.SetActive (false);
		LieutenantImage.SetActive (false);
		WatcherImage.SetActive (true);
		Dialog.text = dialogContent [i];
	}

	private string[] dialogContent = {
		"Wake up.",
		"What time is it?\n...\n......\n4am? Jesus...",
		"Move.",
		"*Knocks on the door*\nMajor, he's here.",
		"Thank you, Private.",
		"Lieutenant, please come in.",
		"I’m sorry for having to wake you up early, lieutenant. \nBut I think it would be better to have this conversation sooner than later.",
		"I am listening.",
		"Let’s get straight to the point, lieutenant, shall we? \n My soldiers have been reporting things to me…",
		"We cut the food supplement standard by 25% one week ago, and in the past three days over ten kilograms of potatoes stored in our kitchen were reported missing. ",
		"Now, you see, lieutenant, I’m not saying your men are thieves...",
		"However, based on the rather apparent correlation between these two events, I think it is pretty safe to assume that they are… involved in this. Now, would you deny it?",
		"(Silence)",
		"(Smiles) Didn't think so.",
		"What are you going to do about it?",
		"Whoa whoa whoa whoa whoa, don’t be so impatient, lieutenant; we’ll get to it in a second. Let me ask you a question first.",
		"...How do you like the life here at the camp?",
		"There’s nothing that I like about this place.",
		"My men suffer from hunger and poor medical conditions every day, and your people do nothing about it.",
		"Well, I guess it wouldn’t sound very convincing if I say I haven’t realized that.",
		"But lieutenant, you see, if you were to look at this camp from where I’m standing, you’ll realize a lot of things.",
		"Running this place isn’t that easy - my officers just give me orders, and I have to do all the dirty job.",
		"Am I the one who decided to reduce the food supply? No. I carry out the orders, that’s it.",
		"But what your men have been doing... ",
		"is making it harder for me to carry out my orders.",
		"(Smokes)",
		"You were saying you don’t like your prisoner life? Well, I guess we could make a deal out of it...",
		"As I said, it is important for me to keep all of my prisoners disciplined. But in order to do that, I need to monitor these people. And you, lieutenant…",
		"You are the perfect candidate for this job. Your people won’t say anything valuable to the watchers, but they trust you as their leader, and will tell you everything.",
		"Your will keep an eye on them, talk to them, and report anything suspicious to me.",
		"And needless to say, do NOT blow your cover - you don’t want your comrades to wring your neck while you’re sleeping, do you?",
		"I’m not going to...",
		"What did I just say? Patience, lieutenant. Allow me to conclude my offer first.",
		"You’re certainly not doing this job for free. In appreciation of your help, we will give you some rewards - food, medications, clothes, etc - each time you provide us with valuable information.",
		"You may choose to enjoy all these stuff yourself, or you can use these to help your comrades; it’s your call.",
		"Suddenly makes you feel less guilty about it, huh?",
		"(Silence)",
		"I’d like to allow you to think about it and make your choice, lieutenant. But given the current situation, I’m afraid this time you don’t have another option.",
		"You will cooperate...",
		"...or you will be held responsible for the stolen food and hanged at sunrise.",
		"Now, would you shake my hand and seal this deal, or shall I tell the watchers outside to prepare the rope?",
		"...",
		"...Fine, I’ll do it.",
		"Good. It would be such a pity to hang a smart man like you anyways.",
		"Here is the roaster of all the prisoners. When you see something or hear something, record it down. We’ll collect it at the end of each day and reward you immediately.",
		"And yes, I forgot - from now on you don’t have to do manual labour anymore; I’ll notify the watchers about that.",
		"That's it for now. You may wanna go back to your cell before anyone realizes you're missing."





	};

}