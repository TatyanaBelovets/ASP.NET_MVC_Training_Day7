using System;
using System.Threading;

namespace Task1.Library
{
    public class CountdownClock
    {
        public delegate void TimeUpEventHandler();

        public event TimeUpEventHandler TimeUp;

        public void ImitationCountdownClock(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            Console.WriteLine("Time is up!");
            if (TimeUp != null) TimeUp();
        }
    }

    
}
