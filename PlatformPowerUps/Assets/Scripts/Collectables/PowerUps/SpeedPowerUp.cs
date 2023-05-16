using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    private Collider2D playerCollision;

    public override void AddPowerUp(Collider2D playerCollision)
    {
        PlayerMovement playerMovement = playerCollision.GetComponent<PlayerMovement>();
        playerMovement.moveSpeed *= 2;

        this.playerCollision = playerCollision;
    }

    public override void RemovePowerUp()
    {
        PlayerMovement playerMovement = playerCollision.GetComponent<PlayerMovement>();
        playerMovement.moveSpeed /= 2;
    }
}
