using UnityEngine;
using System.Collections;

public class GreenPlayerII : MonoBehaviour {

	public static string greenPlayerII_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			greenPlayerII_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		greenPlayerII_ColName = "none";
	}
}