using UnityEngine;
using System.Collections;

public class BluePlayerIV : MonoBehaviour {

	public static string bluePlayerIV_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			bluePlayerIV_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		bluePlayerIV_ColName = "none";
	}
}