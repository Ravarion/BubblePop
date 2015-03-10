using UnityEngine;
using System.Collections;

public class Sprayer : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(new Vector3(0,0,1));
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(new Vector3(0,0,-1));
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Rotate(new Vector3(0,0,1));
		}
		if(Input.GetKey(KeyCode.D))
		{
			transform.Rotate(new Vector3(0,0,-1));
		}
	}
}
