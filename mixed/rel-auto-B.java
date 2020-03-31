import java.util.HashMap;
import java.time.LocalDate;
import java.time.LocalDateTime;

import net.cell_lang.*;


class RelAutoB_Tests {
  public static void run() {
    runBadArgsTests();
    runConvTests(true);
    runConvTests(false);
  }

  private static void runBadArgsTests() {
    RelAutoB db = new RelAutoB();

    long zero = db.myPolyMeth("\"Hi!\"", "0.0");
    long one  = db.myPolyMeth("\"Hi!\"", "0");
    if (zero != 0 | one != 1) {
      System.out.printf("ERROR (1): my_poly_meth(), zero = %d, one = %d\n", zero, one);
      System.exit(1);
    }
    // long two  = db.myPolyMeth("red", "just(true)");

    try {
      db.myPolyMeth("\"Hi!\"", "true");
      System.out.println("ERROR (2): my_poly_meth(\"Hi!\", true)");
      System.exit(1);
    }
    catch (Exception e) {
      // This was expected
    }

    try {
      db.doOptionalMaybe("just(\"Hello!\")", null);
      System.out.println("ERROR (3): DoOptionalMaybe(just(\"Hello!\"), null)");
      System.exit(1);
    }
    catch (Exception e) {
      // This was expected
    }


    db.doOptionalMaybe("just(2.71828)", "just(\"Hi!\")");
    Double maybeFloatValue = db.maybeFloatMembVar();
    String maybeStringValue = db.maybeStringMembVar();
    if (maybeFloatValue.doubleValue() != 2.71828) {
      System.out.printf(
        "MaybeFloatMembVar() ERROR (1): %s, %s\n",
        maybeFloatValue.doubleValue(), maybeFloatValue.doubleValue() - 2.1818
      );
      System.exit(1);
    }
    if (!maybeStringValue.equals("Hi!")) {
      System.out.printf("MaybeStringMembVar() ERROR (1): %s\n", maybeStringValue);
      System.exit(1);
    }

    db.doOptionalMaybe(null, null);
    maybeFloatValue = db.maybeFloatMembVar();
    maybeStringValue = db.maybeStringMembVar();
    if (maybeFloatValue.doubleValue() != 2.71828) {
      System.out.printf(
        "MaybeFloatMembVar() ERROR (2): %s, %s\n",
        maybeFloatValue.doubleValue(), maybeFloatValue.doubleValue() - 2.1818
      );
      System.exit(1);
    }
    if (!maybeStringValue.equals("Hi!")) {
      System.out.printf("MaybeStringMembVar() ERROR (2): %s\n", maybeStringValue);
      System.exit(1);
    }

    db.doOptionalMaybe("nothing", "just(\"Hi!\")");
    maybeFloatValue = db.maybeFloatMembVar();
    maybeStringValue = db.maybeStringMembVar();
    if (maybeFloatValue != null) {
      System.out.printf("MaybeFloatMembVar() ERROR (3): %s\n", maybeFloatValue.doubleValue());
      System.exit(1);
    }
    if (!maybeStringValue.equals("Hi!")) {
      System.out.printf("MaybeStringMembVar() ERROR (3): %s\n", maybeStringValue);
      System.exit(1);
    }

    db.doOptionalMaybe("just(2.71828)", "nothing");
    maybeFloatValue = db.maybeFloatMembVar();
    maybeStringValue = db.maybeStringMembVar();
    if (maybeFloatValue.doubleValue() != 2.71828) {
      System.out.printf(
        "MaybeFloatMembVar() ERROR (4): %s, %s\n",
        maybeFloatValue.doubleValue(), maybeFloatValue.doubleValue() - 2.1818
      );
      System.exit(1);
    }
    if (maybeStringValue != null) {
      System.out.printf("MaybeStringMembVar() ERROR (4): %s\n", maybeStringValue);
      System.exit(1);
    }

    db.doOptionalMaybe("nothing", "nothing");
    maybeFloatValue = db.maybeFloatMembVar();
    maybeStringValue = db.maybeStringMembVar();
    if (maybeFloatValue != null) {
      System.out.printf("MaybeFloatMembVar() ERROR (5): %s\n", maybeFloatValue.doubleValue());
      System.exit(1);
    }
    if (maybeStringValue != null) {
      System.out.printf("MaybeStringMembVar() ERROR (5): %s\n", maybeStringValue);
      System.exit(1);
    }

    db.doOptionalMaybe(null, "just(\"Hi!\")");
    maybeFloatValue = db.maybeFloatMembVar();
    maybeStringValue = db.maybeStringMembVar();
    if (maybeFloatValue != null) {
      System.out.printf("MaybeFloatMembVar() ERROR (6): %s\n", maybeFloatValue.doubleValue());
      System.exit(1);
    }
    if (!maybeStringValue.equals("Hi!")) {
      System.out.printf("MaybeStringMembVar() ERROR (6): %s\n", maybeStringValue);
      System.exit(1);
    }

    db.doOptionalMaybe("just(2.71828)", null);
    maybeFloatValue = db.maybeFloatMembVar();
    maybeStringValue = db.maybeStringMembVar();
    if (maybeFloatValue.doubleValue() != 2.71828) {
      System.out.printf(
        "MaybeFloatMembVar() ERROR (7): %s, %s\n",
        maybeFloatValue.doubleValue(), maybeFloatValue.doubleValue() - 2.1818
      );
      System.exit(1);
    }
    if (!maybeStringValue.equals("Hi!")) {
      System.out.printf("MaybeStringMembVar() ERROR (7): %s\n", maybeStringValue);
      System.exit(1);
    }
  }

