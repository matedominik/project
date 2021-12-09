using UnityEngine;
using System.Collections;

public class RedPlayerII : MonoBehaviour {

	public static string redPlayerII_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			redPlayerII_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		redPlayerII_ColName = "none";
	}
}