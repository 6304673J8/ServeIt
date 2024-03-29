using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterController: MonoBehaviour
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
    public int addedScore;

    [SerializeField]
    private int ServeTime;

    [SerializeField]
    TextMeshProUGUI _insertScoreText;

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

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 10, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, RayDist, HittableLayer);
            if (hit)
            {
                Debug.Log("Hit Something " + hit.collider.name);
            }
        }*/
    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + Movement * WalkSpeed * Time.fixedDeltaTime);
    }

    private void RaycastingCheck()
    {
        RaycastHit2D hitInfoHorizontalLeft = Physics2D.Raycast(transform.position, -Vector2.right, RayDist, HittableLayer);
        RaycastHit2D hitInfoHorizontalRight = Physics2D.Raycast(transform.position, transform.right, RayDist, HittableLayer);
        RaycastHit2D hitInfoVerticalUp = Physics2D.Raycast(transform.position, transform.up, RayDist, HittableLayer);
        RaycastHit2D hitInfoVerticalDown = Physics2D.Raycast(transform.position, Vector2.down, RayDist, HittableLayer);
        if (hitInfoVerticalUp.collider != null)
        {
            Debug.Log("Hitting: " + hitInfoVerticalUp.collider.tag);
          
            if (hitInfoVerticalUp.collider.tag == "Objective")
            {
                hitInfoVerticalUp.collider.gameObject.GetComponent<TableBehaviour>().Interact();
                hitInfoVerticalUp.collider.gameObject.GetComponent<TableBehaviour>().timesServed++;
                Debug.Log("Objective Up");
                Debug.DrawRay(transform.position, transform.up, Color.red);
            }
            else if (hitInfoVerticalUp.collider.tag == "ObjectiveTwo")
            {
                hitInfoVerticalUp.collider.gameObject.GetComponent<TableBehaviourTwo>().Interact();
                hitInfoVerticalUp.collider.gameObject.GetComponent<TableBehaviourTwo>().timesServed++;
                Debug.Log("Objective Up");
                Debug.DrawRay(transform.position, transform.up, Color.red);
            }
        }
        else if (hitInfoVerticalDown.collider != null)
        {
            Debug.Log("Hitting: " + hitInfoVerticalDown.collider.tag);

            if (hitInfoVerticalDown.collider.tag == "Objective")
            {
                hitInfoVerticalDown.collider.gameObject.GetComponent<TableBehaviour>().Interact();
                hitInfoVerticalDown.collider.gameObject.GetComponent<TableBehaviour>().timesServed++;
                Debug.Log("Objective Down");
                Debug.DrawRay(transform.position, -transform.up, Color.red);
            }
            else if (hitInfoVerticalDown.collider.tag == "ObjectiveTwo")
            {
                hitInfoVerticalDown.collider.gameObject.GetComponent<TableBehaviourTwo>().Interact();
                hitInfoVerticalDown.collider.gameObject.GetComponent<TableBehaviourTwo>().timesServed++;
                Debug.Log("Objective Down");
                Debug.DrawRay(transform.position, -transform.up, Color.red);
            }
        }
        else if (hitInfoHorizontalLeft.collider != null)
        {
            Debug.Log("Hitting: " + hitInfoHorizontalLeft.collider.tag);

            if (hitInfoHorizontalLeft.collider.tag == "Objective")
            {
                hitInfoHorizontalLeft.collider.gameObject.GetComponent<TableBehaviour>().Interact();
                hitInfoHorizontalLeft.collider.gameObject.GetComponent<TableBehaviour>().timesServed++;
                Debug.Log("Objective Left");
                Debug.DrawRay(transform.position, -transform.right, Color.red);
            }
            else if (hitInfoHorizontalLeft.collider.tag == "ObjectiveTwo")
            {
                hitInfoHorizontalLeft.collider.gameObject.GetComponent<TableBehaviourTwo>().Interact();
                hitInfoHorizontalLeft.collider.gameObject.GetComponent<TableBehaviourTwo>().timesServed++;
                Debug.Log("Objective Left");
                Debug.DrawRay(transform.position, -transform.right, Color.red);
            }
        }
        else if (hitInfoHorizontalRight.collider != null)
        {
            Debug.Log("Hitting: " + hitInfoHorizontalRight.collider.tag);

            if ((hitInfoHorizontalRight.collider.tag == "Objective"))
            {
                hitInfoHorizontalRight.collider.gameObject.GetComponent<TableBehaviour>().Interact();
                hitInfoHorizontalRight.collider.gameObject.GetComponent<TableBehaviour>().timesServed++;

                Debug.Log("Objective Right");
                Debug.DrawRay(transform.position, transform.right, Color.red);
            }
            else if ((hitInfoHorizontalRight.collider.tag == "ObjectiveTwo"))
            {
                hitInfoHorizontalRight.collider.gameObject.GetComponent<TableBehaviourTwo>().Interact();
                hitInfoHorizontalRight.collider.gameObject.GetComponent<TableBehaviourTwo>().timesServed++;

                Debug.Log("Objective Right");
                Debug.DrawRay(transform.position, transform.right, Color.red);
            }
        }
    }

    public void AddToScore()
    {
        addedScore += 750;
        _insertScoreText.GetComponent<TextMeshProUGUI>().text = addedScore + "";
    }
}
