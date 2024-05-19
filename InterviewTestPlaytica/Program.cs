using System;
using System.Collections.Generic;

public class Game
{
    // Evenimente pentru adăugarea și eliminarea șobolanilor
    public event  Action RatAdded;
    public event Action RatRemoved;

    // Metodă pentru a declanșa evenimentul RatAdded
    public void OnRatAdded()
    {
        RatAdded?.Invoke();
    }

    // Metodă pentru a declanșa evenimentul RatRemoved
    public void OnRatRemoved()
    {
        RatRemoved?.Invoke();
    }
}

public class Rat : IDisposable
{
    readonly Game game;
    public int Attack = 1;
    private static int ratCount = 0;

    public Rat(Game game)
    {
        this.game = game;
        game.RatAdded += HandleRatAdded;
        game.RatRemoved += HandleRatRemoved;

        ratCount++;
        game.OnRatAdded();  // Anunțăm că un șobolan a fost adăugat
        //game.RatAdded.Invoke();
    }

    private void HandleRatAdded()
    {
        Attack++;
    }

    private void HandleRatRemoved()
    {
        Attack--;
    }

    public void Dispose()
    {
        game.RatAdded -= HandleRatAdded;
        game.RatRemoved -= HandleRatRemoved;

        ratCount--;
        game.OnRatRemoved();  // Anunțăm că un șobolan a fost eliminat
    }
}

public class Program
{
    public static void Main()
    {
        var game = new Game();

        var rat1 = new Rat(game);
        Console.WriteLine($"Rat1 Attack: {rat1.Attack}");  // Ar trebui să fie 1
        Console.WriteLine("---");

        var rat2 = new Rat(game);
        Console.WriteLine($"Rat1 Attack: {rat1.Attack}");  // Ar trebui să fie 2
        Console.WriteLine($"Rat2 Attack: {rat2.Attack}");  // Ar trebui să fie 2
        Console.WriteLine("---");

        var rat3 = new Rat(game);
        Console.WriteLine($"Rat1 Attack: {rat1.Attack}");  // Ar trebui să fie 3
        Console.WriteLine($"Rat2 Attack: {rat2.Attack}");  // Ar trebui să fie 3
        Console.WriteLine($"Rat3 Attack: {rat3.Attack}");  // Ar trebui să fie 3
        Console.WriteLine("---");

        rat3.Dispose();
        Console.WriteLine($"Rat1 Attack: {rat1.Attack}");  // Ar trebui să fie 2
        Console.WriteLine($"Rat2 Attack: {rat2.Attack}");  // Ar trebui să fie 2
        Console.WriteLine("---");

        Console.ReadKey();
    }
}
