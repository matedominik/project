using UnityEngine;
using System.Collections;

public class YellowPlayerIII : MonoBehaviour {

	public static string yellowPlayerIII_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			yellowPlayerIII_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		yellowPlayerIII_ColName = "none";
	}
}