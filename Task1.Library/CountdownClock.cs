using System;
using System.Threading;

namespace Task1.Library
{
    public class CountdownClock
    {
        public event EventHandler<int> TimeUp = delegate { };

        public void ImitationCountdownClock(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            if (TimeUp != null) TimeUp(this, seconds);
        }
    }

    
}
