using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    bool isJump = true;
    bool isDead = false;
    int idMove = 0;
    Animator anim;
    
    
    GameObject panelGameover;
    

    public float slideSpeed;
    private float slideTime;
    public float startSlideTime;
    private int direction;
    



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        slideTime = startSlideTime;

       
        panelGameover = GameObject.Find("PanelGameover");
        panelGameover.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Idle();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Slide();
        }



        Move();
        Dead();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Kondisi ketika menyentuh tanah
        if (isJump)
        {
            anim.ResetTrigger("Jump");
            if (idMove == 0) anim.SetTrigger("Idle");
            isJump = false;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Kondisi ketika menyentuh tanah
        anim.SetTrigger("Jump");
        anim.ResetTrigger("Run");
        anim.ResetTrigger("Idle");
        isJump = true;
    }

    public void MoveRight()
    {
        idMove = 1;
    }
    public void MoveLeft()
    {
        idMove = 2;
    }

    private void Move()
    {
        if (idMove == 1 && !isDead)
        {
            // Kondisi ketika bergerak ke kekanan
            if (!isJump) anim.SetTrigger("Run");
            transform.Translate(1 * Time.deltaTime * 2f, 0, 0);
            transform.localScale = new Vector3(0.2522252f, 0.2522252f, 0.2522252f);
        }

        if (idMove == 2 && !isDead)
        {
            // Kondisi ketika bergerak ke kiri
            if (!isJump) anim.SetTrigger("Run");
            transform.Translate(-1 * Time.deltaTime * 2f, 0, 0);
            transform.localScale = new Vector3(-0.2522252f, 0.2522252f, 0.2522252f);
        }
    }

    private void Slide()
    {
        if (idMove == 1 && !isDead)
        {
            // Kondisi ketika bergerak ke kekanan
            if (!isJump) anim.SetTrigger("Slide");
            transform.Translate(1 * Time.deltaTime * 2f, 0, 0);
            transform.localScale = new Vector3(0.2522252f, 0.2522252f, 0.2522252f);
        }

        if (idMove == 2 && !isDead)
        {
            // Kondisi ketika bergerak ke kiri
            if (!isJump) anim.SetTrigger("Slide");
            transform.Translate(-1 * Time.deltaTime * 2f, 0, 0);
            transform.localScale = new Vector3(-0.2522252f, 0.2522252f, 0.2522252f);
        }
    }
    public void Jump()
    {
        if (!isJump)
        {
            // Kondisi ketika Loncat
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
        }
    }

    public void Idle()
    {
        // kondisi ketika idle/diam
        if (!isJump)
        {
            anim.ResetTrigger("Jump");
            anim.ResetTrigger("Run");
            anim.SetTrigger("Idle");
        }
        idMove = 0;
    }
    private void Dead()
    {
        if (!isDead)
        {
            if (transform.position.y < -10f)
            {
                // kondisi ketika jatuh
                isDead = true;
                anim.SetTrigger("Death");
                panelGameover.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Coin"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
           
        }
        
    }
}
