using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip _collectedSound;
    [Range(0, 1)] [SerializeField] private float _soundVolume;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GameManager.instance.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement playerMovement =
                collision.gameObject.GetComponent<PlayerMovement>();

            playerMovement.maxJumps = 2;

            _audioSource.PlayOneShot(_collectedSound, _soundVolume);

            Destroy(gameObject);
        }
    }
}
