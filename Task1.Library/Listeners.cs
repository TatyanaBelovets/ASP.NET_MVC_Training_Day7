using System;

namespace Task1.Library
{
    public class Microwave
    {
        private static void MicrowaveMsg(object sender, int seconds)
        {
            Console.WriteLine("Your breakfast was warmed in {0} seconds!", seconds);
        }

        public void Unregister(CountdownClock clock)
        {
            clock.TimeUp -= MicrowaveMsg;
        }

        public void Register(CountdownClock clock)
        {
            clock.TimeUp += MicrowaveMsg;
        }
    }

    public class Bathroom
    {
        private static void BathroomMsg(object sender, int seconds)
        {
            Console.WriteLine("Bathroom was prepared for using in {0} seconds!", seconds);
        }

        public void Unregister(CountdownClock clock)
        {
            clock.TimeUp -= BathroomMsg;
        }

        public void Register(CountdownClock clock)
        {
            clock.TimeUp += BathroomMsg;
        }
    }
}
