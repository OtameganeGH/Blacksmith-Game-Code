using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reputation : MonoBehaviour
{
	public int rep;
	public Text repText;
	string repLevel;
    // Start is called before the first frame update
    void Start()
    {
		rep = 0;
    }

    // Update is called once per frame
    void Update()
    {
		repText.text = repLevel;


		if (rep > -1 && rep < 6)
		{
			repLevel = "Neutral";
			//set npc spawn rates
		}
		else if (rep > 5 && rep < 20)
		{
			repLevel = "Good";
		}
		else if (rep >= 20)
		{
			repLevel = "Great";
		}
		else if (rep <0 && rep > -5)
		{
			repLevel = "Bad";
		}
		else if (rep <-5 && rep > -20)
		{
			repLevel = "Awful";
		}
		else if (rep <= -20)
		{
			repLevel = "GAME OVER";
			SceneManager.LoadScene(2);
		}

		if (Input.GetKeyDown(KeyCode.KeypadDivide))
			rep -= 5;
		if (Input.GetKeyDown(KeyCode.KeypadMultiply))
			rep += 5;


	}


	public void LowerRep(int repChange)
	{
		rep = rep - repChange;
	}

	public void RaiseRep(int repChange)
	{
		rep = rep + repChange;
	}
}
