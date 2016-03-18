using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnLevelController : MonoBehaviour {
    public float spawnPosX;
    public float spawnPosY;
    public float spawnPosZ;
    public int numberOfSpawns;
    public GameObject spawnParent;
    private Vector3 spawnPos;
    private Quaternion fixedRot;
    private int levelCount;
    private int spawnCount;
    private List<Transform> levelPrefabChildren  = new List<Transform>();
    private Transform spawnParentTransform;

    void Start()
    {
        spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        fixedRot = Quaternion.identity;
        spawnParentTransform = spawnParent.transform;
        foreach (Transform child in spawnParentTransform)
        {
            levelPrefabChildren.Add(child);
        }
        levelCount = levelPrefabChildren.Count;
        spawnCount = 0;
    }
    public void spawnRandomLevel()
    {
        int randomIndex = Random.Range(0, levelCount);
        Debug.Log(randomIndex);
        GameObject tempObj = levelPrefabChildren[randomIndex].gameObject;
        if (spawnCount < numberOfSpawns)
        {
            Instantiate(tempObj, spawnPos, fixedRot);
            spawnCount++;
        }
        else
        {
            Debug.Log("FiNISHED LEVEL!");
        }
    }
}
