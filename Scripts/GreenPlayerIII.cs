using UnityEngine;
using System.Collections;

public class GreenPlayerIII : MonoBehaviour {

	public static string greenPlayerIII_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			greenPlayerIII_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		greenPlayerIII_ColName = "none";
	}
}