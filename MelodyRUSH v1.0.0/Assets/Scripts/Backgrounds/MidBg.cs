using System.Collections;
using UnityEngine;

public class MidBg : MonoBehaviour {

    Pj target;
    Rigidbody2D rb;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Pj>();
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (rb != null)
            rb.velocity = target.speedReference / 2;
        else
            Awake();
    }
}
