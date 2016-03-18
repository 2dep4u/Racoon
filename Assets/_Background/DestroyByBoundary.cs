using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
    private DisplayController displayController;
    private SpawnLevelController spawnLevelController;

    void Start()
    {
        GameObject displayControllerObject = GameObject.FindWithTag("DisplayController");
        if (displayControllerObject != null)
        {
            displayController = displayControllerObject.GetComponent<DisplayController>();
        }
        GameObject spawnLevelControllerObject = GameObject.FindWithTag("SpawnLevelController");
        if (spawnLevelControllerObject != null)
        {
            spawnLevelController = spawnLevelControllerObject.GetComponent<SpawnLevelController>();
        }

        if (displayController == null || spawnLevelController == null)
        {
            Debug.Log("Cannot find 'DisplayController' or 'SpawnLevelController' script");
        }
    }



void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            displayController.gameOverDisplay();
        if (other.tag == "LevelSpawn")
            spawnLevelController.spawnRandomLevel();
            
        Destroy(other.gameObject);
    }
}
