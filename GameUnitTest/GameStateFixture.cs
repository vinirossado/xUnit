using System;
using Game;

namespace GameUnitTest
{
    public class GameStateFixture : IDisposable
    {
        public GameState State { get; private set; }

        public GameStateFixture(){
            State = new GameState();
        }

        public void Dispose(){
            //Cleanup
        }
    }
}
