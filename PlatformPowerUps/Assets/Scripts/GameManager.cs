using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public bool canControlPlayer = true;

    public bool playerIsInvincible = false;

    public float invincibilityTime;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void MakePlayerInvincible()
    {
        playerIsInvincible = true;
        StartCoroutine("MakeVincible");
    }

    IEnumerator MakeVincible()
    {
        yield return new WaitForSeconds(invincibilityTime);
        playerIsInvincible = false;
    }
}
