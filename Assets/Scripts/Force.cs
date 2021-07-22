using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public static IEnumerator ForceInDirection(Rigidbody2D rb, Vector2 force, float dumping)
    {
        while (Mathf.Abs(force.x) > 1f || Mathf.Abs(force.y) > 1f)
        {
            rb.AddForce(force);
            force /= dumping;
            yield return null;
        }
    }
}
