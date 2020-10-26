using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{

    public GameObject Inventory, player, canvas, cam, menu1, menu2;
	public bool invOpen, otherInvOpen, menuOpen;
    // Start is called before the first frame update
    void Start()
    {
        invOpen = false;
		menuOpen = false;
        player = GameObject.Find("Player");
		canvas = GameObject.Find("Canvas");

	}

	// Update is called once per frame
	void Update()
	{
		otherInvOpen = cam.GetComponent<HoverOver>().interactInvOpen;
		if (Input.GetKeyDown(KeyCode.I) && invOpen == false && otherInvOpen == false)
		{
			Inventory.SetActive(true);
			invOpen = true;
			cam.GetComponent<PlayerMovement>().ToggleCursor();
		}
		else if (Input.GetKeyDown(KeyCode.I) && invOpen == true && otherInvOpen == false)
		{
			Inventory.SetActive(false);
			invOpen = false;
			canvas.GetComponent<ItemSelectManager>().ClearItem();
			cam.GetComponent<PlayerMovement>().ToggleCursor();

		}
		if (Input.GetKeyDown(KeyCode.Escape) && menuOpen == false && otherInvOpen == false)
		{
			menu1.SetActive(true);
			menu2.SetActive(true);
			menuOpen = true;
			cam.GetComponent<PlayerMovement>().ToggleCursor();
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && menuOpen == true && otherInvOpen == false)
		{
			menu1.SetActive(false);
			menu2.SetActive(false);
			menuOpen = false;
			cam.GetComponent<PlayerMovement>().ToggleCursor();
		}
	}
}
