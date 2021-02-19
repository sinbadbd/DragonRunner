using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D _rigid;
    SpriteRenderer spriteRenderer;
 
    public float transalation;

    //[SerializeField]
    //private float _speed = 0.5f;

    [SerializeField]
    private bool _grounded = false;

    [SerializeField]
    private float _jumpForced = 5f;

    [SerializeField]
    private LayerMask _groundLayerMask;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        transalation = Input.GetAxis("Horizontal");


        if(Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForced);
            _grounded = false;
        }


        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 5f, _groundLayerMask);
        Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.green);


        if (hitInfo.collider != null)
        {
            _grounded = true;
        }


        _rigid.velocity = new Vector2(transalation, _rigid.velocity.y); 
    }
}
