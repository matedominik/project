using UnityEngine;
using System.Collections;

public class YellowPlayerIV : MonoBehaviour {

	public static string yellowPlayerIV_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			yellowPlayerIV_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		yellowPlayerIV_ColName = "none";
	}
}