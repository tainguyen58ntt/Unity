using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomChunk : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandom()
    {
        foreach (var prop in propSpawnPoints)
        {
            int rand = Random.Range(0, propSpawnPoints.Count);
            Instantiate(propPrefabs[rand], prop.transform.position, Quaternion.identity);
        }
    }
}
