using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D _rigid;
    SpriteRenderer spriteRenderer;
 
    private float transalation;

    [SerializeField]
    private float _jumpForced = 5f;

    [SerializeField]
    private LayerMask _groundLayerMask;

    private bool resetJumpNeeded = false;
    private bool isCheckGrounded = false;

    [SerializeField]
    private float _playerSpeed = 5f;

   private PlayerAnimation anim;



    void Start()
    {
        anim = GetComponent<PlayerAnimation>();
        _rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        movement();
        Attack();
        isCheckGrounded = isGrounded();
    }

    void movement()
    {
        transalation = Input.GetAxisRaw("Horizontal");

        Flip(transalation);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true) // jump
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForced);
            anim.isJump(true);
            //anim.isAttack();
            StartCoroutine(ResetJummpedRoutine());

        }

        _rigid.velocity = new Vector2(transalation * _playerSpeed, _rigid.velocity.y); // left & right movement
        anim.Move(transalation);

    }

    bool isGrounded()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 5f, _groundLayerMask);
        Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.green);


        if (hitInfo.collider != null)
        {
            if (resetJumpNeeded == false)
            {
                anim.isJump(false);
                return true;
            }
               
        }

      return  false;

    }

    void Attack()
    {
        if ((Input.GetButton("Fire1") && isCheckGrounded == true)){
            anim.isAttack();
        }
    }


    /// <summary>
    ///
    ///
    ///  Move Left and right : solution-1
    ///  
    /// </summary>
    /// <param name="move"></param>
    ///

    void Flip (float move)
    {
        if(move > 0)
        {
            spriteRenderer.flipX = false;
        }else if(move < 0)
        {
            spriteRenderer.flipX = true;
        }
    }


    IEnumerator ResetJummpedRoutine()
    {
        resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);

        resetJumpNeeded = false;
    }
}