  public static void runConvTests(boolean doMaybe) {
    RelAutoB db = new RelAutoB();

    var aBool         = false;
    var aInt          = 42L;
    var aFloat        = 3.14159;
    var aDate         = LocalDate.of(2020, 4, 9);
    var aTime         =  LocalDateTime.of(2020, 4, 11, 3, 15, 45);

    // var aTuple        = (1000000007, "Hello world!", new DateTime(2018, 10, 19));
    var aTuple = new Long_String_LocalDate();
    aTuple.item1 = 1000000007;
    aTuple.item2 = "Hello world!";
    aTuple.item3 = LocalDate.of(2018, 10, 19);

    // var aRecord       = ( time: new DateTime(2017, 11, 24, 17, 33, 29),
    //                       label: "How long?",
    //                       maybe: (long?) null
    //                     );

    var aRecord = new Time_Label_Maybe();
    aRecord.time  = LocalDateTime.of(2017, 11, 24, 17, 33, 29);
    aRecord.label = "How long?";
    aRecord.maybe = null;


    var aString       = "Imagine there's no heaven";
    var aEmployeeId   = 8L;
    var aCustomerId   = "ANSDY";
    var aTaggedMaybe  = "id(27955, 14)";

    // var aMap          = new (long, long)[] {
    //                       (6, 98052),
    //                       (1, 19713),
    //                       (9, 3049),
    //                       (5, 8837)
    //                     };

    var aMap = new HashMap<String, Long>();
    aMap.put("employee_id(6)", 98052L);
    aMap.put("employee_id(1)", 19713L);
    aMap.put("employee_id(9)", 3049L);
    aMap.put("employee_id(5)", 8837L);

    var aByteSeq      = new long[] {72, 101, 108, 108, 111, 32, 119, 111, 114, 108, 100, 33};

    // var aTupleSeq     = new (long, DateTime, string)[] {
    //                       (47340, new DateTime(2020, 04, 09, 17, 56, 57), "\"dump-syn-prg.txt\""),
    //                       (  294, new DateTime(2020, 03, 30, 15, 17, 50), "\"empty-db.txt\""),
    //                       (  149, new DateTime(2020, 04, 08, 11, 58, 17), "\"genguids.py\""),
    //                       ( 6526, new DateTime(2020, 02, 21, 11, 03, 26), "\"german.txt\""),
    //                       (  306, new DateTime(2020, 03, 30, 18, 02, 42), "\"input-db.txt\""),
    //                       ( 7382, new DateTime(2019, 07, 28, 14, 32, 57), "\"java-test.java\""),
    //                       ( 1522, new DateTime(2019, 11, 18, 10, 17, 31), "\"la.py\""),
    //                       (  249, new DateTime(2018, 08, 06, 16, 39, 28), "\"main.cpp\"")
    //                     };

    var aTupleSeq = new EmployeeId_LocalDateTime_String[] {
      newEmployeeId_LocalDateTime_String(47340, LocalDateTime.of(2020,  4,  9, 17, 56, 57), "\"dump-syn-prg.txt\""),
      newEmployeeId_LocalDateTime_String(  294, LocalDateTime.of(2020,  3, 30, 15, 17, 50), "\"empty-db.txt\""),
      newEmployeeId_LocalDateTime_String(  149, LocalDateTime.of(2020,  4,  8, 11, 58, 17), "\"genguids.py\""),
      newEmployeeId_LocalDateTime_String( 6526, LocalDateTime.of(2020,  2, 21, 11,  3, 26), "\"german.txt\""),
      newEmployeeId_LocalDateTime_String(  306, LocalDateTime.of(2020,  3, 30, 18,  2, 42), "\"input-db.txt\""),
      newEmployeeId_LocalDateTime_String( 7382, LocalDateTime.of(2019,  7, 28, 14, 32, 57), "\"java-test.java\""),
      newEmployeeId_LocalDateTime_String( 1522, LocalDateTime.of(2019, 11, 18, 10, 17, 31), "\"la.py\""),
      newEmployeeId_LocalDateTime_String(  249, LocalDateTime.of(2018,  8,  6, 16, 39, 28), "\"main.cpp\"")
    };

    var anIntSeq      = new long[] {65535, 16777215, 2147483647, -32768, -2147483648};


    if (doMaybe) {
      db.doMaybe(
        aBool,          // maybeBool:        bool?
        aInt,           // maybeInt:         long?
        aFloat,         // maybeFloat:       double?
        aDate,          // maybeDate:        DateTime?
        aTime,          // maybeTime:        DateTime?
        aTuple,         // maybeTuple:       (long, string, DateTime)?
        aRecord,        // maybeRecord:      (DateTime time, string label, long? maybe)?
        aString,        // maybeString:      string
        aEmployeeId,    // maybeEmployeeId:  long?
        aCustomerId,    // maybeCustomerId:  string
        aTaggedMaybe,   // maybeTaggedMaybe: string
        aMap,           // maybeMap:         (long, long)[]
        aByteSeq,       // maybeByteSeq:     byte[]
        aTupleSeq,      // maybeTupleSeq:    (long, DateTime, string)[]
        anIntSeq        // maybeInt32Seq:    int[]
      );
    }
    else {
      db.doOptional(
        aBool,          // _bool:       bool?
        aInt,           // _int:        long?
        aFloat,         // _float:      double?
        aDate,          // date:        DateTime?
        aTime,          // time:        DateTime?
        aTuple,         // tuple:       (long, string, DateTime)?
        aRecord,        // record:      (DateTime time, string label, long? maybe)?
        aString,        // _string:     string
        aEmployeeId,    // employeeId:  long?
        aCustomerId,    // customerId:  string
        aTaggedMaybe,   // taggedMaybe: string
        aMap,           // map:         (long, long)[]
        aByteSeq,       // byteSeq:     byte[]
        aTupleSeq,      // tupleSeq:    (long, DateTime, string)[]
        anIntSeq        // int32Seq:    int[]
      );
    }

    if (db.maybeIntMembVar() != aInt) {
      System.out.printf("Error: %s != %s\n", db.maybeIntMembVar(), aInt);
      System.exit(1);
    }

    if (db.maybeBoolMembVar() != aBool) {
      System.out.printf("Error: %s != %s\n", db.maybeBoolMembVar(), aBool);
      System.exit(1);
    }

    if (db.maybeFloatMembVar() != aFloat) {
      System.out.printf("Error: %s != %s\n", db.maybeFloatMembVar(), aFloat);
      System.exit(1);
    }

    if (!db.maybeStringMembVar().equals(aString)) {
      System.out.printf("Error: %s != %s\n", db.maybeStringMembVar(), aString);
      System.exit(1);
    }

    if (!db.maybeDateMembVar().equals(aDate)) {
      System.out.printf("Error: %s != %s\n", db.maybeDateMembVar(), aDate);
      System.exit(1);
    }

    if (!db.maybeTimeMembVar().equals(aTime)) {
      System.out.printf("Error: %s != %s\n", db.maybeTimeMembVar(), aTime);
      System.exit(1);
    }

    if (db.maybeEmployeeIdMembVar() != aEmployeeId) {
      System.out.printf("Error: %s != %s\n", db.maybeEmployeeIdMembVar(), aEmployeeId);
      System.exit(1);
    }

    if (!db.maybeCustomerIdMembVar().equals(aCustomerId)) {
      System.out.printf("Error: %s != %s\n", db.maybeCustomerIdMembVar(), aCustomerId);
      System.exit(1);
    }

    var _aTuple = db.maybeTupleMembVar();
    if (_aTuple.item1 != aTuple.item1 || !_aTuple.item2.equals(aTuple.item2) || !aTuple.item3.equals(aTuple.item3)) {
      System.out.printf("Error: %s != %s\n", db.maybeTupleMembVar(), aTuple);
      System.exit(1);
    }

    if (!db.maybeTaggedMaybeMembVar().equals(aTaggedMaybe)) {
      System.out.printf("Error: %s != %s\n", db.maybeTaggedMaybeMembVar(), aTaggedMaybe);
      System.exit(1);
    }

    if (!arrayEquals(db.maybeByteSeqMembVar(), aByteSeq)) {
      System.out.printf("Error: %s != %s\n", db.maybeByteSeqMembVar(), aByteSeq);
      System.exit(1);
    }

    if (!arrayEquals(db.maybeInt32SeqMembVar(), anIntSeq)) {
      System.out.printf("Error: %s != %s\n", db.maybeInt32SeqMembVar(), anIntSeq);
      System.exit(1);
    }

    var _aRecord = db.maybeRecordMembVar();
    if (!_aRecord.time.equals(aRecord.time) || !_aRecord.label.equals(aRecord.label) || _aRecord.maybe != aRecord.maybe) {
      System.out.printf("Error: MaybeRecordMembVar() == aRecord\n");
      System.exit(1);
    }

    var _aTupleSeq = db.maybeTupleSeqMembVar();
    if (!arrayEquals(_aTupleSeq, aTupleSeq)) {
      System.out.printf("Error: MaybeTupleSeqMembVar() != aTupleSeq\n");
      System.out.printf(
        "db.maybeTupleSeqMembVar().length == %s, aTupleSeq.length == %s\n",
        _aTupleSeq.length, aTupleSeq.length
      );
      for (int i=0 ; i < _aTupleSeq.length ; i++)
        if (_aTupleSeq[i] != aTupleSeq[i]) {
          System.out.printf("Error (%s): %s != %s\n", i, _aTupleSeq[i], aTupleSeq[i]);
        }
      System.exit(1);
    }

    var _aMap = db.maybeMapMembVar();
    if (!_aMap.equals(aMap)) {
      System.out.println();
      System.out.println("Error: db.maybeMapMembVar() != aMap");
      System.out.printf(
        "db.maybeMapMembVar().length == %s, aMap.size() == %s\n",
        _aMap.size(), aMap.size()
      );
      for (int i=0 ; i < _aMap.size() ; i++)
        if (_aMap.get(i) != aMap.get(i)) {
          System.out.printf("Error (%s): %s != %s\n", i, _aMap.get(i), aMap.get(i));
        }
      System.exit(1);
    }
  }

