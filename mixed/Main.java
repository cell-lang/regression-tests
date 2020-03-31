import java.io.IOException;


public class Main {
  public static void main(String[] args) throws IOException {
    if (args.length != 1) {
      System.out.println("Usage: <executable> <directory>");
      return;
    }

    // RelAutoA

    RelAutoA_Tests.run(args[0] + "/state-A0.txt", true);

    System.out.print("\n\n");
    for (int i=0 ; i < 80 ; i++)
      System.out.print("#");
    System.out.println("\n\n");

    RelAutoA_Tests.run(args[0] + "/msg-A0.txt", false);
    System.out.println("");
    System.out.println("");

    // RelAutoB
    RelAutoB_Tests.run();

    // ReacAutoA
    ReactAutoA_Tests.run();
  }
}