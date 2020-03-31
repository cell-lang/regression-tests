using System;
using System.Linq;

using Cell.Automata;


class RelAutoB_Tests {
  public static void Run() {
    RunBadArgsTests();
    RunConvTests(true);
    RunConvTests(false);
  }

  private static void RunBadArgsTests() {
    RelAutoB db = new RelAutoB();

    var zero = db.MyPolyMeth("\"Hi!\"", "0.0");
    var one  = db.MyPolyMeth("\"Hi!\"", "0");
    if (zero != 0 | one != 1) {
      Console.WriteLine("ERROR (1): my_poly_meth(), zero = {0}, one = {1}", zero, one);
      Environment.Exit(1);
    }
    // var two  = db.MyPolyMeth("red", "just(true)");

    try {
      db.MyPolyMeth("\"Hi!\"", "true");
      Console.WriteLine("ERROR (2): my_poly_meth(\"Hi!\", true)");
      Environment.Exit(1);
    }
    catch (Exception) {
      // This was expected
    }

    try {
      db.DoOptionalMaybe("just(\"Hello!\")", null);
      Console.WriteLine("ERROR (3): DoOptionalMaybe(just(\"Hello!\"), null)");
      Environment.Exit(1);
    }
    catch (Exception) {
      // This was expected
    }


    db.DoOptionalMaybe("just(2.71828)", "just(\"Hi!\")");
    double? maybeFloatValue = db.MaybeFloatMembVar();
    string maybeStringValue = db.MaybeStringMembVar();
    if (maybeFloatValue != 2.71828) {
      Console.WriteLine(
        "MaybeFloatMembVar() ERROR (1): {0}, {1}",
        maybeFloatValue, maybeFloatValue - 2.1818
      );
      Environment.Exit(1);
    }
    if (maybeStringValue != "Hi!") {
      Console.WriteLine("MaybeStringMembVar() ERROR (1): {0}", maybeStringValue);
      Environment.Exit(1);
    }

    db.DoOptionalMaybe(null, null);
    maybeFloatValue = db.MaybeFloatMembVar();
    maybeStringValue = db.MaybeStringMembVar();
    if (maybeFloatValue != 2.71828) {
      Console.WriteLine(
        "MaybeFloatMembVar() ERROR (2): {0}, {1}",
        maybeFloatValue, maybeFloatValue - 2.1818
      );
      Environment.Exit(1);
    }
    if (maybeStringValue != "Hi!") {
      Console.WriteLine("MaybeStringMembVar() ERROR (2): {0}", maybeStringValue);
      Environment.Exit(1);
    }

    db.DoOptionalMaybe("nothing", "just(\"Hi!\")");
    maybeFloatValue = db.MaybeFloatMembVar();
    maybeStringValue = db.MaybeStringMembVar();
    if (maybeFloatValue != null) {
      Console.WriteLine("MaybeFloatMembVar() ERROR (3): {0}", maybeFloatValue);
      Environment.Exit(1);
    }
    if (maybeStringValue != "Hi!") {
      Console.WriteLine("MaybeStringMembVar() ERROR (3): {0}", maybeStringValue);
      Environment.Exit(1);
    }

    db.DoOptionalMaybe("just(2.71828)", "nothing");
    maybeFloatValue = db.MaybeFloatMembVar();
    maybeStringValue = db.MaybeStringMembVar();
    if (maybeFloatValue != 2.71828) {
      Console.WriteLine(
        "MaybeFloatMembVar() ERROR (4): {0}, {1}",
        maybeFloatValue, maybeFloatValue - 2.1818
      );
      Environment.Exit(1);
    }
    if (maybeStringValue != null) {
      Console.WriteLine("MaybeStringMembVar() ERROR (4): {0}", maybeStringValue);
      Environment.Exit(1);
    }

    db.DoOptionalMaybe("nothing", "nothing");
    maybeFloatValue = db.MaybeFloatMembVar();
    maybeStringValue = db.MaybeStringMembVar();
    if (maybeFloatValue != null) {
      Console.WriteLine("MaybeFloatMembVar() ERROR (5): {0}", maybeFloatValue);
      Environment.Exit(1);
    }
    if (maybeStringValue != null) {
      Console.WriteLine("MaybeStringMembVar() ERROR (5): {0}", maybeStringValue);
      Environment.Exit(1);
    }

    db.DoOptionalMaybe(null, "just(\"Hi!\")");
    maybeFloatValue = db.MaybeFloatMembVar();
    maybeStringValue = db.MaybeStringMembVar();
    if (maybeFloatValue != null) {
      Console.WriteLine("MaybeFloatMembVar() ERROR (6): {0}", maybeFloatValue);
      Environment.Exit(1);
    }
    if (maybeStringValue != "Hi!") {
      Console.WriteLine("MaybeStringMembVar() ERROR (6): {0}", maybeStringValue);
      Environment.Exit(1);
    }

    db.DoOptionalMaybe("just(2.71828)", null);
    maybeFloatValue = db.MaybeFloatMembVar();
    maybeStringValue = db.MaybeStringMembVar();
    if (maybeFloatValue != 2.71828) {
      Console.WriteLine(
        "MaybeFloatMembVar() ERROR (7): {0}, {1}",
        maybeFloatValue, maybeFloatValue - 2.1818
      );
      Environment.Exit(1);
    }
    if (maybeStringValue != "Hi!") {
      Console.WriteLine("MaybeStringMembVar() ERROR (7): {0}", maybeStringValue);
      Environment.Exit(1);
    }
  }