  ////////////////////////////////////////////////////////////////////////////

  static EmployeeId_LocalDateTime_String newEmployeeId_LocalDateTime_String(long id, LocalDateTime time, String str) {
    var obj = new EmployeeId_LocalDateTime_String();
    obj.item1 = id;
    obj.item2 = time;
    obj.item3 = str;
    return obj;
  }

  ////////////////////////////////////////////////////////////////////////////

  static boolean arrayEquals(byte[] a1, byte[] a2) {
    int len = a1.length;
    if (a2.length != len)
      return false;
    for (int i=0 ; i < len ; i++)
      if (a1[i] != a2[i])
        return false;
    return true;
  }

  static boolean arrayEquals(int[] a1, int[] a2) {
    int len = a1.length;
    if (a2.length != len)
      return false;
    for (int i=0 ; i < len ; i++)
      if (a1[i] != a2[i])
        return false;
    return true;
  }

  static boolean arrayEquals(long[] a1, long[] a2) {
    int len = a1.length;
    if (a2.length != len)
      return false;
    for (int i=0 ; i < len ; i++)
      if (a1[i] != a2[i])
        return false;
    return true;
  }


  static boolean arrayEquals(EmployeeId_LocalDateTime_String[] a1,EmployeeId_LocalDateTime_String[] a2) {
    int len = a1.length;
    if (a2.length != len)
      return false;
    for (int i=0 ; i < len ; i++) {
      var e1 = a1[i];
      var e2 = a2[i];

      if (e1.item1 != e2.item1)
        return false;

      if (!e1.item2.equals(e2.item2))
        return false;

      if (!e1.item3.equals(e2.item3))
        return false;
    }
    return true;
  }
}
