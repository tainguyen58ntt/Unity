using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> TerrainChunks;
    public GameObject Player;
    public float CheckerRadius;
    Vector3 NoTerrianPosition;
    public LayerMask terrainMask;
    public GameObject currentChunck;
    PlayerMovement pm;

    [Header("optimazation")]
    public List<GameObject> spawnedChunks;
    public GameObject lastestChunk;
    public float maxOpti;
    float opDist;
    float optimizerCoolDown;
    public float optimizerCoolDownDur;
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimzer();
    }
    void ChunkChecker()
    {
        if (currentChunck == null)
        {
            return;
        }

        Vector3 targetPosition = Vector3.zero;

        if (pm.moveDir.x > 0)
        {
            if (pm.moveDir.y == 0)
            {
                targetPosition = currentChunck.transform.Find("Right").position;
            }
            else if (pm.moveDir.y > 0)
            {
                targetPosition = currentChunck.transform.Find("Right Up").position;
            }
            else
            {
                targetPosition = currentChunck.transform.Find("Right Down").position;
            }
        }
        else if (pm.moveDir.x < 0)
        {
            if (pm.moveDir.y == 0)
            {
                targetPosition = currentChunck.transform.Find("Left").position;
            }
            else if (pm.moveDir.y > 0)
            {
                targetPosition = currentChunck.transform.Find("Left Up").position;
            }
            else
            {
                targetPosition = currentChunck.transform.Find("Left Down").position;
            }
        }
        else
        {
            if (pm.moveDir.y > 0)
            {
                targetPosition = currentChunck.transform.Find("Up").position;
            }
            else if (pm.moveDir.y < 0)
            {
                targetPosition = currentChunck.transform.Find("Down").position;
            }
        }

        if (targetPosition != Vector3.zero && !Physics2D.OverlapCircle(targetPosition, CheckerRadius, terrainMask))
        {
            NoTerrianPosition = targetPosition;
            SpawnChunk();
        }
    }


    void SpawnChunk()
    {
        int rand = Random.Range(0, TerrainChunks.Count);
        lastestChunk = Instantiate(TerrainChunks[rand], NoTerrianPosition, Quaternion.identity);
        spawnedChunks.Add(lastestChunk);
    }
    void ChunkOptimzer() 
    {
        optimizerCoolDown -= Time.deltaTime;
        if(optimizerCoolDown < 0f)
        {
            optimizerCoolDown = optimizerCoolDownDur;
        }
        else
        {
            return;
        }

        foreach(GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(Player.transform.position, chunk.transform.position);
            if(opDist > maxOpti)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
