 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0) //direita
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0) //esqerda
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }
        if (player.isDigging)
        {
            anim.SetInteger("transition", 4);
        }
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion
}
