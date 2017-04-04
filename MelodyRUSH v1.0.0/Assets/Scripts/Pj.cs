using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Pj : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject[] _platforms;
    List <GameObject> platforms = new List<GameObject>();
    public float jumpForce = 12f;
    public float speed = 6;
    int counter = 0;
    int assign = 0;
    string label = "nada";
    int direction = 1;
    int gravityDirection = 1;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _platforms = GameObject.FindGameObjectsWithTag("Plataforma");

        
    }
    void Start()
    {
        AddToList();
        print(_platforms.Length);
        print(platforms.Count);
    }
    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                label = "verde";
                CheckKey();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                label = "rojo";
                CheckKey();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                label = "amarillo";
                CheckKey();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                label = "azul";
                CheckKey();
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                label = "naranja";
                CheckKey();
            }
        }

    }
    void CheckKey()
    {
        platforms[counter].SendMessage("Compare", label);
       
    }
    public void addCounter()
    {
        if (counter < _platforms.Length - 1)
        {
            counter++;
        }
    }
    void AddToList()
    {
        if (assign<_platforms.Length)
        {
            for(int i =0;i<_platforms.Length;i++)
            {
                if (_platforms[i].GetComponent<Platform>().index==assign)
                {
                    platforms.Add(_platforms[i]);
                    assign++;
                    AddToList();
                }
            }
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce((Vector2.up * jumpForce)*gravityDirection,ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jumper"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            Jump();
        }
        if (other.CompareTag("GravityInverter"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            gravityDirection *= -1;
            rb.gravityScale *= gravityDirection;
        }
        if (other.CompareTag("DirectionInverter"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            direction *= -1;
        }
    }
}
