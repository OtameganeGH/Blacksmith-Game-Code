using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{

	public float currency;
	public Text currencyText;
    // Start is called before the first frame update
    void Start()
    {
		currency = 2000;
    }

    // Update is called once per frame
    void Update()
    {
		currencyText.text = (Mathf.RoundToInt(currency) + "G");

		if (Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			currency += 1000;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			currency -= 50;
		}
		if(currency <= 0)
		{
			currency = 0;
		}
	}

	public void CurrencyChange(float change)
	{
		currency += change;
	}

}
