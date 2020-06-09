using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 25f;
    public bool facingLeft = false;
    public Transform character;
    public Animator anim;
    private float jump = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
     
        GetComponent<Rigidbody2D>().velocity = new Vector3(move * maxSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        if (move < 0f && !facingLeft)
        {

            Flip();
        }
        else if (move > 0f && facingLeft)
        {
            Flip();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("chop", true);
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("chop", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            if (jump == 4f) jump = -2f;
            else jump = 4f;
        }
      
    }
    
    


    //flip if needed
    void Flip()
    {
        facingLeft = !facingLeft;
        character.Rotate(0, 180f, 0);
        
       
        
    }


    
}
