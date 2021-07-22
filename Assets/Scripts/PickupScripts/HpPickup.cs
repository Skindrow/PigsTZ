using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPickup : MonoBehaviour
{
    [SerializeField] private float timeBeforeDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStatus>() != null)
        {
            collision.gameObject.GetComponent<PlayerStatus>().HpCount++;
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }
}
