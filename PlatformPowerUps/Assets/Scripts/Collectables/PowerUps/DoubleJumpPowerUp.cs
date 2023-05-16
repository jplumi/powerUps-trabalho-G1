using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPowerUp : PowerUp
{
    private Collider2D playerCollision;

    public override void PowerUpAction(Collider2D playerCollision)
    {
        PlayerMovement playerMovement = playerCollision.GetComponent<PlayerMovement>();
        playerMovement.maxJumps = 2;

        this.playerCollision = playerCollision;

        Invoke("RemovePowerUp", 10f);
    }

    public override void RemovePowerUp()
    {
        PlayerMovement playerMovement = playerCollision.GetComponent<PlayerMovement>();
        playerMovement.maxJumps = 1;

        Destroy(gameObject);
    }
}
