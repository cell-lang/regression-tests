using System;
using System.IO;

using Cell.Generated;


public static class MixedLanguageTests {
  public static void Main(string[] args) {
    if (args.Length != 1) {
      Console.WriteLine("Usage: <executable> <directory>");
      return;
    }

    // RelAutoA

    RelAutoA_Tests.Run(args[0] + "/state-A0.txt", true);

    Console.Write("\n\n");
    for (int i=0 ; i < 80 ; i++)
      Console.Write("#");
    Console.WriteLine("\n\n");

    RelAutoA_Tests.Run(args[0] + "/msg-A0.txt", false);
    Console.WriteLine("");
    Console.WriteLine("");

    // RelAutoB
    RelAutoB_Tests.Run();

    // ReacAutoA
    ReactAutoA_Tests.Run();
  }
}