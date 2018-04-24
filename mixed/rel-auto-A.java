package net.cell_lang;

import java.nio.file.Paths;
import java.nio.file.Files;
import java.io.IOException;
import java.io.OutputStreamWriter;


class RelAutoA_Tests {
  public static void run(String file, boolean setState) throws IOException {
    RelAutoA testDb = new RelAutoA();

    if (file != null) {
      String content = new String(Files.readAllBytes(Paths.get(file)));
      if (setState)
        testDb.setState(content);
      else
        testDb.execute(content);
    }
    else
      testDb.execute("my_msg");

    boolean boolOutput = testDb.aBoolVar();
    long longOutput = testDb.anIntVar();
    double doubleOutput = testDb.aFloatVar();
    Value symbOutput = testDb.aSymbVar();

    String str = testDb.aStringVar();
    boolean[] bools = testDb.aBoolSeqVar();
    long[] longs = testDb.anIntSeqVar();
    double[] doubles = testDb.aFloatSeqVar();

    System.out.printf("%s - %d - %f - %s - %s\n", boolOutput ? "true" : "false", longOutput, doubleOutput, symbOutput.toString(), str);
    for (int i=0 ; i < bools.length ; i++)
      System.out.printf("%d ", bools[i] ? 1 : 0);
    System.out.println("");
    for (int i=0 ; i < longs.length ; i++)
      System.out.printf("%d ", longs[i]);
    System.out.println("");
    for (int i=0 ; i < doubles.length ; i++)
      System.out.printf("%.6f ", doubles[i]);
    System.out.println("\n");

    Double_String_Long_Seq tuple_3A = testDb.aTupleVar();
    double f0 = tuple_3A.item1;
    str = tuple_3A.item2;
    longs = tuple_3A.item3;

    System.out.printf("%.6f - %s -", f0, str);
    for (int i=0 ; i < longs.length ; i++)
      System.out.printf(" %d", longs[i]);
    System.out.println("");

    DateRec aDateRec = testDb.aDateRecVar();
    long day = aDateRec.day;
    long month = aDateRec.month;
    long year = aDateRec.year;
    System.out.printf("%d/%02d/%d\n\n", day, month, year);

    Point[] aPointSeq = testDb.aPointSeqVar();
    for (int i=0 ; i < aPointSeq.length ; i++)
      System.out.printf("%s ", aPointSeq[i].toString());
    System.out.println("");

    Point aPointVar = testDb.aPointVar();
    long x = aPointVar.x;
    long y = aPointVar.y;
    System.out.println(aPointVar.toString());

    Date date = testDb.aDateVar();
    day = date.item1;
    month = date.item2;
    year = date.item3;
    System.out.println(date.toString());

    long time_span = testDb.aTimeSpanVar();
    System.out.printf("msecs(%d)\n", time_span);

    longs = testDb.aTimeSpanSeqVar();
    for (int i=0 ; i < longs.length ; i++)
      System.out.printf("msecs(%d) ", longs[i]);
    System.out.println("");

    AnyPoint anyPoint = testDb.anAnyPointVar();
    System.out.println(anyPoint.toString());

    Rect rect = testDb.aRectVar();
    double width = rect.width;
    double height = rect.height;
    Color color = rect.color;
    x = rect.bottomLeft.x;
    y = rect.bottomLeft.y;
    System.out.printf("(bottom_left: %s, x: %d, y: %d, width: %.6f, height: %.6f, color: %s)\n\n",
      rect.bottomLeft.toString(), x, y, width, height, color.toString());

    int[] elems = new int[] {0, 1, -1, 100, -1000, 2, -2, 10, -100, 1000};
    for (int i=0 ; i < 10 ; i++)
      System.out.printf("%d ", testDb.anIntUnaryRel(elems[i]) ? 1 : 0);
    System.out.println("");

    System.out.print("[");
    boolean[] boolv = testDb.aBoolUnaryRel();
    for (int i=0 ; i < boolv.length ; i++)
      System.out.printf("%s%s", i == 0 ? "" : ", ", boolv[i] ? "true" : "false");
    System.out.println("]\n");

    System.out.print("[");
    long[] intv = testDb.anIntUnaryRel();
    for (int i=0 ; i < intv.length ; i++)
      System.out.printf("%s%d", i == 0 ? "" : ", ", intv[i]);
    System.out.println("]\n");

    System.out.print("[");
    double[] doubleV = testDb.aFloatUnaryRel();
    for (int i=0 ; i < doubleV.length ; i++)
      System.out.printf("%s%.6f", i == 0 ? "" : ", ", doubleV[i]);
    System.out.println("]\n");

    System.out.print("[");
    Value[] values = testDb.aSymbUnaryRel();
    for (int i=0 ; i < values.length ; i++)
      System.out.printf("%s%s", i == 0 ? "" : ", ", values[i].toString());
    System.out.println("]\n");

    System.out.print("[");
    String[] strV = testDb.aStringUnaryRel();
    for (int i=0 ; i < strV.length ; i++)
      System.out.printf("%s\"%s\"", i == 0 ? "" : ", ", strV[i]);
    System.out.println("]\n");

    System.out.print("[");
    AnyPoint[] anyPointV = testDb.anAnyPointUnaryRel();
    for (int i=0 ; i < anyPointV.length ; i++)
      System.out.printf("%s%s", i == 0 ? "" : ", ", anyPointV[i].toString());
    System.out.println("]\n");

    //////////////////////////////////////////////////////////////////////////////

    boolean[][] boolvv = testDb.aBoolSeqUnaryRel();
    for (int i=0 ; i < boolvv.length ; i++) {
      boolv = boolvv[i];
      for (int j=0 ; j < boolv.length ; j++)
        System.out.printf("%s%s", j == 0 ? "" : " ", boolv[j] ? "true" : "false");
      System.out.println("");
    }
    System.out.println("");

    long[][] intvv = testDb.anIntSeqUnaryRel();
    for (int i=0 ; i < intvv.length ; i++) {
      intv = intvv[i];
      for (int j=0 ; j < intv.length ; j++)
        System.out.printf("%s%s", j == 0 ? "" : " ", (int) intv[j]);
      System.out.println("");
    }
    System.out.println("");

    double[][] doubleVV = testDb.aFloatSeqUnaryRel();
    for (int i=0 ; i < doubleVV.length ; i++) {
      doubleV = doubleVV[i];
      for (int j=0 ; j < doubleV.length ; j++)
        System.out.printf("%s%.6f", j == 0 ? "" : " ", doubleV[j]);
      System.out.println("");
    }
    System.out.println("");

    System.out.print("[");
    Value[][] symbVV = testDb.aSymbSeqUnaryRel();
    for (int i=0 ; i < symbVV.length ; i++) {
      Value[] symbV = symbVV[i];
      for (int j=0 ; j < symbV.length ; j++)
        System.out.printf("%s%s", j == 0 ? "" : ", ", symbV[j].toString());
      System.out.print("; ");
    }
    System.out.println("]\n");

    System.out.print("[");
    String[][] strVV = testDb.aStringSeqUnaryRel();
    for (int i=0 ; i < strVV.length ; i++) {
      strV = strVV[i];
      for (int j=0 ; j < strV.length ; j++)
        System.out.printf("%s%s", i == 0 ? "" : ", ", strV[j]);
      System.out.print("; ");
    }
    System.out.println("]\n");


    boolean[] membTests = new boolean[8];

    membTests[0] = testDb.aSymbFloatBinaryRel("pi", 314159e-5);
    membTests[1] = testDb.aSymbFloatBinaryRel("e", 271828e-5);
    membTests[2] = testDb.aSymbFloatBinaryRel("sqrt2", 141421e-5);
    membTests[3] = testDb.aSymbFloatBinaryRel("sqrt3", 173205e-5);

    membTests[4] = testDb.aSymbFloatBinaryRel("pi", 271828e-5);
    membTests[5] = testDb.aSymbFloatBinaryRel("e", 314159e-5);
    membTests[6] = testDb.aSymbFloatBinaryRel("sqrt2", 173205e-5);
    membTests[7] = testDb.aSymbFloatBinaryRel("sqrt3", 141421e-5);

    for (int i=0 ; i < 8 ; i++)
      System.out.printf("%d ", membTests[i] ? 1 : 0);
    System.out.println("");

    System.out.print("[");
    Pair<Value[], double[]> valueDoubleR = testDb.aSymbFloatBinaryRel();
    for (int i=0 ; i < valueDoubleR.item1.length ; i++)
      System.out.printf("%s(%s, %.6f)", i == 0 ? "" : ", ", valueDoubleR.item1[i].toString(), valueDoubleR.item2[i]);
    System.out.println("]\n\n");

    String[] symbV = new String[] {"pi", "e", "sqrt2", "sqrt3", "sqrt5", "non-key"};
    doubleV = new double[] {271828e-5, 314159e-5, 173205e-5, 141421e-5, 223607e-5};
    for (int i=0 ; i < 6 ; i++) {
      String symb = symbV[i];
      System.out.printf("%s: ", symb);
      double d = 0;
      try {
        d = testDb.aSymbFloatBinaryRel(symb);
        System.out.printf("%.6f\n", d);
      }
      catch (Exception e) {
        System.out.println("--");
      }
    }
    System.out.println("");
    // for (int i=0 ; i < 5 ; i++) {
    //   System.out.printf("%.6f: ", doubleV[i]);
    //   String[] results = testDb.bycol1_A_symb_float_binary_rel(doubleV[i]);
    //   for (int j=0 ; j < results.length ; j++)
    //     System.out.print(" {1}", results[j]);
    //   System.out.println("");
    // }
    // puts("\n");

    Pair<boolean[], long[]> boolLongR = testDb.aBoolIntBinaryRel();
    for (int i=0 ; i < boolLongR.item1.length ; i++)
      System.out.printf("(%d, %d) ", boolLongR.item1[i] ? 1 : 0, boolLongR.item2[i]);
    System.out.println("");

    Pair<String[], boolean[][]> stringBoolsR = testDb.aStringBoolSeqBinaryRel();
    for (int i=0 ; i < stringBoolsR.item1.length ; i++) {
      System.out.printf("(\"%s\", (", stringBoolsR.item1[i]);
      boolv = stringBoolsR.item2[i];
      for (int j=0 ; j < boolv.length ; j++)
        System.out.printf("%s%d", j > 0 ? ", " : "", boolv[j] ? 1 : 0);
      System.out.print(")) ");
    }
    System.out.println("");

    Pair<long[][], long[]> longsLongR = testDb.anIntSeqTimeSpanBinaryRel();
    for (int i=0 ; i < longsLongR.item1.length ; i++) {
      System.out.print("((");
      long[] longV = longsLongR.item1[i];
      for (int j=0 ; j < longV.length ; j++)
        System.out.printf("%s%d", j > 0 ? ", " : "", longV[j]);
      System.out.printf("), %d) ", longsLongR.item2[i]);
    }
    System.out.println("\n\n");

    System.out.printf("pi      = %8s %.6f\n", testDb.lookupByFloat(314159e-5).toString(), testDb.lookupBySymb("pi"));
    System.out.printf("e       = %8s %.6f\n", testDb.lookupByFloat(271828e-5).toString(), testDb.lookupBySymb("e"));
    System.out.printf("sqrt(2) = %8s %.6f\n", testDb.lookupByFloat(141421e-5).toString(), testDb.lookupBySymb("sqrt2"));
    System.out.printf("sqrt(3) = %8s %.6f\n", testDb.lookupByFloat(173205e-5).toString(), testDb.lookupBySymb("sqrt3"));

    // System.out.printf("pi      = %8s %s", testDb.lookup("314159e-5"), testDb.lookup("pi"));
    // System.out.printf("e       = %8s %s", testDb.lookup("271828e-5"), testDb.lookup("e"));
    // System.out.printf("sqrt(2) = %8s %s", testDb.lookup("141421e-5"), testDb.lookup("sqrt2"));
    // System.out.printf("sqrt(3) = %8s %s", testDb.lookup("173205e-5"), testDb.lookup("sqrt3"));

    System.out.printf("pi      = %8s %s\n", testDb.lookup("3.14159").toString(), testDb.lookup("pi").toString());
    System.out.printf("e       = %8s %s\n", testDb.lookup("2.71828").toString(), testDb.lookup("e").toString());
    System.out.printf("sqrt(2) = %8s %s\n", testDb.lookup("1.41421").toString(), testDb.lookup("sqrt2").toString());
    System.out.printf("sqrt(3) = %8s %s\n", testDb.lookup("1.73205").toString(), testDb.lookup("sqrt3").toString());

    // testDb.lookup("314159e-5");

    // std::String call_Lookup(string);
    // std::String call_Alt_lookup(string);

    // double call_Lookup_by_symb(string);
    // stringcall_Lookup_by_float(double );

    // for b, i <- ((true, 0), (true, 1), (false, _neg_(1)), (false, 2), (true, _neg_(72305))):
    //   insert a_bool_int_binary_rel(b, i);
    // ;

    System.out.println("");

    System.out.printf("%d -> %s\n",      0, testDb.lookupByInt(0) ? "true" : "false");
    System.out.printf("%d -> %s\n",      1, testDb.lookupByInt(1) ? "true" : "false");
    System.out.printf("%d -> %s\n",     -1, testDb.lookupByInt(-1) ? "true" : "false");
    System.out.printf("%d -> %s\n",      2, testDb.lookupByInt(2) ? "true" : "false");
    System.out.printf("%d -> %s\n", -72305, testDb.lookupByInt(-72305) ? "true" : "false");

    System.out.printf("%d -> %s\n",      0, testDb.lookup("0").toString());
    System.out.printf("%d -> %s\n",      1, testDb.lookup("1").toString());
    System.out.printf("%d -> %s\n",     -1, testDb.lookup("-1").toString());
    System.out.printf("%d -> %s\n",      2, testDb.lookup("2").toString());
    System.out.printf("%d -> %s\n", -72305, testDb.lookup("-72305").toString());

    System.out.println("");

    System.out.print("\"010\"    -> (");
    boolean[] bools2 = testDb.lookupByString("010");
    for (int i=0 ; i < bools2.length ; i++)
      System.out.printf("%s%d", i > 0 ? ", " : "", bools2[i] ? 1 : 0);
    System.out.println(")");

    System.out.print("\"100110\" -> (");
    bools2 = testDb.lookupByString("100110");
    for (int i=0 ; i < bools2.length ; i++)
      System.out.printf("%s%d", i > 0 ? ", " : "", bools2[i] ? 1 : 0);
    System.out.println(")");

    System.out.print("\"\"       -> (");
    bools2 = testDb.lookupByString("");
    for (int i=0 ; i < bools2.length ; i++)
      System.out.printf("%s%d", i > 0 ? ", " : "", bools2[i] ? 1 : 0);
    System.out.println(")");

    // System.out.println('"' << testDb.altLookup("(false, true, false)") << '"' << endl;
    // System.out.println('"' << testDb.altLookup("(true, false, false, true, true, false)") << '"' << endl;
    // System.out.println('"' << testDb.altLookup("()") << '"' << endl << endl;

    System.out.print(testDb.altLookup("msecs(123)").toString() + " : ");
    System.out.println(testDb.altLookup("(0, 1, 2, 3)").toString());
    System.out.print(testDb.altLookup("msecs(98765)").toString() + " : ");
    System.out.println(testDb.altLookup("(9, 8, 7, 6, 5)").toString());

    System.out.println("");

    Value_Double[] symbDoubleV = testDb.symbsAndFloats();
    for (int i=0 ; i < symbDoubleV.length ; i++)
      System.out.printf("(%s, %.5f) ", symbDoubleV[i].item1, symbDoubleV[i].item2);
    System.out.println("\n");

    System.out.println(testDb.hasStringBoolSeqPair("010", new boolean[] {false, true, false}) ? 1 : 0);
    System.out.println(testDb.hasStringBoolSeqPair("100110", new boolean[] {true, false, false, true, true, false}) ? 1 : 0);
    System.out.println(testDb.hasStringBoolSeqPair("", new boolean[0]) ? 1 : 0);
    System.out.println(testDb.hasStringBoolSeqPair("010", new boolean[] {false, true}) ? 1 : 0);
    System.out.println(testDb.hasStringBoolSeqPair("100110", new boolean[] {true, false, false}) ? 1 : 0);
    System.out.println(testDb.hasStringBoolSeqPair("010", new boolean[] {true, false, false, true, true, false}) ? 1 : 0);
    System.out.println(testDb.hasStringBoolSeqPair("100110", new boolean[] {false, true, false}) ? 1 : 0);

    Value value = testDb.anIntToSymbMapVar();
    System.out.println("\n" + value.toString() + "\n");

    System.out.print("msecs(123) -> ");
    try {
      longs = testDb.anIntSeqTimeSpanBinaryRel(123);
      System.out.print("(");
      for (int i=0 ; i < longs.length ; i++)
        System.out.print((i > 0 ? ", " : "") + longs[i]);
      System.out.println(")");
    }
    catch (Exception e) {
      System.out.println("--");
    }
    System.out.println("");

    Triplet<long[], String[], double[][]> longStringDoubleR = testDb.anIntStringFloatSeqTernaryRel();
    for (int i=0 ; i < longStringDoubleR.item1.length ; i++) {
      System.out.printf("%d, %s, (", longStringDoubleR.item1[i], longStringDoubleR.item2[i]);
      for (int j=0 ; j < longStringDoubleR.item3[i].length ; j++)
        System.out.printf("%s%.5f", j > 0 ? ", " : "", longStringDoubleR.item3[i][j]);
      System.out.println(")");
    }
    System.out.println("");

    System.out.print((testDb.anIntStringFloatSeqTernaryRel(0, "pi - e", new double[] {3.14159, 2.71828}) ? 1 : 0) + " ");
    System.out.print((testDb.anIntStringFloatSeqTernaryRel(0, "sqrt(2) - sqrt(3)", new double[] {1.41421, 1.73205}) ? 1 : 0) + " ");
    System.out.println(testDb.anIntStringFloatSeqTernaryRel(0, "sqrt(2) - sqrt(3)", new double[] {141421e-5, 173205e-5}) ? 1 : 0);
    System.out.println("");

    Triplet<Value[], long[], boolean[][]> stringLongBoolsR = testDb.aSymbIntBoolSeqTernaryRel();
    for (int i=0 ; i < stringLongBoolsR.item1.length ; i++) {
      System.out.printf("%s, %d, (", stringLongBoolsR.item1[i].toString(), stringLongBoolsR.item2[i]);
      for (int j=0 ; j < stringLongBoolsR.item3[i].length ; j++)
        System.out.printf("%s%d", j > 0 ? ", " : "", stringLongBoolsR.item3[i][j] ? 1 : 0);
      System.out.println(")");
    }
    System.out.println("");

    System.out.print((testDb.aSymbIntBoolSeqTernaryRel("one",   1, new boolean[] {true}) ? 1 : 0) + " ");
    System.out.print((testDb.aSymbIntBoolSeqTernaryRel("two",   2, new boolean[] {true, false}) ? 1 : 0) + " ");
    System.out.print((testDb.aSymbIntBoolSeqTernaryRel("three", 3, new boolean[] {true, true}) ? 1 : 0) + " ");
    System.out.println((testDb.aSymbIntBoolSeqTernaryRel("four",  4, new boolean[] {true, false, false}) ? 1 : 0) + " ");

    System.out.print((testDb.aSymbIntBoolSeqTernaryRel("(true)", 1, new boolean[] {true}) ? 1 : 0) + " ");
    System.out.print((testDb.aSymbIntBoolSeqTernaryRel("two",    2, new boolean[] {false, false}) ? 1 : 0) + " ");
    System.out.print((testDb.aSymbIntBoolSeqTernaryRel("three",  3, new boolean[] {true}) ? 1 : 0) + " ");
    System.out.print((testDb.aSymbIntBoolSeqTernaryRel("four",   5, new boolean[] {true, false, false}) ? 1 : 0) + " ");

    System.out.println("\n");

    Value state = testDb.readState();

    // FileOutputStream file = new FileOutputStream(outFnName);
    OutputStreamWriter writer = new OutputStreamWriter(System.out);
    state.print(writer);
    writer.write("\n\n");
    writer.flush();
  }
}