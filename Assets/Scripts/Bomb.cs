using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject bombExplosionEffect;
    [SerializeField] private float timeBeforeExplosion;
    [SerializeField] private float radiusOfExplosion;
    [SerializeField] private float knockbackForce;
    [SerializeField] private LayerMask damagableLayers;

    private void Start()
    {
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(timeBeforeExplosion);
        Destroy(Instantiate(bombExplosionEffect, transform.position, Quaternion.identity), 1f);

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radiusOfExplosion, damagableLayers);

        foreach (Collider2D hit in hits)
        {
            float localX = (hit.gameObject.transform.position.x - transform.position.x);
            float localY = (hit.gameObject.transform.position.y - transform.position.y);
            Vector2 pushVector = new Vector2(localX, localY).normalized * knockbackForce;
            StartCoroutine(Force.ForceInDirection(hit.gameObject.GetComponent<Rigidbody2D>()
                , pushVector, 1.1f));

            if (hit.gameObject.GetComponent<PlayerStatus>() != null)
                hit.gameObject.GetComponent<PlayerStatus>().ApplyDamage(1);
            if (hit.gameObject.GetComponent<Enemy>() != null)
                hit.gameObject.GetComponent<Enemy>().ApplyDamage(1);
        }
        Destroy(gameObject.GetComponent<SpriteRenderer>());

        Destroy(gameObject, 2f);

    }





}
