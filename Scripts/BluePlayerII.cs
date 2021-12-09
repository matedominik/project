using UnityEngine;
using System.Collections;

public class BluePlayerII : MonoBehaviour {

	public static string bluePlayerII_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			bluePlayerII_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		bluePlayerII_ColName = "none";
	}
}