using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Components
    Animator anim;
    Rigidbody2D rb;
    public LayerMask HittableLayer;

    //Player
    public bool FacingRight = true;
    float WalkSpeed = 4f;
    float SpeedLimiter = 0.7f;
    float InputHorizontal;
    float InputVertical;
    Vector2 Movement;

    //Animation
    Animator animator;
    string CurrentState;

    bool isMoving;
    bool isServing;

    //Raycast
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public float RayDist;

    [SerializeField]
    private int ServeTime;

    public enum RayState
    {
        Miss,
        Hit
    }

    public RayState Raystate;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", Movement.x);
        animator.SetFloat("Vertical", Movement.y);
        animator.SetFloat("Speed", Movement.sqrMagnitude);
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastingCheck();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 10, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, RayDist, HittableLayer);
            if (hit)
            {
                Debug.Log("Hit Something " + hit.collider.name);
            }
        }
    }

    private void FixedUpdate()
    {        
        //Movement
        rb.MovePosition(rb.position + Movement * WalkSpeed * Time.fixedDeltaTime);
    }

    private void RaycastingCheck()
    {
        //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), RayDist);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, RayDist, HittableLayer);

        if (hitInfo)
            Debug.Log("HMMMMM");

        if (hitInfo.transform.CompareTag("Objective"))
        {
            Debug.Log("Objective");
            Debug.DrawRay(firePoint.position, rb.transform.forward, Color.red, 10.0f);

            //StartCoroutine(Serve());
        }
        else if (hitInfo.transform.CompareTag("Obstacles"))
        {
            //lineRenderer.enabled = false;
            Debug.Log("obstacle");
        }
        Debug.Log("Ojal");

    }

    /*IEnumerator Serve()
    {
        Debug.DrawRay(firePoint.position, rb.transform.forward, Color.red, 10.0f);
        yield return null;
    }*/
    /*void Update()
    { 
        InputHorizontal = Input.GetAxisRaw("Horizontal");    
        InputVertical = Input.GetAxisRaw("Vertical");    
    }

    private void FixedUpdate()
    {
        if (InputHorizontal != 0 || InputVertical != 0)
        {
            if (InputHorizontal != 0 && InputVertical != 0)
            {
                InputHorizontal *= SpeedLimiter;
                InputVertical *= SpeedLimiter;
            }
            rb.velocity = new Vector2(InputHorizontal * WalkSpeed, InputVertical * WalkSpeed);

            if (InputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
            else if (InputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            }
            else if (InputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }
            else if (InputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            ChangeAnimationState(PLAYER_IDLE);
        }
    }*/

    /*void ChangeAnimationState(string newState)
    {
        if (CurrentState == newState) return;

        //Play New Animation
        animator.Play(newState);

        //Update Current State
        CurrentState = newState;
    }
    */
    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
