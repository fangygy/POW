using UnityEngine;
using System.Collections;

public class FadeManager : MonoBehaviour
{
	private static FadeManager instance;
	private static FadeManager GetInstance() { if (instance == null) instance = FindObjectOfType<FadeManager>(); return instance; }
	public float animationSpeed = 1f;

	private Animator fadeAnimator;

	public void FadeFromBlack()
	{
		GetInstance().fadeAnimator.SetBool("Faded", false);
	}

	public void FadeToBlack()
	{
		GetInstance().fadeAnimator.SetBool("Faded", true);
	}

	void Start()
	{
		fadeAnimator = GetComponent<Animator>();
	}

	void Update()
	{
		fadeAnimator.speed = animationSpeed;
	}
}
