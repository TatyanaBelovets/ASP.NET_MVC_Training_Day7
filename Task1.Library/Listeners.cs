using System;

namespace Task1.Library
{
    public class Microwave
    {
        private static void MicrowaveMsg()
        {
            Console.WriteLine("Your breakfast is ready!");
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
        private static void BathroomMsg()
        {
            Console.WriteLine("Bathroom is ready for using!");
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
