using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedCollect : MonoBehaviour
{

    private Survivor survivor;

    // Use this for initialization
    void Start()
    {
        FindSurvivor();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);

    }


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerCollect>().medical++;
        if (other.tag == "Survivor")
        {
            //add ammo
            Destroy(gameObject);//remove crate
            survivor.playerHealth += 15;
        }

    }

    void FindSurvivor()
    {
        GameObject temp = GameObject.FindWithTag("Survivor");

        if (temp != null)
        {
            survivor = temp.GetComponent<Survivor>();
        }
        else
        {
            Debug.Log("No survivor detected");
        }
    }
}
