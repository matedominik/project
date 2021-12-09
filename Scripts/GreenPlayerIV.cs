using UnityEngine;
using System.Collections;

public class GreenPlayerIV : MonoBehaviour {

	public static string greenPlayerIV_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			greenPlayerIV_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		greenPlayerIV_ColName = "none";
	}
}