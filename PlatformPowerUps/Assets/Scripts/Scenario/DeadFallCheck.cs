using UnityEngine;

public class DeadFallCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground")) {
            Destroy(collision.gameObject);
        }
    }
}
