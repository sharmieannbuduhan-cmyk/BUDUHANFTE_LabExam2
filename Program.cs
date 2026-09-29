using System;

class Program
{
    static string[] names = new string[3];
    static int[,] scores = new int[3, 3];
    static int[] totals = new int[3];
    static bool recorded = false;

    static void Main()
    {
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("     COMMUNITY FUN RUN SYSTEM");
            Console.WriteLine("=================================");
            Console.WriteLine("[1] RECORD SCORES");
            Console.WriteLine("[2] SHOW PARTICIPANT SCORES");
            Console.WriteLine("[3] SHOW RANKING");
            Console.WriteLine("[4] EXIT");
            Console.WriteLine();
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RecordScores();
                    break;

                case 2:
                    ShowScores();
                    break;

                case 3:
                    ShowRanking();
                    break;

                case 4:
                    Console.WriteLine("Program ended.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (choice != 4)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        } while (choice != 4);
    }

    static void RecordScores()
    {
        Console.Clear();
        Console.WriteLine("RECORD SCORES");
        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter name of participant " + (i + 1) + ": ");
            names[i] = Console.ReadLine();

            totals[i] = 0;

            for (int j = 0; j < 3; j++)
            {
                Console.Write("Enter score for Round " + (j + 1) + ": ");
                scores[i, j] = int.Parse(Console.ReadLine());
                totals[i] += scores[i, j];
            }

            Console.WriteLine();
        }

        recorded = true;
        Console.WriteLine("Scores recorded successfully.");
    }

    static void ShowScores()
    {
        Console.Clear();

        if (!recorded)
        {
            Console.WriteLine("No scores recorded yet.");
            return;
        }

        Console.WriteLine("PARTICIPANT SCORES");
        Console.WriteLine();

        Console.WriteLine("PARTICIPANT\tR1\tR2\tR3\tTOTAL");

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(
                names[i] + "\t\t" +
                scores[i, 0] + "\t" +
                scores[i, 1] + "\t" +
                scores[i, 2] + "\t" +
                totals[i]);
        }
    }

    static void ShowRanking()
    {
        Console.Clear();

        if (!recorded)
        {
            Console.WriteLine("No scores recorded yet.");
            return;
        }

        string[] rankNames = new string[3];
        int[,] rankScores = new int[3, 3];
        int[] rankTotals = new int[3];

        for (int i = 0; i < 3; i++)
        {
            rankNames[i] = names[i];
            rankTotals[i] = totals[i];

            for (int j = 0; j < 3; j++)
            {
                rankScores[i, j] = scores[i, j];
            }
        }

        for (int pass = 1; pass <= 2; pass++)
        {
            for (int i = 0; i < 3 - pass; i++)
            {
                if (rankTotals[i] < rankTotals[i + 1])
                {
                    int tempTotal = rankTotals[i];
                    rankTotals[i] = rankTotals[i + 1];
                    rankTotals[i + 1] = tempTotal;

                    string tempName = rankNames[i];
                    rankNames[i] = rankNames[i + 1];
                    rankNames[i + 1] = tempName;

                    for (int j = 0; j < 3; j++)
                    {
                        int tempScore = rankScores[i, j];
                        rankScores[i, j] = rankScores[i + 1, j];
                        rankScores[i + 1, j] = tempScore;
                    }
                }
            }

            Console.Write("Pass " + pass + ": ");

            for (int i = 0; i < 3; i++)
            {
                Console.Write(rankTotals[i] + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("FUN RUN RANKING");
        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine((i + 1) + ". " + rankNames[i] + " - " + rankTotals[i]);
        }
    }
}
