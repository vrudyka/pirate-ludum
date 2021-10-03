public abstract class EnemyState
{
    protected MotherAI mother;
    protected StateMashine StateMashine;

    protected EnemyState(MotherAI mother, StateMashine StateMashine)
    {
        this.mother = mother;
        this.StateMashine = StateMashine;
    }

    public virtual void Enter()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
       
    }

    public virtual void Exit()
    {

    }

}