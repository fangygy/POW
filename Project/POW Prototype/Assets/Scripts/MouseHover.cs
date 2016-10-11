using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

	public Vector3 target_pos;
	public Vector3 scale_up;
	public float move_step;
	public float scale_step;
	private bool isOver = false;
	private Vector3 ini_scale;
	private Vector3 ini_pos;
	void Start()
	{
		ini_scale = transform.localScale;
		ini_pos = transform.localPosition;
	}
	void Update()
	{
		if (isOver)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, target_pos, move_step * Time.deltaTime);
			transform.localScale = Vector3.MoveTowards(transform.localScale, scale_up, scale_step * Time.deltaTime);
			if (gameObject.name == "OpenIcon")
			{
				if (Input.GetMouseButtonDown(0))
				{
					GameObject.Find("Slots").GetComponent<Inventory>().Toggle();
				}
			}
		}
		else
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, ini_pos, move_step*Time.deltaTime);
			transform.localScale = Vector3.MoveTowards(transform.localScale, ini_scale, scale_step*Time.deltaTime);
		}
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		isOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isOver = false;
	}
}