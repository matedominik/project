using UnityEngine;
using System.Collections;

public class YellowPlayerI : MonoBehaviour {

	public static string yellowPlayerI_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			yellowPlayerI_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		yellowPlayerI_ColName = "none";
	}
}