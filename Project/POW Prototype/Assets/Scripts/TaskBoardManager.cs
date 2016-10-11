using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
public class TaskBoardManager : MonoBehaviour
{

	public class taskLog
	{
		public GameObject task;
		public bool show;
		//public bool exist;
		public taskLog(GameObject task, bool show)
		{
			this.task = task;
			this.show = show;
			//this.exist = exist;
		}
	}
	public List<taskLog> tasks;
	public List<taskLog> subTasks;
	public List<GameObject> deleteButtons;
	private int subTasks_count;
	private int tasks_count;
	// Use this for initialization
	void Start()
	{
		tasks_count = 0;
		subTasks_count = 0;
		tasks = new List<taskLog>();
		subTasks = new List<taskLog>();
		do
		{
			tasks.Add(new taskLog(GameObject.Find("Task" + tasks.Count), false));
		} while (tasks.Count < 5);

		do
		{
			subTasks.Add(new taskLog(GameObject.Find("SubTask" + subTasks.Count), false));
		} while (subTasks.Count < 5);
		do
		{
			deleteButtons.Add(GameObject.Find("DeleteButton" + deleteButtons.Count));
			deleteButtons[deleteButtons.Count - 1].SetActive(false);
		} while (deleteButtons.Count < 5);
		UpdateTaskBoard();
	}

	public void UpdateTaskBoard()
	{

		int num_task = 0;
		int num_sub = 0;
		for (int i = 0; i < 5; i++)
		{
			tasks[i].task.SetActive(false);
			subTasks[i].task.SetActive(false);
			deleteButtons[i].SetActive(false);
		}
		for (int i = 0; i < tasks.Count; i++)
		{
			if (tasks[i].show)
			{
				tasks[i].task.SetActive(true);
				tasks[i].task.transform.localPosition = new Vector3(-16.2f, 340f - num_task * 20f - num_sub * 60f, 0f);
				num_task++;

			}

			if (subTasks[i].show)
			{
				deleteButtons[i].SetActive(true);
				deleteButtons[i].transform.localPosition = new Vector3(65.3f, 320f - num_task * 20f - num_sub * 60f, 0f);
				subTasks[i].task.SetActive(true);
				subTasks[i].task.transform.localPosition = new Vector3(-15f, 320f - num_task * 20f - num_sub * 60f, 0f);
				num_sub++;
			}


		}
	}
	public void DeleteTask(int index)
	{

		deleteButtons[index].SetActive(false);
		subTasks[index].show = false;
		tasks[index].show = false;
		GameObject.Find("GameManager").GetComponent<GameManager>().DeleteTaskAt(index);
		UpdateTaskBoard();
	

		
	}
	public void ResetTaskBoard()
	{
		for (int i = 0; i < 5; i++)
		{
			//Debug.Log(i);
			deleteButtons[i].SetActive(false);
			subTasks[i].show = false;
			tasks[i].show = false;
		}
		UpdateTaskBoard();
	}

	public void Toggle(int index)
	{
		subTasks[index].show = !subTasks[index].show;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
