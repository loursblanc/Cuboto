using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    public int speed = 5;

    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody2D.AddForce((Vector2.left * 0.1f), ForceMode2D.Impulse);
        
        if(transform.position.x < -17)
        {
            Destroy(this.gameObject);
        }
    }
}
