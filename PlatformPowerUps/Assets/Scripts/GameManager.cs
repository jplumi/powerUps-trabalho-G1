using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public bool canControlPlayer = true;

    public bool playerIsInvincible = false;

    public Health playerHealth = new Health(100, 100);

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
