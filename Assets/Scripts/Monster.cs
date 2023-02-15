using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public float speed;
    private Rigidbody2D mybody;
    void Awake()
    {
        mybody=GetComponent<Rigidbody2D>();
  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mybody.velocity=new Vector2(speed,mybody.velocity.y);
    }
}