  public static void RunConvTests(bool doMaybe) {
    RelAutoB db = new RelAutoB();

    var aBool         = false;
    var aInt          = 42;
    var aFloat        = 3.14159;
    var aDate         = new DateTime(2020, 4, 9);
    var aTime         = new DateTime(2020, 4, 11, 3, 15, 45);
    var aTuple        = (1000000007, "Hello world!", new DateTime(2018, 10, 19));
    var aRecord       = ( time: new DateTime(2017, 11, 24, 17, 33, 29),
                          label: "How long?",
                          maybe: (long?) null
                        );
    var aString       = "Imagine there's no heaven";
    var aEmployeeId   = 8;
    var aCustomerId   = "ANSDY";
    var aTaggedMaybe  = "id(27955, 14)";
    var aMap          = new (long, long)[] {
                          (6, 98052),
                          (1, 19713),
                          (9, 3049),
                          (5, 8837)
                        };
    var aByteSeq      = new byte[] {72, 101, 108, 108, 111, 32, 119, 111, 114, 108, 100, 33};
    var aTupleSeq     = new (long, DateTime, string)[] {
                          (47340, new DateTime(2020, 04, 09, 17, 56, 57), "\"dump-syn-prg.txt\""),
                          (  294, new DateTime(2020, 03, 30, 15, 17, 50), "\"empty-db.txt\""),
                          (  149, new DateTime(2020, 04, 08, 11, 58, 17), "\"genguids.py\""),
                          ( 6526, new DateTime(2020, 02, 21, 11, 03, 26), "\"german.txt\""),
                          (  306, new DateTime(2020, 03, 30, 18, 02, 42), "\"input-db.txt\""),
                          ( 7382, new DateTime(2019, 07, 28, 14, 32, 57), "\"java-test.java\""),
                          ( 1522, new DateTime(2019, 11, 18, 10, 17, 31), "\"la.py\""),
                          (  249, new DateTime(2018, 08, 06, 16, 39, 28), "\"main.cpp\"")
                        };
    var anIntSeq      = new int[] {65535, 16777215, 2147483647, -32768, -2147483648};

    if (doMaybe) {
      db.DoMaybe(
        maybeBool:          aBool,          // bool?
        maybeInt:           aInt,           // long?
        maybeFloat:         aFloat,         // double?
        maybeDate:          aDate,          // DateTime?
        maybeTime:          aTime,          // DateTime?
        maybeTuple:         aTuple,         // (long, string, DateTime)?
        maybeRecord:        aRecord,        // (DateTime time, string label, long? maybe)?
        maybeString:        aString,        // string
        maybeEmployeeId:    aEmployeeId,    // long?
        maybeCustomerId:    aCustomerId,    // string
        maybeTaggedMaybe:   aTaggedMaybe,   // string
        maybeMap:           aMap,           // (long, long)[]
        maybeByteSeq:       aByteSeq,       // byte[]
        maybeTupleSeq:      aTupleSeq,      // (long, DateTime, string)[]
        maybeInt32Seq:      anIntSeq        // int[]
      );
    }
    else {
      db.DoOptional(
        _bool:          aBool,          // bool?
        _int:           aInt,           // long?
        _float:         aFloat,         // double?
        date:           aDate,          // DateTime?
        time:           aTime,          // DateTime?
        tuple:          aTuple,         // (long, string, DateTime)?
        record:         aRecord,        // (DateTime time, string label, long? maybe)?
        _string:        aString,        // string
        employeeId:     aEmployeeId,    // long?
        customerId:     aCustomerId,    // string
        taggedMaybe:    aTaggedMaybe,   // string
        map:            aMap,           // (long, long)[]
        byteSeq:        aByteSeq,       // byte[]
        tupleSeq:       aTupleSeq,      // (long, DateTime, string)[]
        int32Seq:       anIntSeq        // int[]
      );
    }

    if (db.MaybeIntMembVar() != aInt) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeIntMembVar(), aInt);
      Environment.Exit(1);
    }

    if (db.MaybeBoolMembVar() != aBool) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeBoolMembVar(), aBool);
      Environment.Exit(1);
    }

    if (db.MaybeFloatMembVar() != aFloat) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeFloatMembVar(), aFloat);
      Environment.Exit(1);
    }

    if (db.MaybeStringMembVar() != aString) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeStringMembVar(), aString);
      Environment.Exit(1);
    }

    if (db.MaybeDateMembVar() != aDate) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeDateMembVar(), aDate);
      Environment.Exit(1);
    }

    if (db.MaybeTimeMembVar() != aTime) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeTimeMembVar(), aTime);
      Environment.Exit(1);
    }

    if (db.MaybeEmployeeIdMembVar() != aEmployeeId) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeEmployeeIdMembVar(), aEmployeeId);
      Environment.Exit(1);
    }

    if (db.MaybeCustomerIdMembVar() != aCustomerId) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeCustomerIdMembVar(), aCustomerId);
      Environment.Exit(1);
    }

    if (db.MaybeTupleMembVar() != aTuple) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeTupleMembVar(), aTuple);
      Environment.Exit(1);
    }

    if (db.MaybeTaggedMaybeMembVar() != aTaggedMaybe) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeTaggedMaybeMembVar(), aTaggedMaybe);
      Environment.Exit(1);
    }

    if (!ArrayEquals(db.MaybeByteSeqMembVar(), aByteSeq)) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeByteSeqMembVar(), aByteSeq);
      Environment.Exit(1);
    }

    if (!ArrayEquals(db.MaybeInt32SeqMembVar(), anIntSeq)) {
      Console.WriteLine("Error: {0} != {1}", db.MaybeInt32SeqMembVar(), anIntSeq);
      Environment.Exit(1);
    }

    // (DateTime time, string label, long? maybe)? MaybeRecordMembVar();
    if (db.MaybeRecordMembVar().Value != aRecord) {
      Console.WriteLine("Error: MaybeRecordMembVar() == aRecord");
      Environment.Exit(1);
    }


    // (long, DateTime, string)[] MaybeTupleSeqMembVar();
    var _aTupleSeq = db.MaybeTupleSeqMembVar();
    if (!ArrayEquals(_aTupleSeq, aTupleSeq)) {
      Console.WriteLine("Error: MaybeTupleSeqMembVar() != aTupleSeq");
      Console.WriteLine(
        "db.MaybeTupleSeqMembVar().Length == {0}, aTupleSeq.Length == {1}",
        _aTupleSeq.Length, aTupleSeq.Length
      );
      for (int i=0 ; i < _aTupleSeq.Length ; i++)
        if (_aTupleSeq[i] != aTupleSeq[i]) {
          Console.WriteLine("Error ({0}): {1} != {2}", i, _aTupleSeq[i], aTupleSeq[i]);
        }
      Environment.Exit(1);
    }

    // (long, long)[] MaybeMapMembVar();
    var _aMap = db.MaybeMapMembVar();
    if (!ArrayEquals(Sorted(_aMap), Sorted(aMap))) {
      Console.WriteLine();
      Console.WriteLine("Error: db.MaybeMapMembVar() != aMap");
      Console.WriteLine(
        "db.MaybeMapMembVar().Length == {0}, aMap.Length == {1}",
        _aMap.Length, aMap.Length
      );
      for (int i=0 ; i < _aMap.Length ; i++)
        if (_aMap[i] != aMap[i]) {
          Console.WriteLine("Error ({0}): {1} != {2}", i, _aMap[i], aMap[i]);
        }
      Environment.Exit(1);
    }
  }

  static (long, long)[] Sorted((long, long)[] array) {
    var copy = new (long, long)[array.Length];
    for (int i=0 ; i < array.Length ; i++)
      copy[i] = array[i];
    Array.Sort(copy);
    return copy;
  }

  static bool ArrayEquals(byte[] a1, byte[] a2) {
    int len = a1.Length;
    if (a2.Length != len)
      return false;
    for (int i=0 ; i < len ; i++)
      if (a1[i] != a2[i])
        return false;
    return true;
  }

  static bool ArrayEquals(int[] a1, int[] a2) {
    int len = a1.Length;
    if (a2.Length != len)
      return false;
    for (int i=0 ; i < len ; i++)
      if (a1[i] != a2[i])
        return false;
    return true;
  }

  static bool ArrayEquals(long[] a1, long[] a2) {
    int len = a1.Length;
    if (a2.Length != len)
      return false;
    for (int i=0 ; i < len ; i++)
      if (a1[i] != a2[i])
        return false;
    return true;
  }

  static bool ArrayEquals((long, long)[] a1, (long, long)[] a2) {
    int len = a1.Length;
    if (a2.Length != len)
      return false;
    for (int i=0 ; i < len ; i++)
      if (a1[i] != a2[i])
        return false;
    return true;
  }

  static bool ArrayEquals((long, DateTime, string)[] a1, (long, DateTime, string)[] a2) {
    int len = a1.Length;
    if (a2.Length != len)
      return false;
    for (int i=0 ; i < len ; i++)
      if (a1[i] != a2[i])
        return false;
    return true;
  }
}


