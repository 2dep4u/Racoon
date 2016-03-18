using UnityEngine;
using System.Collections;

public class poop : MonoBehaviour {
    public Vector3 movement;
    public PlayerControl player;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerControl>();
        }
        if (player == null)
        {
            Debug.Log("Cannot find 'player's script");
        }
        rb = GetComponent<Rigidbody>();

        movement = new Vector3(-1*(10*(Random.value)+5), 0, 0);

        rb.velocity = movement;
        Destroy(gameObject,1.5f);
    }
    void OnTriggerEnter(Collider other) {
        //if (other.gameObject.layer == 8 || other.gameObject.layer == 11)
        //    PlayerControl.health--;
        //if (PlayerControl.health == 0)
        //{
        //    //PlayerControl.Die();
        //    player.Die();
        //}
        Destroy(gameObject);
    }
}
