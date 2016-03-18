using UnityEngine;
using System.Collections;

public class motion : MonoBehaviour
{
    public float jumpHeight;
    public float timeToHeight;
    private float gravity;
    public int Health = 6;
    private float jumpSpeed;
    private Vector3 jumpVelocity;
    private Animator m_animator;
    public static bool isJump;
    float timer = 0;
    private Rigidbody rb;
    private CapsuleCollider cd;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<CapsuleCollider>();
        m_animator = GetComponent<Animator>();
        isJump = false;
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToHeight, 2);
        Physics.gravity = new Vector3(0, gravity, 0);
        jumpSpeed = Mathf.Abs(gravity) * timeToHeight;
        jumpVelocity = new Vector3(0f, jumpSpeed, 0f);

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 14)
        {
            healthdown(1);
        }
        else if (other.gameObject.layer == 15)
        {
            healthup(1);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            cd.isTrigger = false;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isJump)
        {
            m_animator.SetTrigger("Jump");
            rb.velocity = jumpVelocity;
            isJump = true;
            gameObject.layer = 11;
        }
        if (isJump == true && timer < 0.7f)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= 0.7f && isJump == true)
        {
            gameObject.layer = 8;
            timer = 0;
        }
        if (Input.GetMouseButtonDown(1))
        {
            cd.isTrigger = true;
        }
    }
    public void healthup(int up)
    {
        Health += up;
    }
    public void healthdown(int down)
    {
        Health -= down;
    }
}
