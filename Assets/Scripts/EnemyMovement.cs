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
    public int i;
    void Start()
    {
        i = 0;
        active = player[Random.Range(0, player.Length)];
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (ispresent == true && active != null)
        {
            Vector3 lookDirection = (active.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed * 3);

            if (active.transform.position.y < -.5f)
            { 
                Destroy(active.gameObject);
                active = null;
            }
        }
        
        if (transform.position.y < -.5f)
        {
                Destroy(gameObject);
        }
        
        if (ispresent == true && active == null) 
        { 
                RandomEnemy();
        }
        
        if (ispresent == false &&active != null)
        {
            ispresent = true;
        }

        if(ispresent==false&& active == null) 
        {
            enemyRb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject==active)
        {
            Vector3 push = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(push * 6, ForceMode.Impulse);
        }
    }

    public GameObject RandomEnemy()
    {
        active = player[i];

        if (active == null&&i<3)
        {
            i++;
            RandomEnemy();
        }

        if (active == null && i== 3)
        {
            ispresent = false ;
        }

        if (active != null && i <=3)
        {
            ispresent = true;
        }

        return active;
    } 
}
