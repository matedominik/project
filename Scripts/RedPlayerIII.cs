using UnityEngine;
using System.Collections;

public class RedPlayerIII : MonoBehaviour {

	public static string redPlayerIII_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			redPlayerIII_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		redPlayerIII_ColName = "none";
	}
}