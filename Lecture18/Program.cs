using Lecture18;

public class Program

{

    private static Random random = new Random();

    public static void Main()

    {

        Character c3PO = new NPC(GetRandomName(), 15, 6, 4, random);

        Character r2D2 = new NPC(GetRandomName(), 10, 7, 5, random);

        Character luke = new Player(GetRandomName(), 20, 4, 4, Console.In, Console.Out);

        Game game = new Game(c3PO, r2D2, new Die(random, 6));

        game.Run(Console.Out);

        Console.WriteLine();

        Game game2 = new Game(c3PO, luke, new Die(random, 6));

        game2.Run(Console.Out);

        Console.WriteLine();

    }

    private static string GetRandomName()

    {

        // Seznam možných jmen

        string[] names = new string[]

        {

            "Alex", "Maria", "Ethan", "Olivia", "Noah", "Ava", "Liam", "Sophia", "Mason", "Isabella", "Jacob", "Mia", "William", "Amelia", "James", "Charlotte", "Benjamin", "Harper", "Lucas", "Emily", "Henry", "Madison", "Michael", "Scarlett", "Daniel", "Victoria", "Jack", "Aiden", "Matthew", "Grace", "Samuel", "Chloe", "David", "Lily", "Joseph", "Ruby", "Carter", "Ella", "Owen", "Abigail", "Wyatt", "Zoe", "John", "Layla", "Luke", "Natalie", "Jayden", "Aurora", "Dylan", "Savannah", "Grayson", "Audrey", "Levi", "Brooklyn", "Isaac", "Lucy", "Gabriel", "Emma", "Julian", "Bella", "Mateo", "Alexis", "Anthony", "Ellie", "Jaxon", "Hannah", "Lincoln", "Addison", "Joshua", "Evelyn", "Christopher", "Harper", "Andrew", "Brielle", "Theodore", "Hailey", "Caleb", "Leah", "Ryan", "Nora", "Asher", "Skylar", "Nathan", "Sarah", "Thomas", "Aria", "Leo", "Penelope", "Isaiah", "Ariana", "Charles", "Elena", "Josiah", "Gabriella", "Hudson", "Paisley", "Christian", "Audrey", "Hunter", "Zoe", "Connor", "Stella", "Eli", "Maya", "Ezra", "Camila", "Aaron", "Addison", "Landon", "Avery", "Adrian", "Kinsley", "Jonathan", "Piper", "Nolan", "Arianna", "Jeremiah", "Maria", "Easton", "Angelina", "Elias", "Raelynn", "Colton", "Ivy", "Cameron", "Kennedy", "Carson", "Madelyn", "Robert", "Brianna", "Angel", "Kylie", "Nicholas", "Mackenzie", "Dominic", "Kaitlyn", "Jace", "Ashlyn", "Greyson", "Cora", "Parker", "Adriana", "Mateo", "Reagan", "Jason", "Alison", "Santiago", "Mariana", "Axel", "Molly"

        };

        // Náhodný výběr jména z pole

        return names[random.Next(names.Length)];

    }

}