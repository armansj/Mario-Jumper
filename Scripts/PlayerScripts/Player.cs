using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=8.0f;
    public float maxVelocity = 4f;
    private Rigidbody2D myBody;
    private Animator anim;




    private void Awake()
    {

        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();


    }

    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {



    }


    private void FixedUpdate()
    {
        PlayerMove();

    }

    void PlayerMove()
    {

        float forceX = 0;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");


        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = speed;
            }
            ChangeDirection(1.3f);
            anim.SetBool("Walk", true);

            

        }


        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
                anim.SetBool("Walk", true);
            }

            ChangeDirection(-1.3f);

        }

        else
        {
            anim.SetBool("Walk", false);
            myBody.velocity = new Vector2(0, myBody.velocity.y);

        }
        myBody.AddForce(new Vector2(forceX, 0));
    }

    void ChangeDirection(float direction)
    {
        Vector3 temp = transform.localScale;
        temp.x = direction;
        transform.localScale = temp;

    }

   


}//class

