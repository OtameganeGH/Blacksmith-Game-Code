using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SellItem : MonoBehaviour
{
	public GameObject sellSlot, canvas, queue, cam, inventory;
	public Text defaultPriceText, newPriceText, changePercentText, dialogueText;
	ItemFunction sellFunction;
	string defaultDialogue, newDialogue;
	float defaultPrice, newPrice;
	int priceRaiseAmount = 0, changePercent;
	// Start is called before the first frame update
	void Start()
	{
		sellFunction = sellSlot.GetComponent<ItemFunction>();
		defaultDialogue = dialogueText.text;

	}

	// Update is called once per frame
	private void Update()
	{
		if (priceRaiseAmount <= -4)
		{
			priceRaiseAmount = -4;
		}
		if (sellSlot.tag != "EmptySlot")
		{
			defaultPrice = sellFunction.GetPrice();

			if (priceRaiseAmount <= -10)
			{
				priceRaiseAmount = -10;
			}
			newPrice = defaultPrice + (defaultPrice * (0.05f * priceRaiseAmount));

			defaultPriceText.text = (defaultPrice + "G");
			newPriceText.text = (Mathf.RoundToInt(newPrice) + "G");

			changePercent = (5 * priceRaiseAmount);
			if (changePercent >= 0)
			{
				changePercentText.text = ("+ " + changePercent + "%");
			}
			else if (changePercent < 0 && changePercent > -20)
			{
				changePercentText.text = (changePercent + "%");
			}
			else if (changePercent == -20)
			{
				changePercentText.text = (changePercent + "% + Reputation");
			}


		}
		else
		{
			defaultPriceText.text = ("0G");
			newPriceText.text = ("0G");
			changePercentText.text = ("");
		}
	}
	public void sellClicked()
	{
		if (sellSlot.GetComponent<ItemFunction>().GetItemType() == "Sword" /*Add other weps here*/)
		{
			//SELLING WEAPON
			if (sellSlot.tag != "EmptySlot" && sellSlot.GetComponent<ItemFunction>().isEnchanted == false)
			{		


				if (priceRaiseAmount < 5)
				{

					canvas.GetComponent<Reputation>().RaiseRep(1);
					Debug.Log(" Wep Sold");
					StartCoroutine(IfCaught(2));
				}
				else if (priceRaiseAmount >= 5)
				{
					Debug.Log("Wep Sold");

					int checkIfCaught = Random.Range(0, priceRaiseAmount);
					if (checkIfCaught >= 5)
					{
						Debug.Log("Caught");
						canvas.GetComponent<Reputation>().LowerRep(5);
						StartCoroutine(IfCaught(1));

					}
					else
					{
						Debug.Log("Not Caught");
						canvas.GetComponent<Reputation>().RaiseRep(2);
						StartCoroutine(IfCaught(2));

					}
				}
				else if (priceRaiseAmount == -4)
				{
					Debug.Log("Good Faith Wep Sold");
					canvas.GetComponent<Reputation>().RaiseRep(4);
					StartCoroutine(IfCaught(3));

				}

			}


			//REP RASED IF SOLD AT -20%
			else if (priceRaiseAmount == -4)
			{
				Debug.Log("Good Faith Wep Sold");
				canvas.GetComponent<Reputation>().RaiseRep(4);
				StartCoroutine(IfCaught(3));

			}


			//	SELLING ENCHANTED WEAPON
			else if (sellSlot.tag != "EmptySlot" && sellSlot.GetComponent<ItemFunction>().isEnchanted == true)
			{

				if (priceRaiseAmount < 6)
				{
					
					canvas.GetComponent<Reputation>().RaiseRep(2);
					Debug.Log("Enchanted Wep Sold");
					StartCoroutine(IfCaught(2));
				}


				else if (priceRaiseAmount >= 6)
				{
					int checkIfCaught = Random.Range(0, priceRaiseAmount);
					if (checkIfCaught >= (priceRaiseAmount / 3) * 2)
					{
						Debug.Log("Caught");
						canvas.GetComponent<Reputation>().LowerRep(5);
						StartCoroutine(IfCaught(1));
					}
					else
					{
						Debug.Log("Not Caught");
						canvas.GetComponent<Reputation>().RaiseRep(2);
						StartCoroutine(IfCaught(2));
					}
				}
				else if (priceRaiseAmount == -4)
				{
					Debug.Log("Good Faith Enchant Wep Sold");
					canvas.GetComponent<Reputation>().RaiseRep(6);
					StartCoroutine(IfCaught(3));

				}

			}
			else
			{
				StartCoroutine(IfCaught(4));
			}
			priceRaiseAmount = 0;
		}
	}

	public void priceUp()
	{
		priceRaiseAmount += 1;

	}

	public void priceDown()
	{
		priceRaiseAmount -= 1;
	}

	void MakeLeave()
	{
		
		queue.GetComponent<QueueBehaviour>().DeleteFirst();
		dialogueText.text = defaultDialogue;
		cam.GetComponent<HoverOver>().npcTalking = false;
		//cam.GetComponent<HoverOver>().ClearInteractables();
		if (cam.GetComponent<HoverOver>().hitGO != null)
		{
			Destroy(cam.GetComponent<HoverOver>().hitGO);
		}

	}

	IEnumerator IfCaught(int type)
	{
		cam.GetComponent<HoverOver>().npcTalking = true;
		int CaseTpye = type;
		switch (CaseTpye)
		{
			case 1:
				newDialogue = "Hey! you cant fool me!";				
				dialogueText.text = newDialogue;
				yield return new WaitForSeconds(2);
				EjectItems();
				dialogueText.text = defaultDialogue;
				MakeLeave();
				break;
			case 2:
				newDialogue = "Thank you very much!";
				dialogueText.text = newDialogue;
				sellFunction.SellItem(sellFunction, newPrice);
				yield return new WaitForSeconds(2);
				dialogueText.text = defaultDialogue;
				MakeLeave();
				break;
			case 3:
				newDialogue = "Wow, your prices are generous!";
				dialogueText.text = newDialogue;
				sellFunction.SellItem(sellFunction, newPrice);
				yield return new WaitForSeconds(2);
				dialogueText.text = defaultDialogue;
				MakeLeave();
				break;
			case 4:
				newDialogue = "I don't want that!";
				dialogueText.text = newDialogue;
				EjectItems();
				yield return new WaitForSeconds(2);
				dialogueText.text = defaultDialogue;				
				break;



		}
	}
	public void EjectItems()
	{
		if(sellSlot.tag == "Item")
		inventory.GetComponent<InventoryBehviour>().AddItem(sellFunction);
	}
}
