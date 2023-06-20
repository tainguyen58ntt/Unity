using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    public Vector2 lastMoveVector;


    new Rigidbody2D rigidbody2D;
    PlayerStats player;
    void Start()
    {
        player = GetComponent<PlayerStats>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        lastMoveVector = new Vector2(1, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }
    private void FixedUpdate()
    {
        Move(); 
    }

    void InputManagement()
    {

        if (GameManager.instance.isGameOver)
        {
            return;
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;
        if(moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMoveVector = new Vector2(lastHorizontalVector, 0f);
        }
        if(moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMoveVector = new Vector2(0f, lastVerticalVector);

        }
        if (moveDir.y != 0 && moveDir.x!=0)
        {
            lastVerticalVector = moveDir.y;
            lastMoveVector = new Vector2(lastHorizontalVector, lastVerticalVector);

        }
    }

    private void Move()
    {

        if (GameManager.instance.isGameOver)
        {
            return;
        }
        rigidbody2D.velocity = new Vector2(moveDir.x * player.CurrentMoveSpeed, moveDir.y * player.CurrentMoveSpeed);           
    }

}
