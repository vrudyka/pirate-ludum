public abstract class State
{
    protected MotherAI mother;
    protected StateMashine StateMashine;

    protected State(MotherAI mother, StateMashine StateMashine)
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