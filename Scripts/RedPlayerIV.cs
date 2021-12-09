using UnityEngine;
using System.Collections;

public class RedPlayerIV : MonoBehaviour {

	public static string redPlayerIV_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			redPlayerIV_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		redPlayerIV_ColName = "none";
	}
}