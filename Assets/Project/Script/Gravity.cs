using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] float gravityPower;

    [SerializeField] float drag;

    public void GetGravity(Rigidbody2D rb)
    {
        rb.drag = drag;

        Vector2 dir = (rb.position - (Vector2)transform.position).normalized;

        Vector2 gravityForce = -dir * gravityPower;

        rb.AddForce(gravityForce);
    }
}
