using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Shot Properties")]
    [SerializeField] private GameObject _shot;
    [SerializeField] private float doubleShotRate;
    public float shotRateTime;

    [Header("Sound")]
    [SerializeField] private AudioClip _shotSFX;
    [Range(0, 1)] [SerializeField] private float _shotVolume;

    private GameManager GM;
    private Transform _shotSpawnPoint;
    private Animator _animator;

    private bool _canShoot = true;

    public bool doubleShot = false;

    private AudioSource _audio;

    void Start()
    {
        GM = GameManager.instance;
        _animator = GetComponent<Animator>();
        _shotSpawnPoint = gameObject.transform.Find("ShotSpawnPoint");
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GM.canControlPlayer)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (_canShoot)
        {
            StartCoroutine("ShotTime");

            _animator.SetTrigger("shoot");

            Instantiate(_shot, _shotSpawnPoint.position, _shotSpawnPoint.rotation);
            _audio.PlayOneShot(_shotSFX, _shotVolume);

            if (doubleShot)
                StartCoroutine("SecondShot");
        }
    }

    IEnumerator ShotTime()
    {
        _canShoot = false;
        yield return new WaitForSeconds(shotRateTime);
        _canShoot = true;
    }

    IEnumerator SecondShot()
    {
        yield return new WaitForSeconds(doubleShotRate);
        Instantiate(_shot, _shotSpawnPoint.position, _shotSpawnPoint.rotation);
        _audio.PlayOneShot(_shotSFX, _shotVolume);
    }
}
