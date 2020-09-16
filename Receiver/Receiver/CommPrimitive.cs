using System;
//public enum RegionInHosp
//{
//    Entrance1, Entrance2, Entrance3,Entrance4
//};
namespace Receiver
{
    internal class CommPrimitive
    {
        public DateTime Date { get; set; }
        public TimeSpan time { get; set; }

        public const int Counter = 1;
        public CommPrimitive(int year, int month, int day, int hour, int min, int sec)
        {
            Date = new DateTime(year, month, day);
            time = new TimeSpan(hour, min, sec);
        }
    }
}


