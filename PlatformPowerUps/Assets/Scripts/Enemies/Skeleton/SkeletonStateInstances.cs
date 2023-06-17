public class SkeletonStateInstances
{
    public SkeletonIdleState Idle { get; private set; }
    public SkeletonPatrolState Patrol { get; private set; }
    public SkeletonAlertState Alert { get; private set; }
    public SkeletonDamageState Damage { get; private set; }
    public SkeletonAttackingState Attack { get; private set; }
    public SkeletonDeathState Death { get; private set; }

    public SkeletonStateInstances(Skeleton stateManager)
    {
        Idle = new SkeletonIdleState(stateManager, this);
        Patrol = new SkeletonPatrolState(stateManager, this);
        Damage = new SkeletonDamageState(stateManager, this);
        Attack = new SkeletonAttackingState(stateManager, this);
        Death = new SkeletonDeathState(stateManager, this);
        Alert = new SkeletonAlertState(stateManager, this);
    }
}
