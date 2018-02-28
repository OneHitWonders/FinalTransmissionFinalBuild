using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject ObjectToMoveTo;
    private Mover mover;
    bool canMove = true;
    public float shotRate = 3f;
    private float shotCount = 0f;
    public Transform target;
    public float range;
    float distance;
    public int health = 100;

    void Start()
    {
        mover = GetComponent<Mover>();
    }

    void Update()
    {

        distance = Vector3.Distance(transform.position, target.position);

        if (distance < range)
        {
            if (distance < 50)
            {
                mover.speed = 0f;
                transform.LookAt(target);

                if (shotCount <= 0f)
                {

                    Fire();
                    shotCount = 10f / shotRate;
                }

                shotCount -= Time.deltaTime;
            }

            else if (distance > 50)
            {
                mover.speed = 15f;
                mover.MoveTo(ObjectToMoveTo);
            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }


        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Survivor")
        {
            mover.Stop();
            canMove = false;
            health = health - (Random.Range(3, 6));

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.tag == "Node")
        {
            var node = other.gameObject.GetComponent<PathNode>();

            if (node.NextNode != null)
            {
                ObjectToMoveTo = node.NextNode.gameObject;
            }
            else
                canMove = false;
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
            Update();
        }
    }

    public void Fire()
    {
        // Will create the bullet
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        //GameObject target = GameObject.FindGameObjectWithTag("Player");

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100;

        // Destroys the bullet after two seconds
        Destroy(bullet, 2.0f);
    }

}
