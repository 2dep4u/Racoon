using UnityEngine;
using System.Collections;

public class tempMotionControl : MonoBehaviour
{
    public float jumpHeight;
    public float timeToHeight;
    private float gravity;
    public int Health = 6;
    private float jumpSpeed;
    private Vector3 jumpVelocity;
    private Animator m_animator;
    public static bool isJump;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
        isJump = false;
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToHeight, 2);
        Physics.gravity = new Vector3(0, gravity, 0);
        jumpSpeed = Mathf.Abs(gravity) * timeToHeight;
        jumpVelocity = new Vector3(0f, jumpSpeed, 0f);

    }
    void OnCollisionEnter(Collision other)
    {
        isJump = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isJump)
        {
            m_animator.SetTrigger("Jump");
            rb.velocity = jumpVelocity;
            isJump = true;
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
