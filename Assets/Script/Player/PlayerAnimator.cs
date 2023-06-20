using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    Animator am;
    PlayerMovement playerMovement;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement != null && playerMovement.moveDir != null && (playerMovement.moveDir.x != 0 || playerMovement.moveDir.y != 0))
        {
            am.SetBool("Move", true);
        }
        else
        {
            am.SetBool("Move", false);
        }
    }

    void LateUpdate()
    {
        if (playerMovement != null)
        {
            SpriteDirectionChecker();
        }
    }

    void SpriteDirectionChecker()
    {
        if (playerMovement.moveDir.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        
    }

}
