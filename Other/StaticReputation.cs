using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticReputation : MonoBehaviour
{
	public static float reputation;
    // Start is called before the first frame update
  
   

    // Update is called once per frame
    void Update()
    {
		if (GameObject.Find("Canvas").GetComponent<Reputation>() != null)
		{

			reputation = GameObject.Find("Canvas").GetComponent<Reputation>().rep;

		}
	}
}
