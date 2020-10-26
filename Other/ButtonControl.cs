using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class ButtonControl : MonoBehaviour
{

	public GameObject helpButton, helpText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Help()
	{
		helpText.SetActive(true);
		helpButton.SetActive(false);
	}

	public void Begin()
	{
		SceneManager.LoadScene(1);
	}
	public void Quit()
	{

		Application.Quit();
		
		 
	}
	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}


}
