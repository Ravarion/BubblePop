using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePlusScript : MonoBehaviour {

	private float startTime;

	void Awake()
	{
		startTime = Time.time;
	}
	
	void Update()
	{
		if(Time.time - startTime > 2)
		{
			Destroy(gameObject);
		}
	}
	
	public void SetScore(string score)
	{
		gameObject.GetComponent<Text>().text = score;
	}
	
	public void SetScore(int score)
	{
		gameObject.transform.GetChild(0).GetComponent<Text>().text = score.ToString();
		//GetComponent<Text>().text = score.ToString();
	}
}
