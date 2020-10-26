using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
	public Text scoreText;
	// Start is called before the first frame update
	void Awake()
	{

	}

    // Update is called once per frame
    void Update()
    {
		scoreText.text = (Mathf.RoundToInt(StaticCurrency.currency) + "G");
	}
}
