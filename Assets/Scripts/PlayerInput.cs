using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	private Sprayer sprayer;
	private BubbleGen bubbleGen;
	private Caster caster;
	
	void Awake()
	{
		sprayer = GameObject.Find("BubbleSprayer").GetComponent<Sprayer>();
		caster = GameObject.Find("BubbleCaster").GetComponent<Caster>();
		bubbleGen = GameObject.Find("Bubbles").GetComponent<BubbleGen>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			float xCircle = Input.mousePosition.x - Screen.width/2;
			float yCircle = Input.mousePosition.y - Screen.height/2;
			float angle = Mathf.Atan2(-yCircle, xCircle);
			if(angle < 0)
			{
				angle += Mathf.PI*2;
			}
			sprayer.SetRotation(Quaternion.AngleAxis(-angle*180/Mathf.PI, Vector3.forward));
		}
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
		{
			caster.Shoot();
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Fire2"))
		{
			caster.SwitchNextBubble();
		}
		if(Input.GetKeyDown (KeyCode.Alpha1))
		{
			bubbleGen.SwitchGameMode("Classic");
		}
		if(Input.GetKeyDown (KeyCode.Alpha2))
		{
			bubbleGen.SwitchGameMode("Panic");
		}
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				sprayer.RotateLeft(0.5f);
			}
			else
			{
				sprayer.RotateLeft(3f);
			}
		}
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				sprayer.RotateRight(0.5f);
			}
			else
			{
				sprayer.RotateRight(3f);
			}
		}
		if(Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
		{
			float xCircle = Input.GetAxis("Horizontal");// * Mathf.Sqrt(1 - 0.5f*Mathf.Pow(2, Input.GetAxis("Vertical")));
			float yCircle = Input.GetAxis("Vertical");// * Mathf.Sqrt(1 - 0.5f*Mathf.Pow(2, Input.GetAxis("Horizontal")));
			float angle = Mathf.Atan2(-yCircle, xCircle);
			if(angle < 0)
			{
				angle += Mathf.PI*2;
			}
			sprayer.SetRotation(Quaternion.AngleAxis(-angle*180/Mathf.PI, Vector3.forward));
		}
	}
}
