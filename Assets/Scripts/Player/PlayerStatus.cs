using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int bombCount;
    [SerializeField] private Text bombCountText;
    [SerializeField] private int hp;
    [SerializeField] private Text hpText;
    [SerializeField] private float timeOfInvul;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator animator;

    public static Text scoreText;
    public static int score = 0;

    private bool isInvul = false;


    private void Start()
    {
        bombCountText.text = bombCount.ToString();
        hpText.text = hp.ToString();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }
    public int BombCount
    {
        get
        {
            return bombCount;
        }
        set
        {
            if (BombCount < 0)
            {
                bombCount = 0;
            }
            bombCount = value;
            bombCountText.text = bombCount.ToString();
        }
    }
    public int HpCount
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            hpText.text = hp.ToString();
        }
    }

    public void ApplyDamage(int amount)
    {
        if (!isInvul)
        {
            animator.Play("Fade");
            hp -= amount;
            if (hp <= 0)
                PlayerIsDead();
            StartCoroutine(Invul());
        }

        hpText.text = hp.ToString();
    }

    private void PlayerIsDead()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator Invul()
    {
        isInvul = true;
        yield return new WaitForSeconds(timeOfInvul);
        isInvul = false;
    }
    public static void ScoreAdd(int amount)
    {
        score += amount;
        scoreText.text = "Score " + score.ToString();
    }


}
