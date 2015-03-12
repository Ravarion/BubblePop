using UnityEngine;
using System.Collections;

public class Sprayer : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				transform.Rotate(new Vector3(0,0,0.5f));
			}
			else
			{
				transform.Rotate(new Vector3(0,0,3));
			}
		}
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				transform.Rotate(new Vector3(0,0,-0.5f));
			}
			else
			{
				transform.Rotate(new Vector3(0,0,-3));
			}
		}
		if(Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
		{
			float xCircle = Input.GetAxis("Horizontal") * Mathf.Sqrt(1 - 0.5f*Mathf.Pow(2, Input.GetAxis("Vertical")));
			float yCircle = Input.GetAxis("Vertical") * Mathf.Sqrt(1 - 0.5f*Mathf.Pow(2, Input.GetAxis("Horizontal")));
			float angle = Mathf.Atan2(-yCircle, xCircle);
			if(angle < 0)
			{
				angle += Mathf.PI*2;
			}
			Debug.Log(Input.GetAxis("Vertical") + ", " + Input.GetAxis("Horizontal"));
			transform.rotation = Quaternion.AngleAxis(-angle*180/Mathf.PI, Vector3.forward);
		}
	}
}
