using UnityEngine;
using System.Collections;

public class Sprayer : MonoBehaviour {
	
	public void RotateLeft(float speed)
	{
		transform.Rotate(new Vector3(0,0,speed));
	}
	public void RotateRight(float speed)
	{
		transform.Rotate(new Vector3(0,0,-speed));
	}
	public void SetRotation(Quaternion rotation)
	{
		transform.rotation = rotation;
	}
}
