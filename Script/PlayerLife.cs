using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Load Scene

public class PlayerLife : MonoBehaviour
{
    public GameObject PlayerPS;

    private Animator anim;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            Death();
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("dieLine"))
        {
            Invoke("Restart", 0.5f);
            //Death();
            Debug.Log("Fall off");         
        }
    }
    
    private void Death()
    {
        Destroy(PlayerPS,1f);
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void Restart()//Reload Scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Load the current scene
    }
}
