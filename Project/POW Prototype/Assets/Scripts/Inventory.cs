using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Inventory : MonoBehaviour {
	private List<Item> inventory;
	public List<Image> slots;
	private bool open;
	public float pop_speed;
	private int item_count;
	// Use this for initialization
	void Start () {
		open = false;
		inventory = new List<Item>();
		item_count = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (open)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(120f, 0f, 0f), pop_speed * Time.deltaTime);
			transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime);
		}
		else
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(-405f, 0f, 0f), pop_speed * Time.deltaTime);
			transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime);
		}
	}

	public void UpdateSlots()
	{
		for (int i = 0; i < item_count; i++)
		{
			slots[i].GetComponent<Image>().sprite = inventory[i].GetComponent<SpriteRenderer>().sprite;
		}	
		
	}


	public void AddItem(string name)
	{
		if (GameObject.Find(name).GetComponent<Item>())
		{
			inventory.Add(GameObject.Find(name).GetComponent<Item>());
			item_count++;
			UpdateSlots();
			GameObject.Find(name).SetActive(false);
			GameObject.Find("Lieutenant").GetComponent<CharacterController>().SetContact(false);
		}
	}

	public void Toggle()
	{
		open = !open;
	}
	public void OpenInventory()
	{
		open = true;
	}
	public void CloseInventory()
	{
		open = false;
	}

}
