using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats player;
    CircleCollider2D playerCollector;
    public float pullSpeed;

    [SerializeField] private AudioSource collectionSoundEffect;
     void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
    }

     void Update()
    {
        playerCollector.radius = player.CurrentMagnet;   
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out ICollectable collectable))
        {
            
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            collectionSoundEffect.Play();
            Vector2 forceDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(forceDirection * pullSpeed);

            collectable.Collect(); 
        }
    }
}
