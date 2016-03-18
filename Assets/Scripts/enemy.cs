using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{
    public PlayerControl player;
    public int health = 1;
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
    }
        void OnTriggerEnter(Collider other)
    {
        health--;
        //if (other.gameObject.layer == 8 || other.gameObject.layer == 11)
        //    PlayerControl.health--;
        //if (PlayerControl.health == 0) {
        //    player.Die();
        //}
    }
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}