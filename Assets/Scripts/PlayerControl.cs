using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public Rigidbody rb;
    public GameObject rock;
    public GameObject spine;
    public Vector3 myjump = new Vector3(0, 50f, 0);
    public static int health = 2;
    float timer = 0;
    public static bool in_air = false;
    public Animator m_animator;
    Vector3 temp;
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && in_air==false)
        {
            rb.velocity = myjump;
            spine.layer = 11;
            in_air = true;
            //rb.useGravity = false;
            m_animator.SetTrigger("HurtFront");
        }
        if (in_air == true && timer < 0.5f)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= 0.5f)
        {
            spine.layer = 8;
            timer = 0;
            in_air = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
           // m_animator.SetTrigger("Attack2");
            spine.layer = 11;
            in_air = true;
        }
        if (Input.GetKeyDown("a") && in_air==false)
        {
            m_animator.SetTrigger("HurtFront");
            in_air = true;
            //rb.useGravity = false;
            rb.velocity = myjump;
        }
        if (Input.GetKeyDown("q"))
        {
        m_animator.SetTrigger("Attack1");
        temp = spine.transform.position;
        temp.x += 0.5f;
        temp.y += 0.5f;
        Instantiate(rock, temp, Quaternion.identity);
        }
    }
    public void Die() {
        m_animator.SetTrigger("Die");
        Destroy(gameObject, 1);
    }
}
