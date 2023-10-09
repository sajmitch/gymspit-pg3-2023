int delka;
Console.WriteLine("Zadej délku pole");
int.TryParse(Console.ReadLine(), out delka);
Console.WriteLine("Délka pole: {0}", delka);

bool[] a = new bool[delka];

for (int i = 0; a.Length > i; i++)
{
    a[i] = true;
}

for (int i = 2; i < a.Length; i++)
{
    if (a[i])
    {
        for (int x = i * 2; x < a.Length; x += i)
        {
            a[x] = false;
        }
    }
       

}

for (int i = 0; a.Length > i; i++)
{
    if (a[i])
    {
        Console.WriteLine(i);
    }
}