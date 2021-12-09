using UnityEngine;
using System.Collections;

public class YellowPlayerII : MonoBehaviour {

	public static string yellowPlayerII_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			yellowPlayerII_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		yellowPlayerII_ColName = "none";
	}
}