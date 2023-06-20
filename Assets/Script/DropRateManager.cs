using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float DropRate;
    }
    public List<Drops> drops;

     void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            return;
        }
        float randomNumber = UnityEngine.Random.Range(0, 100f);
        List<Drops> PossibleDrops = new List<Drops>();
        foreach (Drops rate in drops)
        {
            if(randomNumber <= rate.DropRate)
            {
                PossibleDrops.Add(rate);
            }
        }
        if(PossibleDrops.Count > 0)
        {
            Drops drops = PossibleDrops[UnityEngine.Random.Range(0, PossibleDrops.Count)];
            Instantiate(drops.itemPrefab, transform.position, Quaternion.identity);

        }

    }
}
