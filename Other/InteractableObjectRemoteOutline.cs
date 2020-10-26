using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectRemoteOutline : MonoBehaviour
{
    // Start is called before the first frame update

    Outline outline;
    public bool OutlineToggle;
  
    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        OutlineToggle = false;
       

    }

    // Update is called once per frame
    void Update()
    {

        if (OutlineToggle == true)
        {

            outline.enabled = true;

        }
        else if (OutlineToggle == false)
        {
            outline.enabled = false;
        }



       
        OutlineToggle = false;
    }
}