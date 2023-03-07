using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{


    public Sprite emptyHeart;
    public Sprite fullHeart;
    public List<Image> hearts;

    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if(i < PlayerHealth.currHp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < PlayerHealth.maxHp)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
