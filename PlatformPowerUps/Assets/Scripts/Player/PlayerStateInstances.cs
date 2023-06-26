using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInstances
{
    public PlayerIdleState Idle { get; private set; }
    public PlayerJumpingState Jumping { get; private set; }
    public PlayerFallingState Falling { get; private set; }
    public PlayerRunningState Running { get; private set; }
    public PlayerAttack1State Attack1 { get; private set; }
    public PlayerAttack2State Attack2 { get; private set; }
    public PlayerAttack3State Attack3 { get; private set; }
    public PlayerGunOutState GunOut { get; private set; }
    public PlayerShootState Shoot { get; private set; }
    public PlayerGunInState GunIn { get; private set; }
    public PlayerHitState Hit { get; private set; }
    public PlayerDeathState Death { get; private set; }

    public PlayerStateInstances(PlayerStateManager stateManager)
    {
        Idle = new PlayerIdleState(stateManager, this);
        Jumping = new PlayerJumpingState(stateManager, this);
        Falling = new PlayerFallingState(stateManager, this);
        Running = new PlayerRunningState(stateManager, this);
        Attack1 = new PlayerAttack1State(stateManager, this);
        Attack2 = new PlayerAttack2State(stateManager, this);
        Attack3 = new PlayerAttack3State(stateManager, this);
        GunOut = new PlayerGunOutState(stateManager, this);
        Shoot = new PlayerShootState(stateManager, this);
        GunIn = new PlayerGunInState(stateManager, this);
        Hit = new PlayerHitState(stateManager, this);
        Death = new PlayerDeathState(stateManager, this);
    }
}
