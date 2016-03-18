using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public Transform player;
    Vector3 temp;
    void Start() {
        temp.x = player.position.x + 4;
        temp.z = -10f;
    }
	void Update () {
        temp.y = player.position.y;
        transform.position = temp;
	}
}
