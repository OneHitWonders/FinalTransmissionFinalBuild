using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    public GameObject ObjectToMoveTo;
    private Mover mover;
    bool canMove = true;
    public Transform target;
    public float range;
    public float distance;
    public int health = 100;
    public float speed = 5.0f;

    void Start()
    {
        mover = gameObject.GetComponent<Mover>();
    }

    void Update()
    {

        distance = Vector3.Distance(transform.position, target.position);

        if (distance < range)

            if (canMove)
                mover.MoveTo(ObjectToMoveTo);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Survivor")
        {
            health = health - (Random.Range(12, 18));

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (other.gameObject.tag == "Bullet")
        {
            health = health - 50;
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Survivor")
        {
            canMove = true;

        }
    }
}