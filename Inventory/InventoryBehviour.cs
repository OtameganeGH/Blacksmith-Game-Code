using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehviour : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject nextSlot;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //   AddRandomItem();
        //}
    }


    void AddRandomItem()
    {
      
        for (int i = 0; (i < slots.Length) && (nextSlot == null); i++)
        {
            if (slots[i].GetComponent<ItemFunction>().isBlank == true)
            {
               nextSlot = slots[i];
                nextSlot.GetComponent<ItemFunction>().CreateRandom();
				nextSlot.GetComponent<ItemFunction>().DeselectItem();
				nextSlot = null;
                break;
            }
        }
    }

	public void AddItem(ItemFunction newItem)
	{

		for (int i = 0; (i < slots.Length) && (nextSlot == null); i++)
		{
			if (slots[i].GetComponent<ItemFunction>().isBlank == true)
			{
				nextSlot = slots[i];
				nextSlot.GetComponent<ItemFunction>().ChangeItemSlot(newItem, nextSlot.GetComponent<ItemFunction>());
				nextSlot.GetComponent<ItemFunction>().DeselectItem();
				nextSlot = null;
				break;
			}
		}
	}
}
