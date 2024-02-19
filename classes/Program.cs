using System;

class Struna
{
    private double frekvence;
    private double Freq;
    public Struna(double pocatecniFrekvence)
    {
        frekvence = pocatecniFrekvence;
    }
    public void ZahrajNaPrac()
    {
        Console.WriteLine("Na jakém pražci chcete zahrát?");
        double prazec = double.Parse(Console.ReadLine());

        Freq = frekvence * Math.Pow(2, prazec / 12.0);

        Console.WriteLine($"Struna hraje na pražci s frekvencí {Freq} Hz.");
    }
    public void Naladit(double novaFrekvence)
    {
        frekvence = novaFrekvence;
        Console.WriteLine($"Struna byla naladěna na {frekvence} Hz.");
    }
}
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Naladění první struny:");
            double frekvenceStruna1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Naladění druhé struny:");
            double frekvenceStruna2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Naladění třetí struny:");
            double frekvenceStruna3 = double.Parse(Console.ReadLine());
            Struna struna1 = new Struna(frekvenceStruna1);
            Struna struna2 = new Struna(frekvenceStruna2);
            Struna struna3 = new Struna(frekvenceStruna3);
            Console.WriteLine("\nZahraní na první strunu:");
            struna1.ZahrajNaPrac();
            Console.WriteLine("\nZahraní na druhou strunu:");
            struna2.ZahrajNaPrac();
            Console.WriteLine("\nZahraní na třetí strunu:");
            struna3.ZahrajNaPrac();
            Console.WriteLine("\nNaladění první struny na novou hodnotu:");


            double novaFrekvenceStruna1 = double.Parse(Console.ReadLine());
            struna1.Naladit(novaFrekvenceStruna1);
            Console.WriteLine("\nZahraní na první strunu po změně frekvence:");
            struna1.ZahrajNaPrac();

            double novaFrekvenceStruna2 = double.Parse(Console.ReadLine());
            struna1.Naladit(novaFrekvenceStruna1);
            Console.WriteLine("\nZahraní na druhou strunu po změně frekvence:");
            struna1.ZahrajNaPrac();

            double novaFrekvenceStruna3 = double.Parse(Console.ReadLine());
            struna1.Naladit(novaFrekvenceStruna1);
            Console.WriteLine("\nZahraní na třetí strunu po změně frekvence:");
            struna1.ZahrajNaPrac();
        }
    }
}