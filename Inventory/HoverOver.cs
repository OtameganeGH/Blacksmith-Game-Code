using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOver : MonoBehaviour
{
    string switchTag;
    public float rayLength;
	public GameObject forgeInv, enchantInv, craftInv, NPCInv, currOpenInv, hitGO, player, toolTip, canvas;
    public bool interactInvOpen, playerInvOpen, npcTalking;
	PlayerMovement playerTog;
	OpenInventory playerInv;

    // Start is called before the first frame update
    void Start()
    {
		npcTalking = false;
		player = GameObject.Find("Player");
        interactInvOpen = false;
        playerTog = this.GetComponent<PlayerMovement>();
		playerInv = player.GetComponent<OpenInventory>();
	}

    // Update is called once per frame
    void Update()
    {
		playerInvOpen = playerInv.invOpen;
        InteractionRay();
        if (hitGO != null)
        {
            if (hitGO.name == "Anvil" && Input.GetKeyDown(KeyCode.E) && interactInvOpen == false && playerInvOpen ==false)
            {
                craftInv.SetActive(true);
                currOpenInv = craftInv;
                interactInvOpen = true;
                Debug.Log("Anvil Interaction");
				playerInv.Inventory.SetActive(true);
                playerTog.ToggleCursor();
            }
            else if (hitGO.name == "Forge" && Input.GetKeyDown(KeyCode.E) && interactInvOpen == false && playerInvOpen == false)
            {
                forgeInv.SetActive(true);
                currOpenInv = forgeInv;
                interactInvOpen = true;
                Debug.Log("Forge Interaction");
				playerInv.Inventory.SetActive(true);
				playerTog.ToggleCursor();
            }
            else if (hitGO.name == "Enchanter" && Input.GetKeyDown(KeyCode.E) && interactInvOpen == false && playerInvOpen == false)
            {
                enchantInv.SetActive(true);
                currOpenInv = enchantInv;
                interactInvOpen = true;
                Debug.Log("Enchanter Interaction");
				playerInv.Inventory.SetActive(true);
				playerTog.ToggleCursor();
            }
			else if (hitGO.tag == "NPC" && Input.GetKeyDown(KeyCode.E) && interactInvOpen == false && playerInvOpen == false)
			{
				NPCInv.SetActive(true);
				currOpenInv = NPCInv;
				interactInvOpen = true;
				Debug.Log("NPC Interaction");
				playerInv.Inventory.SetActive(true);
				playerTog.ToggleCursor();

			}




            else if (Input.GetKeyDown(KeyCode.E) && interactInvOpen == true && npcTalking == false)
            {
				if(hitGO.name == "Enchanter")
					enchantInv.GetComponent<EnchantmentBehaviour>().EjectItems();
				else if (hitGO.tag == "NPC")
					NPCInv.GetComponent<SellItem>().EjectItems();
				else if (hitGO.name == "Anvil")
					canvas.GetComponent<CraftingBehaviour>().EjectItems();
				ClearInteractables();
			}

        } 

        
        
        
           
        
    }

    void InteractionRay()
    {
        Vector3 playerPos = transform.position;
        Vector3 forward = transform.forward;
        Ray InteractRay = new Ray(playerPos, forward);
        RaycastHit hit;
        Vector3 InteractRayEnd = forward * rayLength;
        Debug.DrawRay(playerPos, InteractRayEnd, Color.green);

        bool hitFound = Physics.Raycast(InteractRay, out hit, rayLength);
        if (hitFound)
        {

            hitGO = hit.transform.gameObject;

           
           

          
            if (hit.collider.tag == "Interactable") { 
            InteractableObjectRemoteOutline outline = hit.collider.gameObject.GetComponent<InteractableObjectRemoteOutline>();      

            if (outline != null)
            {                                  
                    outline.OutlineToggle = true;
            }
        }
           
        }
        if (hit.collider == null)
        {
            hitGO = null;
        }

    }
	public void ClearInteractables()
	{
		currOpenInv.SetActive(false);
		currOpenInv = null;
		interactInvOpen = false;
		playerInv.Inventory.SetActive(false);
		playerTog.ToggleCursor();
		toolTip.SetActive(false);
	}
}
