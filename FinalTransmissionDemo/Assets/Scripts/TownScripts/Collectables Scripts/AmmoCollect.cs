using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollect : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);

    }


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerCollect>().ammo++;
        if (other.tag == "Survivor")
        {
            //add ammo
            Destroy(gameObject);//remove crate
        }

    }
}
