using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    private Collider2D _collider2D;
    private int count=0;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            count++;
            Debug.Log(count);
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
        }
        
    }
}