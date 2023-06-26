using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***
public class Parallax : MonoBehaviour
{
    [SerializeField] public Camera cam;

    [SerializeField] public Transform subject;

    Vector2 startPosition;

    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;

    float distanceFromSubject => transform.position.z - subject.position.z;

    float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    public void Update()
    {
        Vector2 newPos = startPosition + travel;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }

}
***/

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxFactor;
    [SerializeField] private bool infinieVertical;
    [SerializeField] private bool infiniteHorizontal;

    private float textureUnitSizeX;
    private float textureUnitSizeY;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector2 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(parallaxFactor.x * deltaMovement.x, parallaxFactor.y * deltaMovement.y, 0);
        lastCameraPosition = cameraTransform.position;

        if (infiniteHorizontal)
        { 
            if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offsetX = (cameraTransform.transform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(cameraTransform.position.x + offsetX, transform.position.x);
            }
        }
    }

}