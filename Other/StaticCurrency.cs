using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCurrency : MonoBehaviour
{
	// Start is called before the first frame update
	public static float currency;


	private void Update()
	{
		if (GameObject.Find("Canvas").GetComponent<Currency>() != null)
		{
			currency = GameObject.Find("Canvas").GetComponent<Currency>().currency;
		}
		
	}
	private void Awake()
	{
		DontDestroyOnLoad(this);
	}



}
