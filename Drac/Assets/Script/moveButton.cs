using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class moveButton : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float fallSpeed = 1f;

    Vector3 direction;

    void Start()
    {
        setFallSpeed();
        direction = Vector2.down;
    }

    void setFallSpeed()
    {
        rb.linearVelocity = Vector2.down * fallSpeed;
    }
}
