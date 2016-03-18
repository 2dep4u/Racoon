using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour {

    public int startingHealth;
    public int healthPerHeart;
    public GameObject Hearts;

    private int currentHealth;
    private List<Transform> heartList = new List <Transform>();

    void Start()
    {
        AddHearts(startingHealth / healthPerHeart);
        currentHealth = startingHealth;
        if(startingHealth%healthPerHeart != 0 && (healthPerHeart != 1 || healthPerHeart == 2))
        {
            Debug.Log("healthPerHeart is not 1 or 2 or startingHealth is not divisble by healthPerHeart");
        }
    }

    public void AddHearts(int n)
    {
        float x = (startingHealth/healthPerHeart - 1) * -105;
        for (int i = 0; i < n; ++i)
        {
            Transform newHeart = ((GameObject)Instantiate(Hearts.gameObject)).transform;
            newHeart.SetParent(this.transform);
          //  newHeart.parent = this.transform;
            newHeart.GetComponent<RectTransform>().anchoredPosition = new Vector3(x, 0, 0);
            newHeart.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            x += 105;
            heartList.Add(newHeart);
            
        }
    }

    public void reduceHealth()
    {   if (currentHealth > 0)
        {
            currentHealth--;
            int heartToRemove = Mathf.FloorToInt(currentHealth / healthPerHeart);
            Transform temp = heartList[heartToRemove];
            if (healthPerHeart == 2 && (currentHealth) % 2 != 0)
            {
                temp.GetChild(2).gameObject.SetActive(false);
            }
            else
            {
                temp.GetChild(2).gameObject.SetActive(false);
                temp.GetChild(1).gameObject.SetActive(false);
            }
        }

    }
   public void increaseHealth()
    {
        if (currentHealth < 6)
        {
            currentHealth++;
            int heartToRemove = Mathf.FloorToInt((currentHealth - 1) / healthPerHeart);
            Transform temp = heartList[heartToRemove];
            if (healthPerHeart == 2 && (currentHealth) % 2 == 0)
            {
                temp.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                temp.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
    public int getHealth()
    {
        return currentHealth;
    }
}
