using NUnit.Framework;
using UnityEngine.TestTools;
using RedBlueGames.ObjectFsm;

namespace RedBlueGames.ObjectFsm.Tests
{
    public class StateMachineTests
    {
        private class FakeState : IState
        {
            public int NumTimesEntered {get; set;}
            public int NumTimesExited {get; set;}
                
            public void Enter()
            {
                NumTimesEntered++;
            }

            public void Exit()
            {
                NumTimesExited++;
            }

            public void Update(float deltaTime)
            {
                
            }
        }

        [Test]
        public void Ctor_DoesNotEnterInitialState()
        {
            var fakeStateA = new FakeState();
            var stateMachine = new StateMachine(fakeStateA);

            Assert.That(fakeStateA.NumTimesEntered, Is.EqualTo(0));
        }

        [Test]
        public void ChangeState_ExitsCurrentThenEntersNew()
        {
            var fakeStateA = new FakeState();
            var fakeStateB = new FakeState();
            var stateMachine = new StateMachine(fakeStateA);
            stateMachine.ChangeState(fakeStateB);

            Assert.That(fakeStateA.NumTimesExited, Is.EqualTo(1));
            Assert.That(fakeStateB.NumTimesEntered, Is.EqualTo(1));
        }
    }
}