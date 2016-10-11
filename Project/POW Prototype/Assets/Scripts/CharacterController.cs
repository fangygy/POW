using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterController : MonoBehaviour
{

	public float X_Speed;
	public float Y_Speed;

	private bool move_enabled;
	private bool in_contact; 
	private GameObject other_obj;

	void Awake(){
		move_enabled = true;
	}
	// Use this for initialization
	void Start()
	{
		in_contact = false;
		//move_enabled = true;
	}

	// Update is called once per frame
	void Update()
	{
		OnKeyPressed();
		//movement toggle;
		if (Input.GetKeyDown(KeyCode.O))
		{
			move_enabled = !move_enabled; 
		}
	}

	void OnKeyPressed()
	{
		if (move_enabled)
		{
			if (Input.GetKey(KeyCode.W))
			{
				gameObject.transform.Translate(0, Y_Speed, 0);
			}
			if (Input.GetKey(KeyCode.S))
			{
				gameObject.transform.Translate(0, -Y_Speed, 0);
			}
			if (Input.GetKey(KeyCode.A))
			{
				gameObject.transform.Translate(-X_Speed, 0, 0);
			}
			if (Input.GetKey(KeyCode.D))
			{
				gameObject.transform.Translate(X_Speed, 0, 0);
			}
		}
	}
	public void SetMoveEnable(bool enable)
	{
		move_enabled = enable;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.GetComponent<InteractableObjects>())
		{
			other_obj = col.gameObject;
			in_contact = true;
		}
	
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.GetComponent<InteractableObjects>())
		{
			in_contact = false;
		}
	}
	public void SetContact(bool cont)
	{
		in_contact = cont;
	}
	public bool GetContact()
	{
		return in_contact;
	}
	public GameObject GetOtherObject()
	{
		return other_obj;
	}



}
