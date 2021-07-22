using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] protected float speed;
    [SerializeField] protected float knockbackForce;
    [SerializeField] private Animator animator;

    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    



    public void ApplyDamage(int amount)
    {
        hp -= amount;
        animator.Play("Fade");
        if (hp <= 0)
            EnemyDead();
    }

    private void EnemyDead()
    {
        PlayerStatus.ScoreAdd(10);
        Destroy(GetComponent<Collider2D>());
        Destroy(gameObject, 2f);
        animator.Play("Death");
    }

}
