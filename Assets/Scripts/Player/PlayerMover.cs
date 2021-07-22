using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{


    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private VariableJoystick vj;
    private Rigidbody2D rb;
    private float moveInputHor;
    private float moveInputVert;
    public float MoveInputHor
    {
        get
        {
            return moveInputHor;
        }
    }
    public float MoveInputVert
    {
        get
        {
            return moveInputVert;
        }
    }


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInputHor = vj.Horizontal;
        rb.velocity = new Vector2(moveInputHor * speed, rb.velocity.y);

        moveInputVert = vj.Vertical;
        rb.velocity = new Vector2(rb.velocity.x, moveInputVert * speed);
    }
}
