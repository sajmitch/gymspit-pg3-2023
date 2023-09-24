Console.Write("Zadejte kladné číslo N: ");
int N = int.Parse(Console.ReadLine());

for (int i = 1; i <= N; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("Fizz Buzz");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}