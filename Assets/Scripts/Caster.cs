using UnityEngine;
using System.Collections;

public class Caster : MonoBehaviour {
	
	public GameObject redBubble;
	
	private GameObject bubbles;
	
	void Awake()
	{
		bubbles = GameObject.Find("Bubbles");
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bubble = Instantiate(redBubble, transform.position, Quaternion.identity) as GameObject;
			bubble.transform.SetParent(bubbles.transform);
			bubble.GetComponent<Bubble>().Shooter();
//			bubble.GetComponent<Bubble>().SetPopper(true);
		}
	}
}
