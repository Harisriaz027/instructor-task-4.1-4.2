using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject[] player;
    public float speed = 1;
    private Rigidbody enemyRb;
    public bool ispresent = true;
    public GameObject active;
    int r;
    void Start()
    {
        active = RandomEnemy();
        enemyRb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (ispresent == true && player[r] != null)
        {
            Vector3 lookDirection = (player[r].transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed * 3);


            if (transform.position.y < -.5f)
            {
                Destroy(gameObject);
            }
            else if (player[r].transform.position.y < -.5f)
            {
                ispresent = false;
                Destroy(player[r].gameObject);
                RandomEnemy();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject==player[r])
        {
            
            Vector3 push = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(push * 6, ForceMode.Impulse);
       }

    }
    public GameObject RandomEnemy()
    {
        r = Random.Range(0, player.Length);
        ispresent = true;
        return player[r];
    }
}
