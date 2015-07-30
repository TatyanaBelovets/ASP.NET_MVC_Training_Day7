using System;
using Task1.Library;

namespace Task1.TestConsole
{
    class CountdownClockCheck
    {
        static void Main(string[] args)
        {
            var clock = new CountdownClock();
            var bath = new Bathroom();
            var microwave = new Microwave();
            bath.Register(clock);
            microwave.Register(clock);
            Console.WriteLine("The countdown has begun!");
            clock.ImitationCountdownClock(5);
            bath.Unregister(clock);
            clock.ImitationCountdownClock(2);
            Console.ReadKey();
        }
    }
}
