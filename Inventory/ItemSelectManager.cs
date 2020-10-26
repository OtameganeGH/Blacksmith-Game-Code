using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectManager : MonoBehaviour
{

	public GameObject ItemSlot1, ItemSlot2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void setItem(GameObject newItem)
	{
		if (newItem.tag == "EmptySlot" && ItemSlot1 == null)
		{
			ItemSlot1 = newItem;
			Debug.Log("Selected Slot");
		}

		else if (newItem.tag == "Item" && ItemSlot1 == null)
		{
			ItemSlot1 = newItem;
			Debug.Log("Selected Item");
		}

		else if (ItemSlot1 != null && ItemSlot1.tag == "Item" && newItem.tag == "EmptySlot")
		{
			ItemSlot1.GetComponent<ItemFunction>().ChangeItemSlot(ItemSlot1.GetComponent<ItemFunction>(), newItem.GetComponent<ItemFunction>());
			ClearItem();
			ItemSlot1 = newItem;
			ClearItem();

			
			Debug.Log("Swapped Slot");
		}
		else if (newItem == ItemSlot1)
		{
			ClearItem();
			newItem = null;
			Debug.Log("Selected the same slot/item");
		}
		else if (ItemSlot1.tag == "EmptySlot" && newItem.tag == "EmptySlot" && newItem != ItemSlot1)
		{
			ClearItem();
			ItemSlot1 = newItem;
			Debug.Log("Selected another empty slot");
		}

		else if (ItemSlot1.tag == "Item" && newItem.tag == "Item" && newItem != ItemSlot1)
		{
			ClearItem();
			ItemSlot1 = newItem;
			Debug.Log("Selected another item");
		}
		else if (ItemSlot1.tag == "EmptySlot" && newItem.tag == "Item")
		{
			ClearItem();
			ItemSlot1 = newItem;
			Debug.Log("Selected an item from a slot");
		}
	}
	public GameObject GetItem()
	{
		return ItemSlot1;
	}
	public void ClearItem()
	{
		if (ItemSlot1 != null)
		{
			ItemSlot1.GetComponent<ItemFunction>().DeselectItem();
			ItemSlot1 = null;
		}
	}
}
