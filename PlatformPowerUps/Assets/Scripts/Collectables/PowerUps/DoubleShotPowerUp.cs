using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPowerUp : PowerUp
{
    public override void PowerUpAction(Collider2D playerCollision)
    {
        PlayerShoot playerShoot = playerCollision.GetComponent<PlayerShoot>();
        playerShoot.doubleShot = true;
    }
}
