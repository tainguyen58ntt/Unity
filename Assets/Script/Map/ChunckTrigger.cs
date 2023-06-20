using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunckTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    MapController mc;
    public GameObject targetMap;

    void Start()
    {
        mc= FindObjectOfType<MapController>(); 
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mc.currentChunck = targetMap;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(mc.currentChunck == targetMap)
        {
            mc.currentChunck = null;
        }
    }
}
