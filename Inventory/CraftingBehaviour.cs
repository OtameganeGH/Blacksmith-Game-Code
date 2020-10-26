using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingBehaviour : MonoBehaviour
{
	public GameObject Inventory, craftingSlot, sword1, sword2, sword3;
	public Text CraftingText;
	string craftingInfo;
	Color defaultColour;
	ItemFunction CraftingSlot, S1Stats, S2Stats, S3Stats;


    // Start is called before the first frame update
    void Start()
    {
		
		CraftingSlot = craftingSlot.GetComponent<ItemFunction>();
		craftingInfo = "Add a Hilt, Blade and Grip to craft a sword";
		defaultColour = CraftingText.color;
	}

    // Update is called once per frame
    void Update()
    {
		CraftingText.text = craftingInfo;
		S1Stats = sword1.GetComponent<ItemFunction>();
		S2Stats = sword2.GetComponent<ItemFunction>();
		S3Stats = sword3.GetComponent<ItemFunction>();
		if (SlotsFull() && CraftCheck() && craftingSlot.tag != "Item")
		{

			CraftingSlot.ConvertToWeapon(craftingSlot.GetComponent<ItemFunction>(),S1Stats.GetQuality(), S2Stats.GetQuality(), S3Stats.GetQuality(), S1Stats.GetPrice(), S2Stats.GetPrice(), S3Stats.GetPrice(), "Sword", S1Stats.itemImage.GetComponent<Image>().color, S2Stats.itemImage.GetComponent<Image>().color, S3Stats.itemImage.GetComponent<Image>().color);
		}
		if (!SlotsFull())
		{
			if (craftingSlot.tag == "Item")
			{
				
				CraftingSlot.DeleteItem(CraftingSlot);
			}
		}
    }


	public void ToggleCraft()
	{

		if (SlotsFull()&&CraftCheck())
		{
			Inventory.GetComponent<InventoryBehviour>().AddItem(CraftingSlot);
			S1Stats.DeleteItem(S1Stats);
			S2Stats.DeleteItem(S2Stats);
			S3Stats.DeleteItem(S3Stats);
		}else if (!SlotsFull())
		{
			StartCoroutine(CraftMsg(1));
		}
		else if (SlotsFull() && !CraftCheck())
		{
			StartCoroutine(CraftMsg(2));
		}
	}

	bool SlotsFull()
	{
		if (sword1.tag != "EmptySlot" && sword2.tag != "EmptySlot" && sword3.tag != "EmptySlot")
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	bool CraftCheck()
	{
		if (S1Stats.GetItemType() == "Hilt" && S2Stats.GetItemType() == "Blade" && S3Stats.GetItemType() == "Grip")
		{
			return true;
		}
		else if (S1Stats.GetItemType() == "Hilt" && S2Stats.GetItemType() == "Grip" && S3Stats.GetItemType() == "Blade")
		{
			return true;
		}
		else if (S1Stats.GetItemType() == "Blade" && S2Stats.GetItemType() == "Hilt" && S3Stats.GetItemType() == "Grip")
		{
			return true;
		}
		else if (S1Stats.GetItemType() == "Blade" && S2Stats.GetItemType() == "Grip" && S3Stats.GetItemType() == "Hilt")
		{
			return true;
		}
		else if (S1Stats.GetItemType() == "Grip" && S2Stats.GetItemType() == "Blade" && S3Stats.GetItemType() == "Hilt")
		{
			return true;
		}
		else if (S1Stats.GetItemType() == "Grip" && S2Stats.GetItemType() == "Hilt" && S3Stats.GetItemType() == "Blade")
		{
			return true;
		}
		else
		{
			return false;
		}

	}

	IEnumerator CraftMsg(int type)
	{

		int CaseTpye = type;
		switch (CaseTpye)
		{
			case 1:
				craftingInfo = "You need all 3 parts to craft a sword";
				CraftingText.color = Color.red;
				yield return new WaitForSeconds(3f);
				ReturnToDefault();
				break;
			case 2:
				craftingInfo = "You need a Hilt, Blade and Grip to craft a sword";
				CraftingText.color = Color.red;
				yield return new WaitForSeconds(3f);
				ReturnToDefault();
				break;
		}

	}
	void ReturnToDefault()
	{
		craftingInfo = "Add a Hilt, Blade and Grip to craft a sword";
		CraftingText.color = defaultColour;
	}
	public void EjectItems()
	{
		if(sword1.tag == "Item")
		Inventory.GetComponent<InventoryBehviour>().AddItem(S1Stats);

		if (sword2.tag == "Item")
			Inventory.GetComponent<InventoryBehviour>().AddItem(S2Stats);

		if (sword3.tag == "Item")
			Inventory.GetComponent<InventoryBehviour>().AddItem(S3Stats);
	}
}
