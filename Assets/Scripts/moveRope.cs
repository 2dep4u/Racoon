using UnityEngine;
using System.Collections;

public class moveRope : MonoBehaviour {

    public int speedFactor;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-1 * speedFactor, 0, 0);
    }

}
