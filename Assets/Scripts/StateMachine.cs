namespace RedBlueGames.ObjectFsm
{
    public class StateMachine
    {
        private IState currentState;

        public StateMachine(IState initialState)
        {
            currentState = initialState;
        }

        public void Update(float deltaTime)
        {
            currentState.Update(deltaTime);
        }

        public void ChangeState(IState newState)
        {
            currentState.Exit();
            currentState = newState;
            newState.Enter();
        }
    }
}