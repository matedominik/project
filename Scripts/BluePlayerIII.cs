using UnityEngine;
using System.Collections;

public class BluePlayerIII : MonoBehaviour {

	public static string bluePlayerIII_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			bluePlayerIII_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		bluePlayerIII_ColName = "none";
	}
}