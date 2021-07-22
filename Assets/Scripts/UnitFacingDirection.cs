using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFacingDirection : MonoBehaviour
{
    [SerializeField] private Sprite spriteUpward;
    [SerializeField] private Sprite spriteDownward;
    [SerializeField] private Sprite spriteGorizontal;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private PlayerMover pm;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (pm.MoveInputHor < 0)
        {
            sr.sprite = spriteGorizontal;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (pm.MoveInputHor > 0)
        {
            sr.sprite = spriteGorizontal;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (pm.MoveInputVert > 0 && Mathf.Abs(pm.MoveInputHor) < Mathf.Abs(pm.MoveInputVert))
        {
            sr.sprite = spriteUpward;
        }
        else if (pm.MoveInputVert < 0 && Mathf.Abs(pm.MoveInputHor) < Mathf.Abs(pm.MoveInputVert))
        {
            sr.sprite = spriteDownward;
        }


    }
}
