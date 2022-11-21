namespace RedBlueGames.ObjectFsm
{
    public class StateMachine
    {
        private IState currentState;
        private object user;

        public StateMachine(object user, IState initialState)
        {
            this.currentState = initialState;
            this.user = user;
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