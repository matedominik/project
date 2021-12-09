using UnityEngine;
using System.Collections;

public class BluePlayerI : MonoBehaviour {

	public static string bluePlayerI_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{			
			bluePlayerI_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		bluePlayerI_ColName = "none";
	}
}