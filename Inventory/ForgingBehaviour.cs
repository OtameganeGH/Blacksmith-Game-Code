using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent (typeof(ItemFunction))]
[RequireComponent(typeof(Currency))]
//coupling code
public class ForgingBehaviour : MonoBehaviour
{
	public GameObject SelectionIcon, PartChosen, LastPartChosen, MatChosen, LastMatChosen, ForgePart, ForgeMaterial, Result, WorldCanvas;
	ItemFunction PartFunc, MaterialFunc;
	public string forgeInfo;
	public float price;
	public Text infoText, forgeCost;
	Color defaultColour;
	Transform SelectedTransform;
	ItemFunction resultFunc;
	Currency mainCurrency;
	Color matColour;

	// Start is called before the first frame update
	void Start()
	{
		forgeInfo = "Pick a part and a material";
		defaultColour = infoText.color;
		resultFunc = Result.GetComponent<ItemFunction>();
		WorldCanvas = GameObject.Find("Canvas");
		mainCurrency = WorldCanvas.GetComponent<Currency>();
	}

	// Update is called once per frame
	void Update()
	{
		infoText.text = forgeInfo;
		forgeCost.text = (Mathf.RoundToInt(price) + "G");
		if (ForgePart != null && ForgeMaterial != null)
		{
			Debug.Log("Creating item");
			ItemFunction PartFunc, MatFunc;

			MatFunc = ForgeMaterial.GetComponent<ItemFunction>();
			PartFunc = ForgePart.GetComponent<ItemFunction>();
			resultFunc.SetItemType(PartFunc.GetItemType());
			resultFunc.SetName((MatFunc.GetName() + " " + PartFunc.GetName()));
			resultFunc.SetItemQuality(MatFunc.GetQuality());
			resultFunc.SetTag("Item");
			string CaseTpye = MatFunc.GetName();			
			switch (CaseTpye)
			{
				case "Iron":
					matColour = new Color(0.4823529f, 0.4823529f, 0.4823529f);					
					break;
				case "Copper":
					matColour = new Color(0.8862745f, 0.5921569f, 0.1529412f);
					break;
				case "Bronze":
					matColour = new Color(0.5849056f, 0.4014046f, 0.06897471f);
					break;
				case "Mythril":
					matColour = new Color(0.6427109f, 0.9528301f, 0.9528302f);
					break;

			}
			resultFunc.SetIcon(PartFunc.GetIconNumber());
			resultFunc.SetImageColour(matColour);
			Debug.Log(resultFunc.GetImageColour());
			resultFunc.SetPrice(PartFunc.GetPrice() * MatFunc.GetPrice());
			price = resultFunc.GetPrice();
		}
		}
	public void CreatePart()
	{
		if(ForgePart != null && ForgeMaterial != null)
		{			

			if((mainCurrency.currency - resultFunc.GetPrice()) >= 0){
				mainCurrency.CurrencyChange(-(resultFunc.price));
				GameObject.Find("InventoryBackground").GetComponent<InventoryBehviour>().AddItem(resultFunc);
				
			}
			else
			{
				resultFunc.DeleteItem(resultFunc);
				PartChosen.GetComponent<ItemFunction>().ForgeDeselectItem();
				MatChosen.GetComponent<ItemFunction>().ForgeDeselectItem();
				ForgePart = null;
				ForgeMaterial = null;
				LastMatChosen = null;
				LastMatChosen = null;
				price = 0;
				StartCoroutine(ForgeMessage(2));
			}
			}
		else 
		{
			StartCoroutine(ForgeMessage(1));
		}		
	}


	IEnumerator ForgeMessage(int type)
	{

		int CaseTpye = type;
		switch (CaseTpye)
		{
			case 1:
				forgeInfo = "Missing part or material";
				infoText.color = Color.red;
				yield return new WaitForSeconds(3f);
				ReturnToDefault();
				break;
			case 2:
				forgeInfo = "Not enough gold!";
				infoText.color = Color.red;
				yield return new WaitForSeconds(3f);
				ReturnToDefault();
				break;
		}

	}

	void ReturnToDefault()
	{
		forgeInfo = "Pick a part and a material";
		infoText.color = defaultColour;
	}

	public void PartSelect(GameObject partSlot)
	{
		if (partSlot.tag == "PartChoice")
		{
			PartChosen = partSlot;

			if (LastPartChosen == null)
			{
				Debug.Log("NewPartChosen");
				PartChosen.GetComponent<ItemFunction>().ForgeItemSelected();
				LastPartChosen = PartChosen;
				ForgePart = LastPartChosen;

			}
			else if (PartChosen == LastPartChosen)
			{
				Debug.Log("SamePartChosen");

				PartChosen.GetComponent<ItemFunction>().ForgeDeselectItem();
				LastPartChosen = null;
				ForgePart = null;

			}
			else if (LastPartChosen != null && PartChosen != LastPartChosen)
			{
				Debug.Log("SwappedPart");
				LastPartChosen.GetComponent<ItemFunction>().ForgeDeselectItem();
				PartChosen.GetComponent<ItemFunction>().ForgeItemSelected();
				LastPartChosen = PartChosen;
				ForgePart = LastPartChosen;
			}

		}
		else if (partSlot.tag == "MaterialChoice")
		{



			MatChosen = partSlot;

			if (LastMatChosen == null)
			{
				Debug.Log("NewPartChosen");
				MatChosen.GetComponent<ItemFunction>().ForgeItemSelected();
				LastMatChosen = MatChosen;
				ForgeMaterial = LastMatChosen;

			}
			else if (MatChosen == LastMatChosen)
			{
				Debug.Log("SamePartChosen");

				MatChosen.GetComponent<ItemFunction>().ForgeDeselectItem();
				LastMatChosen = null;
				ForgeMaterial = null;

			}
			else if (LastMatChosen != null && MatChosen != LastMatChosen)
			{
				Debug.Log("SwappedPart");
				LastMatChosen.GetComponent<ItemFunction>().ForgeDeselectItem();
				MatChosen.GetComponent<ItemFunction>().ForgeItemSelected();
				LastMatChosen = MatChosen;
				ForgeMaterial = LastMatChosen;
			}
			


		}

	}

	
}
