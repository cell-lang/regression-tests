using System;
using System.IO;

using Cell.Automata;
using Cell.Typedefs;


namespace Cell.Typedefs {
  public partial class Polar : AnyPoint {
    public override string ToString() {
      return string.Format("polar(ro: {0}, theta: {1})", ro, theta);
    }
  }

  public partial class Point : AnyPoint {
    public override string ToString() {
      return string.Format("point(x: {0}, y: {1})", x, y);
    }
  }
}


public static class RelAutoA_Tests {
  public static void Run(string file, bool setState) {
    RelAutoA testDb = new RelAutoA();

    if (file != null) {
      if (setState) {
        Stream stream = new FileStream(file, FileMode.Open);
        try {
          testDb.Load(stream);
        }
        catch (Exception e) {
          Console.WriteLine("{0}", e);
        }
      }
      else {
        string content = File.ReadAllText(file);
        testDb.Execute(content);
      }
    }
    else
      testDb.Execute("my_msg");

    bool boolOutput = testDb.ABoolVar();
    long longOutput = testDb.AnIntVar();
    double doubleOutput = testDb.AFloatVar();
    string symbOutput = testDb.ASymbVar();

    string str = testDb.AStringVar();
    bool[] bools = testDb.ABoolSeqVar();
    long[] longs = testDb.AnIntSeqVar();
    double[] doubles = testDb.AFloatSeqVar();

    Console.WriteLine("{0} - {1} - {2} - {3} - {4}", boolOutput ? "true" : "false", longOutput, doubleOutput, symbOutput, str);
    for (int i=0 ; i < bools.Length ; i++)
      Console.Write("{0} ", bools[i] ? 1 : 0);
    Console.WriteLine("");
    for (int i=0 ; i < longs.Length ; i++)
      Console.Write("{0} ", longs[i]);
    Console.WriteLine("");
    for (int i=0 ; i < doubles.Length ; i++)
      Console.Write("{0:0.000000} ", doubles[i]);
    Console.WriteLine("\n");

    var tuple_3A = testDb.ATupleVar();
    double f0 = tuple_3A.Item1;
    str = tuple_3A.Item2;
    longs = tuple_3A.Item3;

    Console.Write("{0:0.000000} - {1} -", f0, str);
    for (int i=0 ; i < longs.Length ; i++)
      Console.Write(" {0}", longs[i]);
    Console.WriteLine("");

    (long day, long year, long month) dateRec = testDb.ADateRecVar();
    long day = dateRec.day;
    long month = dateRec.month;
    long year = dateRec.year;
    Console.WriteLine("{0}/{1:00}/{2}\n", day, month, year);

    Point[] points = testDb.APointSeqVar();
    for (int i=0 ; i < points.Length ; i++)
      Console.Write("point(x: {0}, y: {1}) ", points[i].x, points[i].y);
    Console.WriteLine("");

    Point point = testDb.APointVar();
    Console.WriteLine("point(x: {0}, y: {1})", point.x, point.y);

    var date = testDb.ADateVar();
    day = date.Item1;
    month = date.Item2;
    year = date.Item3;
    Console.WriteLine("date({0}, {1}, {2})", day, month, year);

    long time_span = testDb.ATimeSpanVar();
    Console.WriteLine("msecs({0})", time_span);

    longs = testDb.ATimeSpanSeqVar();
    for (int i=0 ; i < longs.Length ; i++)
      Console.Write("msecs({0}) ", longs[i]);
    Console.WriteLine("");

    AnyPoint anyPoint = testDb.AnAnyPointVar();
    Console.WriteLine(anyPoint.ToString());

    var rect = testDb.ARectVar();
    double width = rect.width;
    double height = rect.height;
    string color = rect.color;
    long x = rect.bottomLeft.x;
    long y = rect.bottomLeft.y;
    Console.WriteLine(
      "(bottom_left: point(x: {0}, y: {1}), x: {0}, y: {1}, width: {2:0.000000}, height: {3:0.000000}, color: {4})\n",
      x, y, width, height, color
    );

    int[] elems = new int[] {0, 1, -1, 100, -1000, 2, -2, 10, -100, 1000};
    for (int i=0 ; i < 10 ; i++)
      Console.Write("{0} ", testDb.AnIntUnaryRel(elems[i]) ? 1 : 0);
    Console.WriteLine("");

    Console.Write("[");
    bool[] boolv = testDb.ABoolUnaryRel();
    for (int i=0 ; i < boolv.Length ; i++)
      Console.Write("{0}{1}", i == 0 ? "" : ", ", boolv[i] ? "true" : "false");
    Console.WriteLine("]\n");

    Console.Write("[");
    long[] intv = testDb.AnIntUnaryRel();
    for (int i=0 ; i < intv.Length ; i++)
      Console.Write("{0}{1}", i == 0 ? "" : ", ", intv[i]);
    Console.WriteLine("]\n");

    Console.Write("[");
    double[] floatv = testDb.AFloatUnaryRel();
    for (int i=0 ; i < floatv.Length ; i++)
      Console.Write("{0}{1:0.000000}", i == 0 ? "" : ", ", floatv[i]);
    Console.WriteLine("]\n");

    Console.Write("[");
    string[] symbv = testDb.ASymbUnaryRel();
    for (int i=0 ; i < symbv.Length ; i++)
      Console.Write("{0}{1:0.000000}", i == 0 ? "" : ", ", symbv[i]);
    Console.WriteLine("]\n");

    Console.Write("[");
    string[] strv = testDb.AStringUnaryRel();
    for (int i=0 ; i < strv.Length ; i++)
      Console.Write("{0}\"{1}\"", i == 0 ? "" : ", ", strv[i]);
    Console.WriteLine("]\n");

    Console.Write("[");
    AnyPoint[] anyPoints = testDb.AnAnyPointUnaryRel();
    for (int i=0 ; i < anyPoints.Length ; i++)
      Console.Write("{0}{1}", i == 0 ? "" : ", ", anyPoints[i].ToString());
    Console.WriteLine("]\n");

    //////////////////////////////////////////////////////////////////////////////

    bool[][] boolvv = testDb.ABoolSeqUnaryRel();
    for (int i=0 ; i < boolvv.Length ; i++) {
      boolv = boolvv[i];
      for (int j=0 ; j < boolv.Length ; j++)
        Console.Write("{0}{1}", j == 0 ? "" : " ", boolv[j] ? "true" : "false");
      Console.WriteLine("");
    }
    Console.WriteLine("");

    long[][] intvv = testDb.AnIntSeqUnaryRel();
    for (int i=0 ; i < intvv.Length ; i++) {
      intv = intvv[i];
      for (int j=0 ; j < intv.Length ; j++)
        Console.Write("{0}{1}", j == 0 ? "" : " ", (int) intv[j]);
      Console.WriteLine("");
    }
    Console.WriteLine("");

    double[][] floatvv = testDb.AFloatSeqUnaryRel();
    for (int i=0 ; i < floatvv.Length ; i++) {
      floatv = floatvv[i];
      for (int j=0 ; j < floatv.Length ; j++)
        Console.Write("{0}{1:0.000000}", j == 0 ? "" : " ", floatv[j]);
      Console.WriteLine("");
    }
    Console.WriteLine("");

    Console.Write("[");
    string[][] symbvv = testDb.ASymbSeqUnaryRel();
    for (int i=0 ; i < symbvv.Length ; i++) {
      symbv = symbvv[i];
      for (int j=0 ; j < symbv.Length ; j++)
        Console.Write("{0}{1}", j == 0 ? "" : ", ", symbv[j]);
      Console.Write("; ");
    }
    Console.WriteLine("]\n");

    Console.Write("[");
    string[][] strvv = testDb.AStringSeqUnaryRel();
    for (int i=0 ; i < strvv.Length ; i++) {
      strv = strvv[i];
      for (int j=0 ; j < strv.Length ; j++) {
        Console.Write("{0}{1}", j == 0 ? "" : ", ", strv[j]);
      }
      Console.Write("; ");
    }
    Console.WriteLine("]\n");

    bool[] memb_tests = new bool[8];

    memb_tests[0] = testDb.ASymbFloatBinaryRel("pi", 314159e-5);
    memb_tests[1] = testDb.ASymbFloatBinaryRel("e", 271828e-5);
    memb_tests[2] = testDb.ASymbFloatBinaryRel("sqrt2", 141421e-5);
    memb_tests[3] = testDb.ASymbFloatBinaryRel("sqrt3", 173205e-5);

    memb_tests[4] = testDb.ASymbFloatBinaryRel("pi", 271828e-5);
    memb_tests[5] = testDb.ASymbFloatBinaryRel("e", 314159e-5);
    memb_tests[6] = testDb.ASymbFloatBinaryRel("sqrt2", 173205e-5);
    memb_tests[7] = testDb.ASymbFloatBinaryRel("sqrt3", 141421e-5);

    for (int i=0 ; i < 8 ; i++)
      Console.Write("{0} ", memb_tests[i] ? 1 : 0);
    Console.WriteLine("");


    Console.Write("[");
    var pairs_SF = testDb.ASymbFloatBinaryRel();
    for (int i=0 ; i < pairs_SF.Length ; i++)
      Console.Write("{0}({1}, {2:0.000000})", i == 0 ? "" : ", ", pairs_SF[i].Item1, pairs_SF[i].Item2);
    Console.WriteLine("]\n\n");

    string[] symbs_A = new string[] {"pi", "e", "sqrt2", "sqrt3", "sqrt5", "non-key"};
    double[] doubles_A = new double[] {271828e-5, 314159e-5, 173205e-5, 141421e-5, 223607e-5};
    for (int i=0 ; i < 6 ; i++) {
      string symb = symbs_A[i];
      Console.Write("{0}: ", symb);
      double d = 0;
      try {
        d = testDb.ASymbFloatBinaryRel(symb);
        Console.WriteLine("{0:0.000000}", d);
      }
      catch {
        Console.WriteLine("--");
      }
    }
    Console.WriteLine("");
    // for (int i=0 ; i < 5 ; i++) {
    //   Console.Write("{0}: ", doubles_A[i]);
    //   string[] results = testDb.bycol1_A_symb_float_binary_rel(doubles_A[i]);
    //   for (int j=0 ; j < results.Length ; j++)
    //     Console.Write(" {1}", results[j]);
    //   Console.WriteLine("");
    // }
    // puts("\n");

    var pairs_BI = testDb.ABoolIntBinaryRel();
    for (int i=0 ; i < pairs_BI.Length ; i++)
      Console.Write("({0}, {1}) ", pairs_BI[i].Item1 ? 1 : 0, pairs_BI[i].Item2);
    Console.WriteLine("");

    var pairs_SBS = testDb.AStringBoolSeqBinaryRel();
    for (int i=0 ; i < pairs_SBS.Length ; i++) {
      Console.Write("(\"{0}\", (", pairs_SBS[i].Item1);
      boolv = pairs_SBS[i].Item2;
      for (int j=0 ; j < boolv.Length ; j++)
        Console.Write("{0}{1}", j > 0 ? ", " : "", boolv[j] ? 1 : 0);
      Console.Write(")) ");
    }
    Console.WriteLine("");

    var pairs_ISTS = testDb.AnIntSeqTimeSpanBinaryRel();
    for (int i=0 ; i < pairs_ISTS.Length ; i++) {
      Console.Write("((");
      long[] llongv = pairs_ISTS[i].Item1;
      for (int j=0 ; j < llongv.Length ; j++)
        Console.Write("{0}{1}", j > 0 ? ", " : "", llongv[j]);
      Console.Write("), {0}) ", pairs_ISTS[i].Item2);
    }
    Console.WriteLine("\n\n");

    Console.WriteLine("pi      = {0,8} {1:0.000000}", testDb.LookupByFloat(314159e-5), testDb.LookupBySymb("pi"));
    Console.WriteLine("e       = {0,8} {1:0.000000}", testDb.LookupByFloat(271828e-5), testDb.LookupBySymb("e"));
    Console.WriteLine("sqrt(2) = {0,8} {1:0.000000}", testDb.LookupByFloat(141421e-5), testDb.LookupBySymb("sqrt2"));
    Console.WriteLine("sqrt(3) = {0,8} {1:0.000000}", testDb.LookupByFloat(173205e-5), testDb.LookupBySymb("sqrt3"));

    // Console.WriteLine("pi      = %8s %s", testDb.Lookup("314159e-5"), testDb.Lookup("pi"));
    // Console.WriteLine("e       = %8s %s", testDb.Lookup("271828e-5"), testDb.Lookup("e"));
    // Console.WriteLine("sqrt(2) = %8s %s", testDb.Lookup("141421e-5"), testDb.Lookup("sqrt2"));
    // Console.WriteLine("sqrt(3) = %8s %s", testDb.Lookup("173205e-5"), testDb.Lookup("sqrt3"));

    Console.WriteLine("pi      = {0,8} {1:0.00000}", testDb.Lookup("3.14159").ToString(), testDb.Lookup("pi").ToString());
    Console.WriteLine("e       = {0,8} {1:0.00000}", testDb.Lookup("2.71828").ToString(), testDb.Lookup("e").ToString());
    Console.WriteLine("sqrt(2) = {0,8} {1:0.00000}", testDb.Lookup("1.41421").ToString(), testDb.Lookup("sqrt2").ToString());
    Console.WriteLine("sqrt(3) = {0,8} {1:0.00000}", testDb.Lookup("1.73205").ToString(), testDb.Lookup("sqrt3").ToString());

    // testDb.Lookup("314159e-5");

    // std::string call_Lookup(string);
    // std::string call_Alt_lookup(string);

    // double call_Lookup_by_symb(string);
    // stringcall_Lookup_by_float(double );

    // for b, i <- ((true, 0), (true, 1), (false, _neg_(1)), (false, 2), (true, _neg_(72305))):
    //   insert a_bool_int_binary_rel(b, i);
    // ;

    Console.WriteLine("");

    Console.WriteLine("{0} -> {1}",      0, testDb.LookupByInt(0) ? "true" : "false");
    Console.WriteLine("{0} -> {1}",      1, testDb.LookupByInt(1) ? "true" : "false");
    Console.WriteLine("{0} -> {1}",     -1, testDb.LookupByInt(-1) ? "true" : "false");
    Console.WriteLine("{0} -> {1}",      2, testDb.LookupByInt(2) ? "true" : "false");
    Console.WriteLine("{0} -> {1}", -72305, testDb.LookupByInt(-72305) ? "true" : "false");

    Console.WriteLine("{0} -> {1}",      0, testDb.Lookup("0").ToString());
    Console.WriteLine("{0} -> {1}",      1, testDb.Lookup("1").ToString());
    Console.WriteLine("{0} -> {1}",     -1, testDb.Lookup("-1").ToString());
    Console.WriteLine("{0} -> {1}",      2, testDb.Lookup("2").ToString());
    Console.WriteLine("{0} -> {1}", -72305, testDb.Lookup("-72305").ToString());

    Console.WriteLine("");

    Console.Write("\"010\"    -> (");
    bool[] bools2 = testDb.LookupByString("010");
    for (int i=0 ; i < bools2.Length ; i++)
      Console.Write("{0}{1}", i > 0 ? ", " : "", bools2[i] ? 1 : 0);
    Console.WriteLine(")");

    Console.Write("\"100110\" -> (");
    bools2 = testDb.LookupByString("100110");
    for (int i=0 ; i < bools2.Length ; i++)
      Console.Write("{0}{1}", i > 0 ? ", " : "", bools2[i] ? 1 : 0);
    Console.WriteLine(")");

    Console.Write("\"\"       -> (");
    bools2 = testDb.LookupByString("");
    for (int i=0 ; i < bools2.Length ; i++)
      Console.Write("{0}{1}", i > 0 ? ", " : "", bools2[i] ? 1 : 0);
    Console.WriteLine(")");

    // Console.WriteLine('"' << testDb.AltLookup("(false, true, false)") << '"' << endl;
    // Console.WriteLine('"' << testDb.AltLookup("(true, false, false, true, true, false)") << '"' << endl;
    // Console.WriteLine('"' << testDb.AltLookup("()") << '"' << endl << endl;

    Console.Write(testDb.AltLookup("msecs(123)").ToString() + " : ");
    Console.WriteLine(testDb.AltLookup("(0, 1, 2, 3)").ToString());
    Console.Write(testDb.AltLookup("msecs(98765)").ToString() + " : ");
    Console.WriteLine(testDb.AltLookup("(9, 8, 7, 6, 5)").ToString());

    Console.WriteLine("");

    var symb_float_pairs = testDb.SymbsAndFloats();
    for (int i=0 ; i < symb_float_pairs.Length ; i++)
      Console.Write("({0}, {1:0.00000}) ", symb_float_pairs[i].Item1, symb_float_pairs[i].Item2);
    Console.WriteLine("\n");

    Console.WriteLine(testDb.HasStringBoolSeqPair("010", new bool[] {false, true, false}) ? 1 : 0);
    Console.WriteLine(testDb.HasStringBoolSeqPair("100110", new bool[] {true, false, false, true, true, false}) ? 1 : 0);
    Console.WriteLine(testDb.HasStringBoolSeqPair("", new bool[0]) ? 1 : 0);
    Console.WriteLine(testDb.HasStringBoolSeqPair("010", new bool[] {false, true}) ? 1 : 0);
    Console.WriteLine(testDb.HasStringBoolSeqPair("100110", new bool[] {true, false, false}) ? 1 : 0);
    Console.WriteLine(testDb.HasStringBoolSeqPair("010", new bool[] {true, false, false, true, true, false}) ? 1 : 0);
    Console.WriteLine(testDb.HasStringBoolSeqPair("100110", new bool[] {false, true, false}) ? 1 : 0);

    var intToSymbMap = testDb.AnIntToSymbMapVar();
    Console.WriteLine();
    Console.Write("[");
    bool first = true;
    foreach (var entry in intToSymbMap) {
      if (!first)
        Console.Write(", ");
      first = false;
      Console.Write("{0} -> {1}", entry.Item1, entry.Item2);
    }
    Console.WriteLine("]");

    // Console.Write("msecs(123) -> ");
    // try {
    //   longs = testDb.AnIntSeqTimeSpanBinaryRel(123);
    //   Console.Write("(");
    //   for (int i=0 ; i < longs.Length ; i++)
    //     Console.Write((i > 0 ? ", " : "") + longs[i]);
    //   Console.WriteLine(")");
    // }
    // catch {
    //   Console.WriteLine("--");
    // }
    // Console.WriteLine("");


    var triplev_I_S_FS = testDb.AnIntStringFloatSeqTernaryRel();
    for (int i=0 ; i < triplev_I_S_FS.Length ; i++) {
      var triple = triplev_I_S_FS[i];
      Console.Write("{0}, {1}, (", triple.Item1, triple.Item2);
      for (int j=0 ; j < triple.Item3.Length ; j++)
        Console.Write("{0}{1:0.00000}", j > 0 ? ", " : "", triple.Item3[j]);
      Console.WriteLine(")");
    }
    Console.WriteLine("");

    Console.Write((testDb.AnIntStringFloatSeqTernaryRel(0, "pi - e", new double[] {3.14159, 2.71828}) ? 1 : 0) + " ");
    Console.Write((testDb.AnIntStringFloatSeqTernaryRel(0, "sqrt(2) - sqrt(3)", new double[] {1.41421, 1.73205}) ? 1 : 0) + " ");
    Console.WriteLine(testDb.AnIntStringFloatSeqTernaryRel(0, "sqrt(2) - sqrt(3)", new double[] {141421e-5, 173205e-5}) ? 1 : 0);
    Console.WriteLine("");

    var triplev_S_I_BS = testDb.ASymbIntBoolSeqTernaryRel();
    for (int i=0 ; i < triplev_S_I_BS.Length ; i++) {
      var triple = triplev_S_I_BS[i];
      Console.Write("{0}, {1}, (", triple.Item1, triple.Item2);
      for (int j=0 ; j < triple.Item3.Length ; j++)
        Console.Write("{0}{1}", j > 0 ? ", " : "", triple.Item3[j] ? 1 : 0);
      Console.WriteLine(")");
    }
    Console.WriteLine("");

    Console.Write((testDb.ASymbIntBoolSeqTernaryRel("one",   1, new bool[] {true}) ? 1 : 0) + " ");
    Console.Write((testDb.ASymbIntBoolSeqTernaryRel("two",   2, new bool[] {true, false}) ? 1 : 0) + " ");
    Console.Write((testDb.ASymbIntBoolSeqTernaryRel("three", 3, new bool[] {true, true}) ? 1 : 0) + " ");
    Console.WriteLine((testDb.ASymbIntBoolSeqTernaryRel("four",  4, new bool[] {true, false, false}) ? 1 : 0) + " ");

    Console.Write((testDb.ASymbIntBoolSeqTernaryRel("(true)", 1, new bool[] {true}) ? 1 : 0) + " ");
    Console.Write((testDb.ASymbIntBoolSeqTernaryRel("two",    2, new bool[] {false, false}) ? 1 : 0) + " ");
    Console.Write((testDb.ASymbIntBoolSeqTernaryRel("three",  3, new bool[] {true}) ? 1 : 0) + " ");
    Console.Write((testDb.ASymbIntBoolSeqTernaryRel("four",   5, new bool[] {true, false, false}) ? 1 : 0) + " ");

    Console.WriteLine("\n");
    testDb.Save(Console.OpenStandardOutput());
    Console.WriteLine("\n");
  }
}