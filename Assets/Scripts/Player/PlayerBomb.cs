using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBomb : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private Bomb bombPrefab;
    [SerializeField] private Button bombButton;
    void Start()
    {
        bombButton.onClick.AddListener(BombPut);
    }



    private void BombPut()
    {
        if (playerStatus.BombCount > 0)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            playerStatus.BombCount--;
        }
    }
}
