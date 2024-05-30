using System;
using System.Collections.Generic;

public class Game
{
    public Action<Rat> RatCreated;
    public Action<Rat> RatDestroyed;
}

public class Rat : IDisposable
{
    readonly Game _game;
    public int Attack = 1;
    private string Name { get; }

    public Rat(Game game, string name)
    {
        _game = game;
        Name = name;

        // Subscribe to the event and increment the attack for the current rat
        _game.RatCreated += (r) =>
        {
            if (r != this) // Avoid incrementing the attack of the new rat twice
            {
                Attack++;
                r.Attack++;
            };
        };

        // Unsubscribe from the event
        _game.RatDestroyed += (r) =>
        {
            if (r != this)
            {
                Attack--;
               // r.Attack--;
            }
        };


        // Invoke the event, passing the current rat
        _game.RatCreated?.Invoke(this);
    }

    public void Dispose()
    {
        _game.RatDestroyed?.Invoke(this);
    }
}

public class Program
{
    public static void Main()
    {
        var game = new Game();

        var rat1 = new Rat(game, "Rat1");
        Console.WriteLine($"Rat1 Attack: {rat1.Attack}");  // Should be 1
        Console.WriteLine("---");

        var rat2 = new Rat(game, "Rat2");
        Console.WriteLine($"Rat1 Attack: {rat1.Attack}");  // Should be 2
        Console.WriteLine($"Rat2 Attack: {rat2.Attack}");  // Should be 2
        Console.WriteLine("---");

        var rat3 = new Rat(game, "Rat3");
        Console.WriteLine($"Rat1 Attack: {rat1.Attack}");  // Should be 3
        Console.WriteLine($"Rat2 Attack: {rat2.Attack}");  // Should be 3
        Console.WriteLine($"Rat3 Attack: {rat3.Attack}");  // Should be 3
        Console.WriteLine("---");

        var rat4 = new Rat(game, "Rat4");
        Console.WriteLine($"Rat1 Attack: {rat1.Attack}");  // Should be 4
        Console.WriteLine($"Rat2 Attack: {rat2.Attack}");  // Should be 4
        Console.WriteLine($"Rat3 Attack: {rat3.Attack}");  // Should be 4
        Console.WriteLine($"Rat4 Attack: {rat4.Attack}");  // Should be 4
        Console.WriteLine("---");

        rat3.Dispose();
        Console.WriteLine($"Rat1 Attack: {rat1.Attack}");  // Should still be 3, since we don't decrement here
        Console.WriteLine($"Rat2 Attack: {rat2.Attack}");  // Should still be 3, same reason
        Console.WriteLine($"Rat4 Attack: {rat4.Attack}");  // Should still be 3, same reason
        Console.WriteLine("---");

        Console.ReadKey();
    }
}
