using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicBossEmerge : MonoBehaviour
{

    [SerializeField] float jumpForce;

    public void Trigger()
    {
        Rigidbody2D RB = GetComponent<Rigidbody2D>();
        RB.isKinematic = false;
        RB.velocity = Vector2.up * jumpForce;
        StartCoroutine("EnableScripts");
    }

    IEnumerator EnableScripts()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<Skeleton>().enabled = true;
        GetComponent<SkeletonDamageable>().enabled = true;
        GetComponent<AudioSource>().enabled = true;
    }
}
