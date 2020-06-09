using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public float enemySpeed = 40;
    private Transform target;
    public bool FacingLeft = true;
    Movement movement = new Movement();
    public Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (target.position.x > transform.position.x && FacingLeft == true)
        {
            FacingLeft = false;
            transform.Rotate(0, 180f, 0);
        }
        else if (target.position.x < transform.position.x && FacingLeft == false)
        {
            FacingLeft = true;
            transform.Rotate(0, 180f, 0);
        }

    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
    }
}
