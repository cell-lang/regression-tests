using System;
using System.IO;

using Cell.Facades;


public static class ReactAutoA_Tests {
  public static void Run() {
    ReactAutoA testAuto = new ReactAutoA();

    bool aBool = true;
    string aSymb = "my_symbol";
    long anInt = 42;
    double aFloat = 3.14159;
    string aString = "Imagine there's no heaven...";
    long aTimeSpan = 60000;
    var aRect = (color: Blue.singleton, width: 4.16, height: 0.81, bottomLeft: (x: 25, y: 9));
    // string aRect = "(color: blue, width: 4.16, height: 0.81, bottom_left: point(x: 25, y: 9))";
    var aDateRec = (day: 15, year: 2007, month: 3);
    // string aDateRec = "(day: 15, year: 2007, month: 3)";
    (int, int, int) aDate = (5, 2, 2018);

    var aPoint = (x: 12, y: 7);
    // string aPoint = "point(x: 12, y: 7)";

    Polar polar = new Polar();
    polar.ro = 6.28318;
    polar.theta = 1.73205;
    AnyPoint anAnyPoint = polar;
    // string anAnyPoint = "polar(ro: 6.28318, theta: 1.73205)";

    var aTuple = (2.71828, "It's easy if you try...", new long[] {1, 1, 2, 6, 24});
    bool[] aBoolSeq = new bool[] {true, false, false, true};
    long[] anIntSeq = new long[] {100, 101, 102, 103, 104, 105};
    double[] aFloatSeq = new double[] {-2.0, -1.0, 0.0, 1.0, 2.0, 3.0};
    string[] aPointSeq = new string[] {"point(x: 0, y: 0)", "point(x: 1, y: 1)", "point(x: 2, y: 4)"};
    string _aPointSeq = "(point(x: 0, y: 0), point(x: 1, y: 1), point(x: 2, y: 4))";
    long[] aTimeSpanSeq = new long[] {60, 3600, 86420};
    // string anIntToSymbMap = "[0 -> zero, 1 -> one, 2 -> two, 3 -> three]";
    string anIntToSymbMap = "[1 -> one, 2 -> two, 0 -> zero, 3 -> three]";

    testAuto.ABoolInput = aBool;
    testAuto.ASymbInput = aSymb;
    testAuto.AnIntInput = anInt;
    testAuto.AFloatInput = aFloat;
    testAuto.AStringInput = aString;
    testAuto.ATimeSpanInput = aTimeSpan;
    testAuto.ARectInput = aRect;
    // testAuto.SetInput(ReactAutoA.Input.A_RECT_INPUT, aRect);
    testAuto.ADateRecInput = aDateRec;
    // testAuto.SetInput(ReactAutoA.Input.A_DATE_REC_INPUT, aDateRec);
    testAuto.ADateInput = aDate;
    // testAuto.SetInput(ReactAutoA.Input.A_DATE_INPUT, _aDate);
    testAuto.APointInput = aPoint;
    // testAuto.SetInput(ReactAutoA.Input.A_POINT_INPUT, aPoint);
    testAuto.AnAnyPointInput = anAnyPoint;
    // testAuto.SetInput(ReactAutoA.Input.AN_ANY_POINT_INPUT, anAnyPoint);
    testAuto.ATupleInput = aTuple;
    // testAuto.SetInput(ReactAutoA.Input.A_TUPLE_INPUT, _aTuple);
    testAuto.ABoolSeqInput = aBoolSeq;
    testAuto.AnIntSeqInput = anIntSeq;
    testAuto.AFloatSeqInput = aFloatSeq;
    // testAuto.APointSeqInput = aPointSeq;
    testAuto.SetInput(ReactAutoA.Input.A_POINT_SEQ_INPUT, _aPointSeq);
    testAuto.ATimeSpanSeqInput = aTimeSpanSeq;
    // testAuto.AnIntToSymbMapInput = anIntToSymbMap;
    testAuto.SetInput(ReactAutoA.Input.AN_INT_TO_SYMB_MAP_INPUT, anIntToSymbMap);

    testAuto.Apply();

    if (testAuto.ABoolOutput != aBool) {
      Console.WriteLine("ERROR: ABoolOutput = {0}, ABool = {1}", testAuto.ABoolOutput, aBool);
      return;
    }

    if (testAuto.ASymbOutput != aSymb) {
      Console.WriteLine("ERROR: ASymbOutput = {0}, ASymb = {1}", testAuto.ASymbOutput, aSymb);
      return;
    }

    if (testAuto.AnIntOutput != anInt) {
      Console.WriteLine("ERROR: AnIntOutput = {0}, AnInt = {1}", testAuto.AnIntOutput, anInt);
      return;
    }

    if (testAuto.AFloatOutput != aFloat) {
      Console.WriteLine("ERROR: AFloatOutput = {0}, AFloat = {1}", testAuto.AFloatOutput, aFloat);
      return;
    }

    if (testAuto.AStringOutput != aString) {
      Console.WriteLine("ERROR: AStringOutput = {0}, AString = {1}", testAuto.AStringOutput, aString);
      return;
    }

    if (testAuto.ATimeSpanOutput != aTimeSpan) {
      Console.WriteLine("ERROR: ATimeSpanOutput = {0}, ATimeSpan = {1}", testAuto.ATimeSpanOutput, aTimeSpan);
      return;
    }

    var outRect = testAuto.ARectOutput;
    if (outRect != aRect) {
      Console.WriteLine("ERROR: ARectOutput = {0}, aRect = {1}", outRect, aRect);
      return;
    }

    var outDateRec = testAuto.ADateRecOutput;
    if (outDateRec != aDateRec) {
      Console.WriteLine("ERROR: aDateRecOutput = {0}, aDateRec = {1}", outDateRec, aDateRec);
      return;
    }

    if (testAuto.ADateOutput.Item1 != aDate.Item1) {
      Console.WriteLine("ERROR: ADateOutput.Item1 = {0}, ADate.Item1 = {1}", testAuto.ADateOutput.Item1, aDate.Item1);
      return;
    }

    if (testAuto.ADateOutput.Item2 != aDate.Item2) {
      Console.WriteLine("ERROR: ADateOutput.Item2 = {0}, ADate.Item2 = {1}", testAuto.ADateOutput.Item2, aDate.Item2);
      return;
    }

    if (testAuto.ADateOutput.Item3 != aDate.Item3) {
      Console.WriteLine("ERROR: ADateOutput.Item3 = {0}, ADate.Item3 = {1}", testAuto.ADateOutput.Item3, aDate.Item3);
      return;
    }

    var outPoint = testAuto.APointOutput;
    if (outPoint != aPoint) {
      Console.WriteLine("ERROR: APointOutput = {0}, APoint = {1}", outPoint, aPoint);
      return;
    }

    if (testAuto.AnAnyPointOutput.ToString() != anAnyPoint.ToString()) {
      Console.WriteLine("ERROR: AnAnyPointOutput = {0}, AnAnyPoint = {1}", testAuto.AnAnyPointOutput, anAnyPoint);
      return;
    }

    if (testAuto.ATupleOutput.Item1 != aTuple.Item1) {
      Console.WriteLine("ERROR: ATupleOutput.Item1 = {0}, ATuple.Item1 = {1}", testAuto.ATupleOutput.Item1, aTuple.Item1);
      return;
    }

    if (testAuto.ATupleOutput.Item2 != aTuple.Item2) {
      Console.WriteLine("ERROR: ATupleOutput.Item2 = {0}, ATuple.Item2 = {1}", testAuto.ATupleOutput.Item2, aTuple.Item2);
      return;
    }

    if (!Eq(testAuto.ATupleOutput.Item3, aTuple.Item3)) {
      Console.WriteLine("ERROR: ATupleOutput.Item3 = {0}, ATuple.Item3 = {1}", testAuto.ATupleOutput.Item3, aTuple.Item3);
      return;
    }

    if (!Eq(testAuto.ABoolSeqOutput, aBoolSeq)) {
      Console.WriteLine("ERROR: ABoolSeqOutput = {0}, ABoolSeq = {1}", testAuto.ABoolSeqOutput, aBoolSeq);
      return;
    }

    if (!Eq(testAuto.AnIntSeqOutput, anIntSeq)) {
      Console.WriteLine("ERROR: AnIntSeqOutput = {0}, AnIntSeq = {1}", testAuto.AnIntSeqOutput, anIntSeq);
      return;
    }

    if (!Eq(testAuto.AFloatSeqOutput, aFloatSeq)) {
      Console.WriteLine("ERROR: AFloatSeqOutput = {0}, AFloatSeq = {1}", testAuto.AFloatSeqOutput, aFloatSeq);
      return;
    }


    var outPointSeq = testAuto.APointSeqOutput;
    string[] strs = new string[outPointSeq.Length];
    for (int i=0 ; i < strs.Length ; i++)
      strs[i] = string.Format("point(x: {0}, y: {1})", outPointSeq[i].x, outPointSeq[i].y);
    if (!EqStrV(strs, aPointSeq)) {
      Console.WriteLine("ERROR: APointSeqOutput = {0}, APointSeq = {1}", strs, _aPointSeq);
      return;
    }

    if (!Eq(testAuto.ATimeSpanSeqOutput, aTimeSpanSeq)) {
      Console.WriteLine("ERROR: ATimeSpanSeqOutput = {0}, ATimeSpanSeq = {1}", testAuto.ATimeSpanSeqOutput, aTimeSpanSeq);
      return;
    }

    string str = "[";
    foreach (var entry in testAuto.AnIntToSymbMapOutput) {
      if (str != "[")
        str += ", ";
      str += string.Format("{0} -> {1}", entry.Key, entry.Value);
    }
    str += "]";
    if (str != anIntToSymbMap) {
      Console.WriteLine("ERROR: AnIntToSymbMapOutput = {0}, anIntToSymbMap = {1}", str, anIntToSymbMap);
      return;
    }

    Console.WriteLine("Reactive automata tests passed!");
  }

  static bool Eq<T>(T[] xs, T[] ys) where T : System.IComparable<T> {
    if (xs.Length != ys.Length)
      return false;
    for (int i=0 ; i < xs.Length ; i++)
      if (xs[i].CompareTo(ys[i]) != 0)
        return false;
    return true;
  }

  static bool EqStrV<T>(T[] xs, string[] ys) {
    if (xs.Length != ys.Length)
      return false;
    for (int i=0 ; i < xs.Length ; i++)
      if (xs[i].ToString() != ys[i])
        return false;
    return true;
  }
}
