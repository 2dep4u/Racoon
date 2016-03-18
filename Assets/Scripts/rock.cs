using UnityEngine;
using System.Collections;

public class rock : MonoBehaviour {
    public Vector3 mythrow;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        mythrow = new Vector3(10f, 10f, 0);
        rb.velocity = mythrow;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (transform.position.y < -10f) {
            Destroy(gameObject);
        }
    }
}
