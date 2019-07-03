package net.cell_lang;

import java.util.Arrays;


class ReactAutoA_Tests {
  public static void run() {
    ReactAutoA testAuto = new ReactAutoA();

    boolean aBool = true;
    String aSymb = "my_symbol";
    long anInt = 42;
    double aFloat = 3.14159;
    String aString = "Imagine there's no heaven...";
    long aTimeSpan = 60000;

    boolean[] aBoolSeq = new boolean[] {true, false, false, true};
    long[] anIntSeq = new long[] {100, 101, 102, 103, 104, 105};
    double[] aFloatSeq = new double[] {-2.0, -1.0, 0.0, 1.0, 2.0, 3.0};
    long[] aTimeSpanSeq = new long[] {60, 3600, 86420};
    // String anIntToSymbMap = "[0 -> zero, 1 -> one, 2 -> two, 3 -> three]";
    String anIntToSymbMap = "[1 -> one, 2 -> two, 0 -> zero, 3 -> three]";

    Rect aRect = new Rect();
    aRect.color = Blue.singleton;
    aRect.width = 4.16;
    aRect.height = 0.81;
    aRect.bottomLeft = new Point();
    aRect.bottomLeft.x = 25;
    aRect.bottomLeft.y = 9;

    DateRec aDateRec = new DateRec();
    aDateRec.day = 15;
    aDateRec.month = 3;
    aDateRec.year = 2007;

    Date aDate = new Date();
    aDate.item1 = 5;
    aDate.item2 = 2;
    aDate.item3 = 2018;

    Point aPoint = new Point();
    aPoint.x = 12;
    aPoint.y = 7;

    Polar aPolar = new Polar();
    aPolar.ro = 6.28318;
    aPolar.theta = 1.73205;
    // anAnyPoint = "polar(ro: 6.28318, theta: 1.73205)";

    Double_String_Long_Seq aTuple = new Double_String_Long_Seq();
    aTuple.item1 = 2.71828;
    aTuple.item2 = "It's easy if you try...";
    aTuple.item3 = new long[] {1, 1, 2, 6, 24};

    Point[] aPointSeq = new Point[3];
    for (int i=0 ; i < aPointSeq.length ; i++)
      aPointSeq[i] = new Point();
    aPointSeq[0].x = 0;
    aPointSeq[0].y = 0;
    aPointSeq[1].x = 1;
    aPointSeq[1].y = 1;
    aPointSeq[2].x = 2;
    aPointSeq[2].y = 4;

    // String aRect = "(color: blue, width: 4.16, height: 0.81, bottom_left: point(x: 25, y: 9))";
    // String aDateRec = "(day: 15, year: 2007, month: 3)";
    // var aDate = new Tuple<long, long, long>(5, 2, 2018);
    // String aPoint = "point(x: 12, y: 7)";
    // String anAnyPoint = "polar(ro: 6.28318, theta: 1.73205)";
    // var aTuple = new Tuple<double, String, long[]>(2.71828, "It's easy if you try...", new long[] {1, 1, 2, 6, 24});
    // String[] aPointSeq = new String[] {"point(x: 0, y: 0)", "point(x: 1, y: 1)", "point(x: 2, y: 4)"};

    testAuto.setABoolInput(aBool);
    testAuto.setASymbInput(aSymb);
    testAuto.setAnIntInput(anInt);
    testAuto.setAFloatInput(aFloat);
    testAuto.setAStringInput(aString);
    testAuto.setATimeSpanInput(aTimeSpan);
    testAuto.setARectInput(aRect);
    testAuto.setADateRecInput(aDateRec);
    testAuto.setADateInput(aDate);
    testAuto.setAPointInput(aPoint);
    testAuto.setAnAnyPointInput(aPolar);
    testAuto.setATupleInput(aTuple);
    testAuto.setABoolSeqInput(aBoolSeq);
    testAuto.setAnIntSeqInput(anIntSeq);
    testAuto.setAFloatSeqInput(aFloatSeq);
    testAuto.setAPointSeqInput(aPointSeq);
    testAuto.setATimeSpanSeqInput(aTimeSpanSeq);
    testAuto.setAnIntToSymbMapInput(anIntToSymbMap);

    testAuto.apply();


    boolean aBoolOutput = testAuto.aBoolOutput();
    if (aBoolOutput != aBool) {
      System.out.printf("ERROR: ABoolOutput = %s, ABool = %s\n", Boolean.toString(aBoolOutput), Boolean.toString(aBool));
      return;
    }

    Value aSymbOutput = testAuto.aSymbOutput();
    if (!aSymbOutput.toString().equals(aSymb)) {
      System.out.printf("ERROR: ASymbOutput = %s, ASymb = %s\n", aSymbOutput.toString(), aSymb);
      return;
    }

    long anIntOutput = testAuto.anIntOutput();
    if (anIntOutput != anInt) {
      System.out.printf("ERROR: AnIntOutput = %d, AnInt = %d\n", anIntOutput, anInt);
      return;
    }

    double aFloatOutput = testAuto.aFloatOutput();
    if (aFloatOutput != aFloat) {
      System.out.printf("ERROR: AFloatOutput = %f, AFloat = %f\n", aFloatOutput, aFloat);
      return;
    }

    String aStringOutput = testAuto.aStringOutput();
    if (!aStringOutput.equals(aString)) {
      System.out.printf("ERROR: AStringOutput = %s, AString = %s\n", aStringOutput, aString);
      return;
    }

    long aTimeSpanOutput = testAuto.aTimeSpanOutput();
    if (aTimeSpanOutput != aTimeSpan) {
      System.out.printf("ERROR: ATimeSpanOutput = %d, ATimeSpan = %d\n", aTimeSpanOutput, aTimeSpan);
      return;
    }

    Rect aRectOutput = testAuto.aRectOutput();
    if (!aRectOutput.toString().equals(aRect.toString())) {
      System.out.printf("ERROR: ARectOutput = %s, aRect = %s\n", aRectOutput.toString(), aRect.toString());
      return;
    }

    DateRec aDateRecOutput = testAuto.aDateRecOutput();
    if (!aDateRecOutput.toString().equals(aDateRec.toString())) {
      System.out.printf("ERROR: aDateRecOutput = %s, aDateRec = %s\n", aDateRecOutput.toString(), aDateRec.toString());
      return;
    }

    Date aDateOutput = testAuto.aDateOutput();
    if (aDateOutput.item1 != aDate.item1 || aDateOutput.item2 != aDate.item2 || aDateOutput.item3 != aDate.item3) {
      System.out.printf("ERROR: aDateOutput = %s, aDate = %s\n", aDateOutput.toString(), aDate.toString());
      return;
    }

    Point aPointOutput = testAuto.aPointOutput();
    if (!aPointOutput.toString().equals(aPoint.toString())) {
      System.out.printf("ERROR: aPointOutput = %s, aPoint = %s\n", aPointOutput.toString(), aPoint.toString());
      return;
    }

    AnyPoint anAnyPointOutput = testAuto.anAnyPointOutput();
    if (!anAnyPointOutput.toString().equals(aPolar.toString())) {
      System.out.printf("ERROR: anAnyPointOutput = %s, anAnyPoint = %s\n", anAnyPointOutput.toString(), aPolar.toString());
      return;
    }

    Double_String_Long_Seq aTupleOutput = testAuto.aTupleOutput();
    if (!aTupleOutput.toString().equals(aTuple.toString())) {
      System.out.printf("ERROR: aTupleOutput = %s, aTuple = %s\n", aTupleOutput.toString(), aTuple.toString());
      return;
    }

    boolean[] aBoolSeqOutput = testAuto.aBoolSeqOutput();
    if (!Arrays.equals(aBoolSeqOutput, aBoolSeq)) {
      System.out.printf("ERROR: aBoolSeqOutput = %s, aBoolSeq = %s\n", aBoolSeqOutput.toString(), aBoolSeq.toString());
      return;
    }

    long[] anIntSeqOutput = testAuto.anIntSeqOutput();
    if (!Arrays.equals(anIntSeqOutput, anIntSeq)) {
      System.out.printf("ERROR: anIntSeqOutput = %s, anIntSeq = %s\n", anIntSeqOutput.toString(), anIntSeq.toString());
      return;
    }

    double[] aFloatSeqOutput = testAuto.aFloatSeqOutput();
    if (!Arrays.equals(aFloatSeqOutput, aFloatSeq)) {
      System.out.printf("ERROR: aFloatSeqOutput = %s, aFloatSeq = %s\n", aFloatSeqOutput.toString(), aFloatSeq.toString());
      return;
    }

    Point[] aPointSeqOutput = testAuto.aPointSeqOutput();
    if (!cellEquals(aPointSeqOutput, aPointSeq)) {
      // System.out.printf("ERROR: aPointSeqOutput = %s, aPointSeq = %s\n", aPointSeqOutput.toString(), aPointSeq.toString());
      System.out.println("ERROR: aPointSeqOutput != aPointSeq");

      System.out.println("aPointSeqOutput = [");
      for (int i=0 ; i < aPointSeqOutput.length ; i++)
        System.out.printf("  %s\n", aPointSeqOutput[i].toString());
      System.out.println("]");

      System.out.println("aPointSeq = [");
      for (int i=0 ; i < aPointSeq.length ; i++)
        System.out.printf("  %s\n", aPointSeq[i].toString());
      System.out.println("]");
      return;
    }

    long[] aTimeSpanSeqOutput = testAuto.aTimeSpanSeqOutput();
    if (!Arrays.equals(aTimeSpanSeqOutput, aTimeSpanSeq)) {
      System.out.printf("ERROR: aTimeSpanSeqOutput = %s, aTimeSpanSeq = %s\n", aTimeSpanSeqOutput.toString(), aTimeSpanSeq.toString());
      return;
    }

    Value anIntToSymbMapOutput = testAuto.anIntToSymbMapOutput();
    if (!anIntToSymbMapOutput.toString().equals(anIntToSymbMap)) {
      System.out.printf("ERROR: anIntToSymbMapOutput = %s, anIntToSymbMap = %s\n", anIntToSymbMapOutput.toString(), anIntToSymbMap);
      return;
    }

    System.out.println("Reactive automata tests passed!");
  }

  static boolean cellEquals(Object[] xs, Object[] ys) {
    if (xs.length != ys.length)
      return false;
    for (int i=0 ; i < xs.length ; i++)
      if (!xs[i].toString().equals(ys[i].toString()))
        return false;
    return true;
  }
}
