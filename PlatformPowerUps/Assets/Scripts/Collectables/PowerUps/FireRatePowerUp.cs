using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp : PowerUp
{
    private Collider2D playerCollision;

    public override void PowerUpAction(Collider2D playerCollision)
    {
        PlayerShoot playerShoot = playerCollision.GetComponent<PlayerShoot>();
        playerShoot.shotRateTime /= 2;

        this.playerCollision = playerCollision;

        Invoke("RemovePowerUp", 10f);
    }

    public override void RemovePowerUp()
    {
        PlayerShoot playerShoot = playerCollision.GetComponent<PlayerShoot>();
        playerShoot.shotRateTime *= 2;

        Destroy(gameObject);
    }
}
