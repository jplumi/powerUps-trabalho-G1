using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPowerUp : PowerUp
{
    private Collider2D playerCollision;

    public override void AddPowerUp(Collider2D playerCollision)
    {
        PlayerShoot playerShoot = playerCollision.GetComponent<PlayerShoot>();
        playerShoot.doubleShot = true;

        this.playerCollision = playerCollision;
    }

    public override void RemovePowerUp()
    {
        PlayerShoot playerShoot = playerCollision.GetComponent<PlayerShoot>();
        playerShoot.doubleShot = false;
    }
}