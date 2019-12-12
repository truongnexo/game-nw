using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrValentine : Enemy
{
    private Rigidbody2D r2D;
    private Animator anim;
    /// <summary>
    /// 
    /// </summary>
    public void Start()
    {
        // khoi tao doi tuong
        r2D = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public override void FixedUpdate()
    {
        Movement();

    }
    void Movement()
    {
        Vector3 temp = transform.localScale;
        speed = 0;
        //anim.SetBool("Hit", false);
        anim.SetBool("Walk", false);
        // lay khoang cach tu skeleton toi player
        distance = Vector2.Distance(transform.position, player.position);

        // cho quai thuc day khi player nam trong khoang distanceMIN va ngu lai khi player ra khoi
        if (player.transform.position.x > this.transform.position.x && distance < distanceMIN)
        {
            speed = 0.4f;
            anim.SetBool("Walk", true);
            temp.x = 3f;
            transform.localScale = temp;
            // neu player den qua gan thi Attack
            if (distance <= 1.2)
            {
                anim.SetBool("Attack", true);
                speed = 0;
            }
            else
            {
                anim.SetBool("Attack", false);
                speed = 0.2f;
            }
        }
        else

        if (player.transform.position.x < this.transform.position.x && distance < distanceMIN)
        {
            speed = 0.4f;
            r2D.AddForce(Vector2.left * speed);
            anim.SetBool("Walk", true);
            temp.x = -3f;
            transform.localScale = temp;
            if (distance < 1.2)
            {
                anim.SetBool("Attack", true);
                speed = 0;
            }
            else
            {
                anim.SetBool("Attack", false);
                speed = 0.2f;
            }
        }
        colliderPlayer = Physics2D.Linecast(pointA.position, pointB.position, 1 << 8); // tra ve gia tri true khi pointB ra khoi ground
        Debug.DrawLine(pointA.position, pointB.position, Color.green);
        if (!colliderPlayer)
        {
            speed = 0;
            anim.SetBool("Walk", false);
        }


        if (health <= 0)
        {
            anim.SetTrigger("Death");
            Destroy(gameObject);
        }

        r2D.velocity = new Vector2(transform.localScale.x, 0) * speed;
        Check_Sword_Arc();
        Check();
    }

    //kiem tra xem player co chem chung khong
    void Check_Sword_Arc()
    {
        float checkSword = Vector2.Distance(Sword_Arc.position, transform.position); // khoang cach giua vet chem voi enemy
        //Debug.Log("distanceSword" + checkSword);
        if (checkSword < 1 && Input.GetMouseButtonDown(0))
        {
            health -= 10;
            //anim.SetBool("Hit", true);
            anim.SetTrigger("Hit");
            r2D.AddForce(Vector2.right * speed * 0);
        }
    }
    private void Check()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
