import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.Random;

import net.cell_lang.RelAuto;


public class MixedDateTimeTests {
  static LocalDate epochDate = LocalDate.of(1970, 1, 1);
  static LocalDateTime epochTime = LocalDateTime.of(1970, 1, 1, 0, 0, 0);

  static Random random = new Random(0);
  static RelAuto relAuto = new RelAuto();


  public static void main(String[] args) {

    for (int i=0 ; i <= 100000 ; i++) {
      TestDate(i);
      TestDate(-i);

      int j = 0;
      while (j < 86400000) {
        TestTime(i, j);
        j += random.nextInt(3600000);
      }

      if (i > 0 & i % 1000 == 0)
        System.out.print('.');
    }

    System.out.printf("\nEverything seems OK\n");
  }


  static void TestDate(int epochDelta) {
    LocalDate date = epochDate.plusDays(epochDelta);
    relAuto.setDate(date);
    LocalDate dateCopy = relAuto.date();
    long epochDeltaCopy = relAuto.dateEpochDelta();
    if (!dateCopy.equals(date) | epochDeltaCopy != epochDelta) {
      System.out.printf("%s != %s | %s != %s\n", date, dateCopy, epochDelta, epochDeltaCopy);
      System.exit(1);
    }    
  }

  static void TestTime(long epochDelta, long timeOfDayMs) {
    LocalDateTime time = epochTime.plusDays(epochDelta).plusNanos(1000000 * timeOfDayMs);
    relAuto.setTime(time);
    LocalDateTime timeCopy = relAuto.time();
    long epochDeltaNs =  1000000 * (86400000 * epochDelta + timeOfDayMs);
    long epochDeltaNsCopy = relAuto.timeEpochDelta();
    if (!timeCopy.equals(time) | epochDeltaNsCopy != epochDeltaNs) {
      if (!timeCopy.equals(time))
        System.out.printf("%s != %s\n", time, timeCopy);
      if (epochDeltaNsCopy != epochDeltaNs)
        System.out.printf("%s != %s", epochDeltaNs, epochDeltaNsCopy);
      System.out.printf("  year:          %s - %s\n", time.getYear(), timeCopy.getYear());
      System.out.printf("  month:         %s - %s\n", time.getMonth(), timeCopy.getMonth());
      System.out.printf("  day:           %s - %s\n", time.getDayOfMonth(), timeCopy.getDayOfMonth());
      System.out.printf("  hours:         %s - %s\n", time.getHour(), timeCopy.getHour());
      System.out.printf("  minutes:       %s - %s\n", time.getMinute(), timeCopy.getMinute());
      System.out.printf("  seconds:       %s - %s\n", time.getSecond(), timeCopy.getSecond());
      System.out.printf("  nanoseconds:   %s - %s\n", time.getNano(), timeCopy.getNano());
      System.exit(1);
    }
  }
}
