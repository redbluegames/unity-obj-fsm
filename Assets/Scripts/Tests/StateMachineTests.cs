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
            public int NumTimesUpdated {get; set;}
                
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
                NumTimesUpdated++;
            }
        }

        [Test]
        public void Ctor_StartsInInitialStateWithoutEnter()
        {
            var fakeStateA = new FakeState();
            var stateMachine = new StateMachine(this, fakeStateA);
            stateMachine.Update(0.0f);

            Assert.That(fakeStateA.NumTimesEntered, Is.EqualTo(0));
            Assert.That(fakeStateA.NumTimesUpdated, Is.EqualTo(1));
        }

        [Test]
        public void ChangeState_ExitsCurrentThenEntersNew()
        {
            var fakeStateA = new FakeState();
            var fakeStateB = new FakeState();
            var stateMachine = new StateMachine(this, fakeStateA);
            stateMachine.ChangeState(fakeStateB);

            Assert.That(fakeStateA.NumTimesExited, Is.EqualTo(1));
            Assert.That(fakeStateB.NumTimesEntered, Is.EqualTo(1));
        }
    }
}