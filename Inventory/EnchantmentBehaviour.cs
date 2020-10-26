using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnchantmentBehaviour : MonoBehaviour
{
	public GameObject Inventory, enchantmentSlot, Canvas;
	public Text infoText;
	string textUpdate;
	ItemFunction enchant;
	public float enchantCost;
	Color defaultColour, warningColour = Color.red;
	Currency mainCurrency;
	// Start is called before the first frame update
	void Start()
	{
		mainCurrency = Canvas.GetComponent<Currency>();
		enchant = enchantmentSlot.GetComponent<ItemFunction>();
		textUpdate = "increase the chance for a weapon to not be detected for 150G";
		defaultColour = infoText.color;
	}

	// Update is called once per frame
	void Update()
	{
		infoText.text = textUpdate;
	}

	public void Enchant() { 
		if (enchant.GetItemType() == "Sword" && ((mainCurrency.currency + enchantCost) >=0)&& enchant.GetEnchant()==false) {
			enchant.EnchantOn();			
			Canvas.GetComponent<Currency>().CurrencyChange(enchantCost);
			Inventory.GetComponent<InventoryBehviour>().AddItem(enchant);
			//enchant.EnchantOff();
		}
		else if ((mainCurrency.currency + enchantCost) < 0)
		{
			StartCoroutine(EnchantMessage(1));
		}
		else if (enchant.GetItemType() != "Sword")
		{
			StartCoroutine(EnchantMessage(2));
		}
	}

	void ReturnToDefault()
	{
		textUpdate = "increase the chance for a weapon to not be detected for 150G";
		infoText.color = defaultColour;
	}
	IEnumerator EnchantMessage(int type)
	{

		int CaseTpye = type;
			switch (CaseTpye) {
			case 1:
				textUpdate = "You don't have enough gold!";
				infoText.color = warningColour;
				yield return new WaitForSeconds(3f);
				ReturnToDefault();
				break;
			case 2:
				textUpdate = "Only Weapons can be enchanted!";
				infoText.color = warningColour;
				yield return new WaitForSeconds(3f);
				ReturnToDefault();
				break;




			}
		
	}
	public void EjectItems()
	{
		if(enchantmentSlot.tag == "Item")
		Inventory.GetComponent<InventoryBehviour>().AddItem(enchant);
	}

	}
