using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemFunction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public float quality, price;
	public GameObject itemImage, itemButton, canvas, selectionIcon, enchantIcon;
	public string nameTemp, itemType;
	string[] SwordNames;
	public bool isBlank, isEnchanted, hasSelected;
	public int iconNumber;
	public GameObject hilt, handle, blade, material, sword;
	public GameObject[] icons;
	ToolTipBehaviour toolTip;
	void Start()
	{
		isBlank = true;
		string[] TempSwordNames = { "Maming", "Smacking", "Crossfire", "the Baned", "Azeroth", "Kalimdor", " the Horde", " the Mullen", " Storms", " Legends", " Swording", "CyberBullying", "the Sword", "the Profaned", "Irythill", "Lordran", "Slaying", "Hunting", "Hunger", "the Champion" };
		SwordNames = TempSwordNames;
		canvas = GameObject.Find("Canvas");
		GameObject[] setIcons = { hilt, handle, blade, material, sword };
		icons = setIcons;
		toolTip = FindObjectOfType<ToolTipBehaviour>();
	}



	public string GetName()
	{
		return gameObject.name;
	}

	public void SetName(string newName)
	{
		gameObject.name = newName;
	}
	public float GetPrice()
	{
		return price;
	}
	public void SetPrice(float newPrice)
	{
		price = newPrice;
	}

	public float GetQuality()
	{
		return quality;
	}

	public void SetItemQuality(float newQuality)
	{
		quality = newQuality;

	}
	public void SetTag(string newTag)
	{
		gameObject.tag = newTag;
	}
	public string GetTag()
	{
		return gameObject.tag;
	}
	public int GetIconNumber()
	{
		return iconNumber;
	}
	public void SetIconNumber(int newNum)
	{
		iconNumber = newNum;
	}
	public void SetIcon(int newNum)
	{
		if (itemImage != null)
		{
			itemImage.SetActive(false);
		}
		itemImage = icons[newNum];
		SetIconNumber(newNum);
		itemImage.SetActive(true);

	}
	public void EnchantOff()
	{
		isEnchanted = false;
		enchantIcon.SetActive(false);
		Debug.Log(gameObject.name + "  Enchant off");
	}
	public void EnchantOn()
	{
		isEnchanted = true;
		enchantIcon.SetActive(true);
		Debug.Log(gameObject.name + "  Enchant on");
	}
	public bool GetEnchant()
	{
		return isEnchanted;
	}
	public void SetItemType(string newType)
	{
		itemType = newType;
	}
	public string GetItemType()
	{
		return itemType;
	}
	public Color GetImageColour()
	{
		return itemImage.GetComponent<Image>().color;
	}
	public void SetImageColour(Color newColour)
	{
		itemImage.GetComponent<Image>().color = newColour;


	}



	public void ConvertToWeapon(ItemFunction slot, float item1Qual, float item2Qual, float item3Qual, float item1Price, float item2Price, float item3Price, string newTag, Color I1Colour, Color I2Colour, Color I3Colour)
	{

		slot.quality = ((item1Qual + item2Qual + item3Qual) / 3);
		slot.price = (item1Price + item2Price + item3Price) * 1.2f;
		slot.tag = "Item";
		slot.itemImage = sword;
		slot.SetItemType("Sword");
		slot.itemImage.SetActive(true);
		slot.iconNumber = 4;
		slot.itemImage.GetComponent<Image>().color = new Color(((I1Colour.r + I2Colour.r + I3Colour.r) / 3), ((I1Colour.g + I2Colour.g + I3Colour.g) / 3), ((I1Colour.b + I2Colour.b + I3Colour.b) / 3));
		string caseList = newTag;
		switch (caseList)
		{
			case "Sword":
				string nameAddon = SwordNames[Random.Range(0, SwordNames.Length - 1)];
				slot.gameObject.name = ("Sword of " + nameAddon);
				break;
		}
	}

	public void CreateRandom()
	{
		float randomPrice, currCurrency;
		randomPrice = Random.Range(10, 200);
		currCurrency = canvas.GetComponent<Currency>().currency;
		if ((currCurrency -= randomPrice) >= 0)
		{
			isBlank = false;
			iconNumber = (Random.Range(0, icons.Length - 1));
			itemImage = icons[iconNumber];
			itemImage.SetActive(true);
			SetName("Test Object");
			SetItemQuality(Random.Range(1, 5));
			SetItemType("Item");
			SetTag("Item");
			SetPrice(randomPrice);

			int col1 = Random.Range(0, 255);
			int col2 = Random.Range(0, 255);
			int col3 = Random.Range(0, 255);
			Color set = new Color(col1, col2, col3);
			SetImageColour(set);
			Debug.Log(set);

			canvas.GetComponent<Currency>().currency -= randomPrice;
		}

		randomPrice = 0;

	}



	public void ChangeItemSlot(ItemFunction item, ItemFunction slot)
	{
		//slot = item;
		slot.isBlank = false;
		item.isBlank = true;

		//setIcon logic
		int tempIconNumber;
		tempIconNumber = item.GetIconNumber();
		item.itemImage.SetActive(false);
		slot.itemImage = slot.icons[tempIconNumber];
		slot.SetIconNumber(tempIconNumber);
		slot.itemImage.SetActive(true);


		//Name Swap Logic
		slot.SetName(item.GetName());
		item.name = null;


		//Price Swap Logic
		slot.SetPrice(item.GetPrice());
		item.SetPrice(0.0f);

		//Quality Swap Logic
		slot.SetItemQuality(item.GetQuality());
		item.SetItemQuality(0.0f);

		//Tag Swap Logic
		string tagSwap;
		tagSwap = slot.GetTag();
		slot.SetTag(item.GetTag());
		item.SetTag(tagSwap);
		tagSwap = null;

		//Swap enchantment if item has it
		if (item.isEnchanted == true)
		{
			item.EnchantOff();
			slot.EnchantOn();

		}

		//Swap item type string
		string tempType;
		tempType = item.GetItemType();
		item.SetItemType("");
		slot.SetItemType(tempType);

		//Swap Colour logic
		Color tempColour;
		tempColour = item.GetImageColour();
		item.SetImageColour(new Color(1, 1, 1));
		slot.SetImageColour(tempColour);



	}

	public void DeleteItem(ItemFunction item)
	{
		item.isBlank = true;
		if (itemImage != null)
		{
			item.itemImage.SetActive(false);
		}
		item.SetName(null);
		item.SetPrice(0);
		item.SetItemQuality(0);
		item.SetTag("EmptySlot");
		item.SetItemType("");
		if (item.GetEnchant())
		{
			item.EnchantOff();
		}

	}


	public void ItemSelected()
	{
		selectionIcon.SetActive(true);
		canvas.GetComponent<ItemSelectManager>().setItem(this.gameObject);
	}

	public void DeselectItem()
	{
		selectionIcon.SetActive(false);
		canvas.GetComponent<ItemSelectManager>().ItemSlot1 = null;
	}
	public void ForgeItemSelected()
	{
		selectionIcon.SetActive(true);
		hasSelected = true;
	}

	public void ForgeDeselectItem()
	{
		hasSelected = false;
		selectionIcon.SetActive(false);

	}

	public void SellItem(ItemFunction sellSlot, float newPrice)
	{
		canvas.GetComponent<Currency>().currency += newPrice;
		DeleteItem(sellSlot);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if(this.tag == "Item")
		toolTip.ShowTooltip(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		toolTip.HideToolTip();
	}
}
