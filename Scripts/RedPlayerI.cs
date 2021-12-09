using UnityEngine;
using System.Collections;

public class RedPlayerI : MonoBehaviour {

	public static string redPlayerI_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			redPlayerI_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		redPlayerI_ColName = "none";
	}
}