while (true)
{
    Console.WriteLine("Zvolte operaci: ");
    Console.WriteLine("Pro sčítání stiskněte 1 ");
    Console.WriteLine("Pro odčítání stiskněte 2 ");
    Console.WriteLine("Pro násobení stiskněte 3 ");
    Console.WriteLine("Pro dělení stiskněte 4 ");

    double cislo1;
    double cislo2;
    double menuend;

    int menu = int.Parse(Console.ReadLine());

    if (menu == 1)
    {
        Console.WriteLine("Napište první číslo: ");
        double.TryParse(Console.ReadLine(), out cislo1);
        Console.WriteLine("Napište druhé číslo: ");
        double.TryParse(Console.ReadLine(), out cislo2);

        Console.WriteLine("Výsledek je: {0} + {1} = {2}", cislo1, cislo2, cislo1 + cislo2);

        Console.WriteLine("Pro pokračování stiskněte 1, pro ukončení stistkněte 2");
        double.TryParse(Console.ReadLine(), out menuend);
        if (menuend != 1)
        {
            break;
        }


    }

    if (menu == 2)
    {
        Console.WriteLine("Napište první číslo: ");
        double.TryParse(Console.ReadLine(), out cislo1);
        Console.WriteLine("Napište druhé číslo: ");
        double.TryParse(Console.ReadLine(), out cislo2);

        Console.WriteLine("Výsledek je: {0} - {1} = {2}", cislo1, cislo2, cislo1 - cislo2);
        Console.WriteLine("Pro pokračování stiskněte 1, pro ukončení stistkněte 2");
        double.TryParse(Console.ReadLine(), out menuend);
        if (menuend != 1)
        {
            break;
        }
    }

    if (menu == 3)
    {
        Console.WriteLine("Napište první číslo: ");
        double.TryParse(Console.ReadLine(), out cislo1);
        Console.WriteLine("Napište druhé číslo: ");
        double.TryParse(Console.ReadLine(), out cislo2);

        Console.WriteLine("Výsledek je: {0} * {1} = {2}", cislo1, cislo2, cislo1 * cislo2);
        Console.WriteLine("Pro pokračování stiskněte 1, pro ukončení stistkněte 2");
        double.TryParse(Console.ReadLine(), out menuend);
        if (menuend != 1)
        {
            break;
        }
    }

    if (menu == 4)
    {
        Console.WriteLine("Napište první číslo: ");
        double.TryParse(Console.ReadLine(), out cislo1);
        Console.WriteLine("Napište druhé číslo: ");
        double.TryParse(Console.ReadLine(), out cislo2);

        Console.WriteLine("Výsledek je: {0} / {1} = {2}", cislo1, cislo2, cislo1 / cislo2);
        Console.WriteLine("Pro pokračování stiskněte 1, pro ukončení stistkněte 2");
        double.TryParse(Console.ReadLine(), out menuend);
        if (menuend != 1)
        {
            break;
        }
    }
}


