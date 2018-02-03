using System;
using System.IO;

using CellLang;


public static class TrAutoA_Tests {
  public static void Run(string file, bool setState) {
    Generated.TrAutoA testDb = new Generated.TrAutoA();

    if (file != null) {
      string content = System.IO.File.ReadAllText(file);
      if (setState)
        testDb.SetState(content);
      else
        testDb.Execute(content);
    }
    else
      testDb.Execute("my_msg");

    bool boolOutput = testDb.Get_A_bool_var();
    long longOutput = testDb.Get_An_int_var();
    double doubleOutput = testDb.Get_A_float_var();
    string symbOutput = testDb.Get_A_symb_var();

    string str = testDb.Get_A_string_var();
    bool[] bools = testDb.Get_A_bool_seq_var();
    long[] longs = testDb.Get_An_int_seq_var();
    double[] doubles = testDb.Get_A_float_seq_var();

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

    Tuple<double, string, long[]> tuple_3A = testDb.Get_A_tuple_var();
    double f0 = tuple_3A.Item1;
    str = tuple_3A.Item2;
    longs = tuple_3A.Item3;

    Console.Write("{0:0.000000} - {1} -", f0, str);
    for (int i=0 ; i < longs.Length ; i++)
      Console.Write(" {0}", longs[i]);
    Console.WriteLine("");

    Value val = testDb.Get_A_date_rec_var();
    long day = val.Lookup("day").AsLong();
    long month = val.Lookup("month").AsLong();
    long year = val.Lookup("year").AsLong();
    Console.WriteLine("{0}/{1:00}/{2}\n", day, month, year);

    Value[] vals = testDb.Get_A_point_seq_var();
    for (int i=0 ; i < vals.Length ; i++)
      Console.Write("{0} ", vals[i].ToString());
    Console.WriteLine("");

    long x = testDb.Get_A_point_var().Lookup("x").AsLong();
    long y = testDb.Get_A_point_var().Lookup("y").AsLong();
    Console.WriteLine("point(x: {0}, y: {1})", x, y);

    Tuple<long, long, long> tuple_3B = testDb.Get_A_date_var();
    day = tuple_3B.Item1;
    month = tuple_3B.Item2;
    year = tuple_3B.Item3;
    Console.WriteLine("date({0}, {1}, {2})", day, month, year);

    long time_span = testDb.Get_A_time_span_var();
    Console.WriteLine("msecs({0})", time_span);

    longs = testDb.Get_A_time_span_seq_var();
    for (int i=0 ; i < longs.Length ; i++)
      Console.Write("msecs({0}) ", longs[i]);
    Console.WriteLine("");

    val = testDb.Get_An_any_point_var();
    Console.WriteLine(val.ToString());

    val = testDb.Get_A_rect_var();
    double width = val.Lookup("width").AsDouble();
    double height = val.Lookup("height").AsDouble();
    string color = val.Lookup("color").AsSymb();
    x = val.Lookup("bottom_left").Lookup("x").AsLong();
    y = val.Lookup("bottom_left").Lookup("y").AsLong();
    Console.WriteLine("(bottom_left: {0}, x: {1}, y: {2}, width: {3:0.000000}, height: {4:0.000000}, color: {5})\n",
      val.Lookup("bottom_left").ToString(), x, y, width, height, color);

    int[] elems = new int[] {0, 1, -1, 100, -1000, 2, -2, 10, -100, 1000};
    for (int i=0 ; i < 10 ; i++)
      Console.Write("{0} ", testDb.In_An_int_unary_rel(elems[i]) ? 1 : 0);
    Console.WriteLine("");

    Console.Write("[");
    bool[] boolv = testDb.Get_A_bool_unary_rel();
    for (int i=0 ; i < boolv.Length ; i++)
      Console.Write("{0}{1}", i == 0 ? "" : ", ", boolv[i] ? "true" : "false");
    Console.WriteLine("]\n");

    Console.Write("[");
    long[] intv = testDb.Get_An_int_unary_rel();
    for (int i=0 ; i < intv.Length ; i++)
      Console.Write("{0}{1}", i == 0 ? "" : ", ", intv[i]);
    Console.WriteLine("]\n");

    Console.Write("[");
    double[] floatv = testDb.Get_A_float_unary_rel();
    for (int i=0 ; i < floatv.Length ; i++)
      Console.Write("{0}{1:0.000000}", i == 0 ? "" : ", ", floatv[i]);
    Console.WriteLine("]\n");

    Console.Write("[");
    string[] symbv = testDb.Get_A_symb_unary_rel();
    for (int i=0 ; i < symbv.Length ; i++)
      Console.Write("{0}{1:0.000000}", i == 0 ? "" : ", ", symbv[i]);
    Console.WriteLine("]\n");

    Console.Write("[");
    string[] strv = testDb.Get_A_string_unary_rel();
    for (int i=0 ; i < strv.Length ; i++)
      Console.Write("{0}\"{1}\"", i == 0 ? "" : ", ", strv[i]);
    Console.WriteLine("]\n");

    Console.Write("[");
    vals = testDb.Get_An_any_point_unary_rel();
    for (int i=0 ; i < vals.Length ; i++)
      Console.Write("{0}{1}", i == 0 ? "" : ", ", vals[i].ToString());
    Console.WriteLine("]\n");

    //////////////////////////////////////////////////////////////////////////////

    bool[][] boolvv = testDb.Get_A_bool_seq_unary_rel();
    for (int i=0 ; i < boolvv.Length ; i++) {
      boolv = boolvv[i];
      for (int j=0 ; j < boolv.Length ; j++)
        Console.Write("{0}{1}", j == 0 ? "" : " ", boolv[j] ? "true" : "false");
      Console.WriteLine("");
    }
    Console.WriteLine("");

    long[][] intvv = testDb.Get_An_int_seq_unary_rel();
    for (int i=0 ; i < intvv.Length ; i++) {
      intv = intvv[i];
      for (int j=0 ; j < intv.Length ; j++)
        Console.Write("{0}{1}", j == 0 ? "" : " ", (int) intv[j]);
      Console.WriteLine("");
    }
    Console.WriteLine("");

    double[][] floatvv = testDb.Get_A_float_seq_unary_rel();
    for (int i=0 ; i < floatvv.Length ; i++) {
      floatv = floatvv[i];
      for (int j=0 ; j < floatv.Length ; j++)
        Console.Write("{0}{1:0.000000}", j == 0 ? "" : " ", floatv[j]);
      Console.WriteLine("");
    }
    Console.WriteLine("");

    Console.Write("[");
    string[][] symbvv = testDb.Get_A_symb_seq_unary_rel();
    for (int i=0 ; i < symbvv.Length ; i++) {
      symbv = symbvv[i];
      for (int j=0 ; j < symbv.Length ; j++)
        Console.Write("{0}{1}", j == 0 ? "" : ", ", symbv[j]);
      Console.Write("; ");
    }
    Console.WriteLine("]\n");

    Console.Write("[");
    string[][] strvv = testDb.Get_A_string_seq_unary_rel();
    for (int i=0 ; i < strvv.Length ; i++) {
      strv = strvv[i];
      for (int j=0 ; j < strv.Length ; j++)
        Console.Write("{0}{1}", i == 0 ? "" : ", ", strv[j]);
      Console.Write("; ");
    }
    Console.WriteLine("]\n");


    bool[] memb_tests = new bool[8];

    memb_tests[0] = testDb.In_A_symb_float_binary_rel("pi", 314159e-5);
    memb_tests[1] = testDb.In_A_symb_float_binary_rel("e", 271828e-5);
    memb_tests[2] = testDb.In_A_symb_float_binary_rel("sqrt2", 141421e-5);
    memb_tests[3] = testDb.In_A_symb_float_binary_rel("sqrt3", 173205e-5);

    memb_tests[4] = testDb.In_A_symb_float_binary_rel("pi", 271828e-5);
    memb_tests[5] = testDb.In_A_symb_float_binary_rel("e", 314159e-5);
    memb_tests[6] = testDb.In_A_symb_float_binary_rel("sqrt2", 173205e-5);
    memb_tests[7] = testDb.In_A_symb_float_binary_rel("sqrt3", 141421e-5);

    for (int i=0 ; i < 8 ; i++)
      Console.Write("{0} ", memb_tests[i] ? 1 : 0);
    Console.WriteLine("");


    Console.Write("[");
    Tuple<string, double>[] pairs_SF = testDb.Get_A_symb_float_binary_rel();
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
        d = testDb.Lookup_A_symb_float_binary_rel(symb);
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

    Tuple<bool, long>[] pairs_BI = testDb.Get_A_bool_int_binary_rel();
    for (int i=0 ; i < pairs_BI.Length ; i++)
      Console.Write("({0}, {1}) ", pairs_BI[i].Item1 ? 1 : 0, pairs_BI[i].Item2);
    Console.WriteLine("");

    Tuple<string, bool[]>[] pairs_SBS = testDb.Get_A_string_bool_seq_binary_rel();
    for (int i=0 ; i < pairs_SBS.Length ; i++) {
      Console.Write("(\"{0}\", (", pairs_SBS[i].Item1);
      boolv = pairs_SBS[i].Item2;
      for (int j=0 ; j < boolv.Length ; j++)
        Console.Write("{0}{1}", j > 0 ? ", " : "", boolv[j] ? 1 : 0);
      Console.Write(")) ");
    }
    Console.WriteLine("");

    Tuple<long[], long>[] pairs_ISTS = testDb.Get_An_int_seq_time_span_binary_rel();
    for (int i=0 ; i < pairs_ISTS.Length ; i++) {
      Console.Write("((");
      long[] llongv = pairs_ISTS[i].Item1;
      for (int j=0 ; j < llongv.Length ; j++)
        Console.Write("{0}{1}", j > 0 ? ", " : "", llongv[j]);
      Console.Write("), {0}) ", pairs_ISTS[i].Item2);
    }
    Console.WriteLine("\n\n");

    Console.WriteLine("pi      = {0,8} {1:0.000000}", testDb.Call_Lookup_by_float(314159e-5), testDb.Call_Lookup_by_symb("pi"));
    Console.WriteLine("e       = {0,8} {1:0.000000}", testDb.Call_Lookup_by_float(271828e-5), testDb.Call_Lookup_by_symb("e"));
    Console.WriteLine("sqrt(2) = {0,8} {1:0.000000}", testDb.Call_Lookup_by_float(141421e-5), testDb.Call_Lookup_by_symb("sqrt2"));
    Console.WriteLine("sqrt(3) = {0,8} {1:0.000000}", testDb.Call_Lookup_by_float(173205e-5), testDb.Call_Lookup_by_symb("sqrt3"));

    // Console.WriteLine("pi      = %8s %s", testDb.Call_Lookup("314159e-5"), testDb.Call_Lookup("pi"));
    // Console.WriteLine("e       = %8s %s", testDb.Call_Lookup("271828e-5"), testDb.Call_Lookup("e"));
    // Console.WriteLine("sqrt(2) = %8s %s", testDb.Call_Lookup("141421e-5"), testDb.Call_Lookup("sqrt2"));
    // Console.WriteLine("sqrt(3) = %8s %s", testDb.Call_Lookup("173205e-5"), testDb.Call_Lookup("sqrt3"));

    Console.WriteLine("pi      = {0,8} {1:0.00000}", testDb.Call_Lookup("3.14159").ToString(), testDb.Call_Lookup("pi").ToString());
    Console.WriteLine("e       = {0,8} {1:0.00000}", testDb.Call_Lookup("2.71828").ToString(), testDb.Call_Lookup("e").ToString());
    Console.WriteLine("sqrt(2) = {0,8} {1:0.00000}", testDb.Call_Lookup("1.41421").ToString(), testDb.Call_Lookup("sqrt2").ToString());
    Console.WriteLine("sqrt(3) = {0,8} {1:0.00000}", testDb.Call_Lookup("1.73205").ToString(), testDb.Call_Lookup("sqrt3").ToString());

    // testDb.Call_Lookup("314159e-5");

    // std::string call_Lookup(string);
    // std::string call_Alt_lookup(string);

    // double call_Lookup_by_symb(string);
    // stringcall_Lookup_by_float(double );

    // for b, i <- ((true, 0), (true, 1), (false, _neg_(1)), (false, 2), (true, _neg_(72305))):
    //   insert a_bool_int_binary_rel(b, i);
    // ;

    Console.WriteLine("");

    Console.WriteLine("{0} -> {1}",      0, testDb.Call_Lookup_by_int(0) ? "true" : "false");
    Console.WriteLine("{0} -> {1}",      1, testDb.Call_Lookup_by_int(1) ? "true" : "false");
    Console.WriteLine("{0} -> {1}",     -1, testDb.Call_Lookup_by_int(-1) ? "true" : "false");
    Console.WriteLine("{0} -> {1}",      2, testDb.Call_Lookup_by_int(2) ? "true" : "false");
    Console.WriteLine("{0} -> {1}", -72305, testDb.Call_Lookup_by_int(-72305) ? "true" : "false");

    Console.WriteLine("{0} -> {1}",      0, testDb.Call_Lookup("0").ToString());
    Console.WriteLine("{0} -> {1}",      1, testDb.Call_Lookup("1").ToString());
    Console.WriteLine("{0} -> {1}",     -1, testDb.Call_Lookup("-1").ToString());
    Console.WriteLine("{0} -> {1}",      2, testDb.Call_Lookup("2").ToString());
    Console.WriteLine("{0} -> {1}", -72305, testDb.Call_Lookup("-72305").ToString());

    Console.WriteLine("");

    Console.Write("\"010\"    -> (");
    bool[] bools2 = testDb.Call_Lookup_by_string("010");
    for (int i=0 ; i < bools2.Length ; i++)
      Console.Write("{0}{1}", i > 0 ? ", " : "", bools2[i] ? 1 : 0);
    Console.WriteLine(")");

    Console.Write("\"100110\" -> (");
    bools2 = testDb.Call_Lookup_by_string("100110");
    for (int i=0 ; i < bools2.Length ; i++)
      Console.Write("{0}{1}", i > 0 ? ", " : "", bools2[i] ? 1 : 0);
    Console.WriteLine(")");

    Console.Write("\"\"       -> (");
    bools2 = testDb.Call_Lookup_by_string("");
    for (int i=0 ; i < bools2.Length ; i++)
      Console.Write("{0}{1}", i > 0 ? ", " : "", bools2[i] ? 1 : 0);
    Console.WriteLine(")");

    // Console.WriteLine('"' << testDb.Call_Alt_lookup("(false, true, false)") << '"' << endl;
    // Console.WriteLine('"' << testDb.Call_Alt_lookup("(true, false, false, true, true, false)") << '"' << endl;
    // Console.WriteLine('"' << testDb.Call_Alt_lookup("()") << '"' << endl << endl;

    Console.Write(testDb.Call_Alt_lookup("msecs(123)").ToString() + " : ");
    Console.WriteLine(testDb.Call_Alt_lookup("(0, 1, 2, 3)").ToString());
    Console.Write(testDb.Call_Alt_lookup("msecs(98765)").ToString() + " : ");
    Console.WriteLine(testDb.Call_Alt_lookup("(9, 8, 7, 6, 5)").ToString());

    Console.WriteLine("");

    Tuple<string, double>[] symb_float_pairs = testDb.Call_Symbs_and_floats();
    for (int i=0 ; i < symb_float_pairs.Length ; i++)
      Console.Write("({0}, {1:0.00000}) ", symb_float_pairs[i].Item1, symb_float_pairs[i].Item2);
    Console.WriteLine("\n");

    Console.WriteLine(testDb.Call_Has_string_bool_seq_pair("010", new bool[] {false, true, false}) ? 1 : 0);
    Console.WriteLine(testDb.Call_Has_string_bool_seq_pair("100110", new bool[] {true, false, false, true, true, false}) ? 1 : 0);
    Console.WriteLine(testDb.Call_Has_string_bool_seq_pair("", new bool[0]) ? 1 : 0);
    Console.WriteLine(testDb.Call_Has_string_bool_seq_pair("010", new bool[] {false, true}) ? 1 : 0);
    Console.WriteLine(testDb.Call_Has_string_bool_seq_pair("100110", new bool[] {true, false, false}) ? 1 : 0);
    Console.WriteLine(testDb.Call_Has_string_bool_seq_pair("010", new bool[] {true, false, false, true, true, false}) ? 1 : 0);
    Console.WriteLine(testDb.Call_Has_string_bool_seq_pair("100110", new bool[] {false, true, false}) ? 1 : 0);

    val = testDb.Get_An_int_to_symb_map_var();
    Console.WriteLine("\n" + val.ToString() + "\n");

    Console.Write("msecs(123) -> ");
    try {
      longs = testDb.Lookup_An_int_seq_time_span_binary_rel(123);
      Console.Write("(");
      for (int i=0 ; i < longs.Length ; i++)
        Console.Write((i > 0 ? ", " : "") + longs[i]);
      Console.WriteLine(")");
    }
    catch {
      Console.WriteLine("--");
    }
    Console.WriteLine("");

    Tuple<long, string, double[]>[] triplev_I_S_FS = testDb.Get_An_int_string_float_seq_ternary_rel();
    for (int i=0 ; i < triplev_I_S_FS.Length ; i++) {
      Tuple<long, string, double[]> triple = triplev_I_S_FS[i];
      Console.Write("{0}, {1}, (", triple.Item1, triple.Item2);
      for (int j=0 ; j < triple.Item3.Length ; j++)
        Console.Write("{0}{1:0.00000}", j > 0 ? ", " : "", triple.Item3[j]);
      Console.WriteLine(")");
    }
    Console.WriteLine("");

    Console.Write((testDb.In_An_int_string_float_seq_ternary_rel(0, "pi - e", new double[] {3.14159, 2.71828}) ? 1 : 0) + " ");
    Console.Write((testDb.In_An_int_string_float_seq_ternary_rel(0, "sqrt(2) - sqrt(3)", new double[] {1.41421, 1.73205}) ? 1 : 0) + " ");
    Console.WriteLine(testDb.In_An_int_string_float_seq_ternary_rel(0, "sqrt(2) - sqrt(3)", new double[] {141421e-5, 173205e-5}) ? 1 : 0);
    Console.WriteLine("");

    Tuple<string, long, bool[]>[] triplev_S_I_BS = testDb.Get_A_symb_int_bool_seq_ternary_rel();
    for (int i=0 ; i < triplev_S_I_BS.Length ; i++) {
      Tuple<string, long, bool[]> triple = triplev_S_I_BS[i];
      Console.Write("{0}, {1}, (", triple.Item1, triple.Item2);
      for (int j=0 ; j < triple.Item3.Length ; j++)
        Console.Write("{0}{1}", j > 0 ? ", " : "", triple.Item3[j] ? 1 : 0);
      Console.WriteLine(")");
    }
    Console.WriteLine("");

    Console.Write((testDb.In_A_symb_int_bool_seq_ternary_rel("one",   1, new bool[] {true}) ? 1 : 0) + " ");
    Console.Write((testDb.In_A_symb_int_bool_seq_ternary_rel("two",   2, new bool[] {true, false}) ? 1 : 0) + " ");
    Console.Write((testDb.In_A_symb_int_bool_seq_ternary_rel("three", 3, new bool[] {true, true}) ? 1 : 0) + " ");
    Console.WriteLine((testDb.In_A_symb_int_bool_seq_ternary_rel("four",  4, new bool[] {true, false, false}) ? 1 : 0) + " ");

    Console.Write((testDb.In_A_symb_int_bool_seq_ternary_rel("(true)", 1, new bool[] {true}) ? 1 : 0) + " ");
    Console.Write((testDb.In_A_symb_int_bool_seq_ternary_rel("two",    2, new bool[] {false, false}) ? 1 : 0) + " ");
    Console.Write((testDb.In_A_symb_int_bool_seq_ternary_rel("three",  3, new bool[] {true}) ? 1 : 0) + " ");
    Console.Write((testDb.In_A_symb_int_bool_seq_ternary_rel("four",   5, new bool[] {true, false, false}) ? 1 : 0) + " ");

    Console.WriteLine("\n");

    Value state = testDb.ReadState();

    StreamWriter stdOutWriter = new StreamWriter(Console.OpenStandardOutput());
    stdOutWriter.AutoFlush = true;

    state.Print(stdOutWriter);
    Console.WriteLine("\n");
  }


  public static void Main(string[] args) {
    if (args.Length != 1) {
      Console.WriteLine("Usage: <executable> <directory>");
      return;
    }

    Run(args[0] + "/state-A0.txt", true);

    Console.Write("\n\n");
    for (int i=0 ; i < 80 ; i++)
      Console.Write("#");
    Console.WriteLine("\n\n");

    Run(args[0] + "/msg-A0.txt", false);
    Console.WriteLine("");
  }
}