using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb;

    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        print("distToPlayer" + distToPlayer);

        if(distToPlayer < agroRange)
        {
            //chase
            ChasePlayer();
            
        }
        else
        {
            //don't chase
            StopChasePlayer();
        }

    }

    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //on the left of player
            rb.velocity = new Vector2(moveSpeed, -5);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-moveSpeed, -5);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            StopChasePlayer();
        }

    }

    private void StopChasePlayer()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Death();
        }
    }

    private void Death()
    {
        anim.SetTrigger("Aggrodeath");
        Destroy(gameObject, 1f);
        //rb.bodyType = RigidbodyType2D.Static;
    }
}
