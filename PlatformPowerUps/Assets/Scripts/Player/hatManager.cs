using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hatManager : MonoBehaviour
{
    public static int hat = 5;

    public Image[] hats;
    public Sprite fullHat;
    public Sprite emptyHat;

    // Update is called once per frame
    void Update()
    {
        foreach(Image img in hats)
        {
            img.sprite = emptyHat;
        }
        for(int i = 0; i < hat; i++)
        {
            hats[i].sprite = fullHat;
        }
    }
}
