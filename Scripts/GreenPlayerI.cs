using UnityEngine;
using System.Collections;

public class GreenPlayerI : MonoBehaviour {

	public static string greenPlayerI_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			greenPlayerI_ColName = col.gameObject.name;
		}
	}

	void Start () 
	{
		greenPlayerI_ColName = "none";
	}
}