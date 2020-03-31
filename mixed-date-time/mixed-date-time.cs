using System;
using Cell.Facades;


class App {
  static DateTime epochDate = new DateTime(1970, 1, 1);
  static DateTime epochTime = new DateTime(1970, 1, 1, 0, 0, 0);

  static Random random = new Random(0);
  static RelAuto relAuto = new RelAuto();


  static void Main(string[] args) {

    for (int i=0 ; i <= 100000 ; i++) {
      TestDate(i);
      TestDate(-i);

      int j = 0;
      while (j < 86400000) {
        TestTime(i, j);
        j += random.Next(3600000);
      }

      if (i > 0 & i % 1000 == 0)
        Console.Write('.');
    }

    Console.WriteLine("\nEverything seems OK");
  }


  static void TestDate(int epochDelta) {
    DateTime date = epochDate.AddDays(epochDelta);
    relAuto.SetDate(date);
    DateTime dateCopy = relAuto.Date;
    long epochDeltaCopy = relAuto.DateEpochDelta;
    if (dateCopy != date | epochDeltaCopy != epochDelta) {
      Console.WriteLine("{0} != {1} | {2} != {3}", date, dateCopy, epochDelta, epochDeltaCopy);
      Environment.Exit(1);
    }    
  }

  static void TestTime(long epochDelta, long timeOfDayMs) {
    DateTime time = epochTime.AddDays(epochDelta).AddMilliseconds(timeOfDayMs);
    relAuto.SetTime(time);
    DateTime timeCopy = relAuto.Time;
    long epochDeltaNs =  1000000 * (86400000 * epochDelta + timeOfDayMs);
    long epochDeltaNsCopy = relAuto.TimeEpochDelta;
    if (timeCopy != time | epochDeltaNsCopy != epochDeltaNs) {
      if (timeCopy != time)
        Console.WriteLine("{0} != {1}", time, timeCopy);
      if (epochDeltaNsCopy != epochDeltaNs)
        Console.WriteLine("{0} != {1}", epochDeltaNs, epochDeltaNsCopy);
      Console.WriteLine("  year:          {0} - {1}", time.Year, timeCopy.Year);
      Console.WriteLine("  month:         {0} - {1}", time.Month, timeCopy.Month);
      Console.WriteLine("  day:           {0} - {1}", time.Day, timeCopy.Day);
      Console.WriteLine("  hours:         {0} - {1}", time.Hour, timeCopy.Hour);
      Console.WriteLine("  minutes:       {0} - {1}", time.Minute, timeCopy.Minute);
      Console.WriteLine("  seconds:       {0} - {1}", time.Second, timeCopy.Second);
      Console.WriteLine("  milliseconds:  {0} - {1}", time.Millisecond, timeCopy.Millisecond);
      Console.WriteLine("  ticks:         {0} - {1}", time.Ticks, timeCopy.Ticks);
      Environment.Exit(1);
    }
  }
}
