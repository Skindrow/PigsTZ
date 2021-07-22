using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Enemy
{
    [SerializeField] private GameObject[] directions;
    [SerializeField] private float walkingTick;
    [SerializeField] private Sprite[] directionsSprites;
    [SerializeField] private SpriteRenderer sr;

    private void Start()
    {
        StartCoroutine(RandomWalking());
    }

    private IEnumerator RandomWalking()
    {
        while (true)
        {

            int index = Random.Range(0, directions.Length);
            Vector2 directionPos = directions[index].transform.position;
            sr.sprite = directionsSprites[index];
            for (int j = 0; j < walkingTick; j++)
            {
                transform.position = Vector2.MoveTowards(transform.position, directionPos, speed / 100);
                yield return new WaitForFixedUpdate();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStatus>() != null)
        {
            PlayerStatus ps = collision.gameObject.GetComponent<PlayerStatus>();
            ps.ApplyDamage(1);

            float localX = (collision.gameObject.transform.position.x - transform.position.x);
            float localY = (collision.gameObject.transform.position.y - transform.position.y);
            Vector2 pushVector = new Vector2(localX, localY).normalized * knockbackForce;
            StartCoroutine(Force.ForceInDirection(collision.gameObject.GetComponent<Rigidbody2D>()
                , pushVector, 1.1f));
        }
    }



}
