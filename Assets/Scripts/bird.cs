using UnityEngine;
using System.Collections;

public class bird : MonoBehaviour {
    public GameObject birdcrap;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
        if (Random.value < 0.05)
            Instantiate(birdcrap, transform.position, Quaternion.identity);
    }
}
