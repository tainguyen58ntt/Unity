using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimesMove : MonoBehaviour
{
    // Start is called before the first frame update
    EnimyStats enimy;
    Transform player;

    void Start()
    {
        enimy = GetComponent<EnimyStats>();
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enimy.currentMovespeed * Time.deltaTime);
    }
}
