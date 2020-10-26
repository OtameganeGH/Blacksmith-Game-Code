using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTipBehaviour : MonoBehaviour 
{
	public GameObject toolTipMenu;
	public Text toolTipPrice, toolTipQuality, toolTipName;

	public GameObject ItemToRead;
	float price = 0, quality = 0;
	string itemName = "";
	List<RaycastResult> raycastResultList;

	// Start is called before the first frame update
	void Start()
    {
		toolTipPrice.text = ( "0G");
		toolTipQuality.text = ("Quality: ");
		toolTipName.text = itemName;
	}

	// Update is called once per frame

	

	public void ShowTooltip(ItemFunction item) {

		toolTipPrice.text = (item.GetPrice() + "G");

		float  newQual;
		float oldQual = item.GetQuality();
		newQual = (Mathf.RoundToInt(oldQual / 0.5f) * 0.5f);
		toolTipQuality.text = (newQual + " / 5");
			   		 
		toolTipName.text = item.GetName();
		toolTipMenu.SetActive(true);
	}
	public void HideToolTip()
	{
		toolTipMenu.SetActive(false);
	}
	

}
