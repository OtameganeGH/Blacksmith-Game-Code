using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueBehaviour : MonoBehaviour
{
	public GameObject[] line;
	public GameObject slot1, slot2, slot3, slot4, slot5, npc, toggler, cam, sellMenu;
	public bool slot1Free = true, slot2Free = true, slot3Free = true, slot4Free = true, slot5Free = true, spawning = true;
	public AudioSource door;
	public float rep;
	// Start is called before the first frame update
	void Start()
    {
		GameObject[] lineSlots = {slot1, slot2, slot3, slot4, slot5 };
		line = lineSlots;
		door = GetComponent<AudioSource>();
		rep = StaticReputation.reputation;
	}

    // Update is called once per frame
    void Update()
    {
		if (spawning)
		{
			StartCoroutine(NPCSapawnTimer());
			spawning = false;
		}
    }


	void SpawnNPC()
	{
		
		toggler = Instantiate(npc, slot1.transform.position, slot1.transform.rotation);
		door.Play();
		slot1Free = false;
		toggler.GetComponent<CustomerBehaviour>().firstInLine = true;

		

	}
	public void DeleteFirst()
	{
		Debug.Log("DeletedFirst");
		slot1Free = true;
		door.Play();
		spawning = true;
		if (cam.GetComponent<HoverOver>().currOpenInv != null)
			cam.GetComponent<HoverOver>().ClearInteractables();

		sellMenu.GetComponent<SellItem>().EjectItems();

	}
	
	IEnumerator NPCSapawnTimer()
	{


		if (rep > -1 && rep < 6)
		{
			yield return new WaitForSeconds(Random.Range(15, 30));
			if (slot1Free)
			{
				SpawnNPC();
			}

		}
		else if (rep > 6 && rep < 20)
		{
			yield return new WaitForSeconds(Random.Range(10, 15));
			if (slot1Free)
			{
				SpawnNPC();
			}
		}
		else if (rep >= 20)
		{
			yield return new WaitForSeconds(Random.Range(5, 10));
			if (slot1Free)
			{
				SpawnNPC();
			}
		}
		else if (rep < 0 && rep > -6)
		{
			yield return new WaitForSeconds(Random.Range(25, 30));
			if (slot1Free)
			{
				SpawnNPC();
			}
		}
		else if (rep < -6 && rep > -20)
		{
			yield return new WaitForSeconds(Random.Range(30, 40));
			if (slot1Free)
			{
				SpawnNPC();
			}
		}		
		
	}
}
