using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{
	public GameObject timer, Skin1, Skin2, Skin3;
	 public float leaveTimer;
	public bool firstInLine = false, timerOn = false;
	AudioSource bing;
    // Start is called before the first frame update
    void Start()
    {
		bing = GetComponent<AudioSource>();
		leaveTimer = (Random.Range(30, 60));
		
		//StartCoroutine(TimerFlash());
		
	}
	private void Awake()
	{
		int type = Random.Range(1, 3);
		int CaseTpye = type;
		switch (CaseTpye)
		{
			case 1:
				Skin1.SetActive(true);
				break;
			case 2:
				Skin2.SetActive(true);
				break;
			case 3:
				Skin3.SetActive(true);
				break;
		}
	}


	// Update is called once per frame
	void Update()
	{
		
		if (firstInLine)
		{
			leaveTimer -= 1 * Time.deltaTime;
		}
		if (leaveTimer < 0)
		{
			GameObject Queue = GameObject.Find("Queue");
			Queue.GetComponent<QueueBehaviour>().DeleteFirst();	
			

			Destroy(this.gameObject);
		}

		if (leaveTimer < 15 && timerOn == false)
		{
			StartCoroutine(TimerFlash());
			timerOn = true;
			
		}
		
	
	}



		IEnumerator TimerFlash()
		{
			Debug.Log("flash started");
		for (int i = 0; (i < 15); i++)
		{
			timer.SetActive(true);
			bing.Play();
			yield return new WaitForSeconds(1f - (.07f * i));
			
			timer.SetActive(false);
			yield return new WaitForSeconds(1f - (.07f * i));
		}
			
		}

	}

