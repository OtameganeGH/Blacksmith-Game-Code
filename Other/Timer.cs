using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;	

public class Timer : MonoBehaviour
{
	public Text counterText;
	float currentTime = 0f;

	public float startSec;
	public float startMin;
	public bool timerOn = true;
	
    // Start is called before the first frame update
    void Start()
    {
		currentTime = startSec;

	}

	// Update is called once per frame
	void Update()
    {

		if(currentTime <=9)
		{
		counterText.text =  startMin.ToString("0") + ":0" +	currentTime.ToString("0");
		}
		else
		{
			counterText.text = startMin.ToString("0") + ":" + currentTime.ToString("0");
		}
		
		if (timerOn)
		{
			currentTime -= 1 * Time.deltaTime;
		//	print(currentTime); 
			
		}
		if (currentTime < 0)
		{
			currentTime = 59f;
			startMin -= 1;
		}
		if(startMin < 0)
		{
			timerOn = false;	
			Debug.Log("Timer Ended");
			if (StaticCurrency.currency >= 20000)
			{
				SceneManager.LoadScene(3);
			}
			else
			{
				SceneManager.LoadScene(4);
			}
		}


		

		if (startMin < 3f) { counterText.color = Color.red; }

		if (Input.GetKeyDown(KeyCode.KeypadEnter))
			startMin -= 1;

	}


	IEnumerator StartTimer()
	{
		yield return new WaitForSeconds(1200);
		
	}

}
