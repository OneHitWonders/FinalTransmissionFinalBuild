using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{

    public Dialouge dialouge;
    public GameObject guiObject;

    public void TriggerDialouge(Dialouge t)
    {

        FindObjectOfType<DialougeManager>().StartDialogue(t);

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.tag == "NPC")
                {
                    Dialouge trig = hit.collider.gameObject.GetComponent<Dialouge>();

                    TriggerDialouge(trig);
                }

            }

        }

        //void OnTriggerStay(Collider other)
        //{
        //    if (other.gameObject.tag == "Survivor")
        //    {
        //        guiObject.SetActive(true);
        //        if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
        //        {
        //            Dialouge trig = gameObject.GetComponent<Dialouge>();

        //            TriggerDialouge(trig);
        //        }
        //    }
        //}
    }
}
