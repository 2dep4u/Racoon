using UnityEngine;
using System.Collections;

public class peanut : MonoBehaviour {
    float angle = 0;
    public GameObject sparkle;
    void OnTriggerEnter() {
        sparkle=(GameObject)Instantiate(sparkle, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(sparkle, 0.5f);
    }
    void Update() {
        angle += 2f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
