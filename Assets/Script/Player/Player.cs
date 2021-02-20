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

    //[SerializeField]
    //private bool _grounded = false;

    [SerializeField]
    private float _jumpForced = 5f;

    [SerializeField]
    private LayerMask _groundLayerMask;

    private bool resetJumpNeeded = false;

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

        movement();




    }

    void movement()
    {
        transalation = Input.GetAxis("Horizontal");
        _rigid.velocity = new Vector2(transalation, _rigid.velocity.y); // left & right movement

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true) // jump
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForced);

            StartCoroutine(ResetJummpedRoutine());
        }

    }

    bool isGrounded()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 5f, _groundLayerMask);
        Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.green);


        if (hitInfo.collider != null)
        {

            //return resetJumpNeeded = true;
            if (resetJumpNeeded == false)
                return true;
        }

      return  false;

    }

    IEnumerator ResetJummpedRoutine()
    {
        resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);

        resetJumpNeeded = false;
    }
}
