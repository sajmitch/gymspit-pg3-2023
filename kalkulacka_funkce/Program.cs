    Console.WriteLine("Zvolte operaci: ");
    Console.WriteLine("Pro sčítání stiskněte 1 ");
    Console.WriteLine("Pro odčítání stiskněte 2 ");
    Console.WriteLine("Pro násobení stiskněte 3 ");
    Console.WriteLine("Pro dělení stiskněte 4 ");
    Console.WriteLine("Pro umocňování stiskněte 5 ");
    Console.WriteLine("Pro odmocňování stiskněte 6 ");

switch (Console.ReadKey().KeyChar)
{
    case '1':
        Scitani()
            ; break;
    case '2':
        Odcitani()
            ; break;
    case '3':
        Nasobeni()
            ; break;
    case '4':
        Deleni()
            ; break;
    case '5':
        Umocnovani()
            ; break;
    case '6':
        Odmocnovani()
            ; break;

}

    static void Scitani()
    {
        bool success = false;
        double a;
        double b;
        Console.WriteLine("Napište první číslo");
        do
        {
            success = double.TryParse(Console.ReadLine(), out a);
            if (!success)
            {
                Console.WriteLine("Neplatný vstup");
            }
        } while (!success);
        Console.WriteLine("Zadejte druhé číslo");
        do
        {
            success = double.TryParse(Console.ReadLine(), out b);
            if (!success)
            {
                Console.WriteLine("Neplatný vstup");
            }

        } while (!success);
        Console.WriteLine(a + b);
    }

static void Odcitani()
{
    bool success = false;
    double a;
    double b;
    Console.WriteLine("Napište první číslo");
    do
    {
        success = double.TryParse(Console.ReadLine(), out a);
        if (!success)
        {
            Console.WriteLine("Neplatný vstup");
        }
    } while (!success);
    Console.WriteLine("Zadejte druhé číslo");
    do
    {
        success = double.TryParse(Console.ReadLine(), out b);
        if (!success)
        {
            Console.WriteLine("Neplatný vstup");
        }

    } while (!success);
    Console.WriteLine(a - b);
}

static void Nasobeni()
{
    bool success = false;
    double a;
    double b;
    Console.WriteLine("Napište první číslo");
    do
    {
        success = double.TryParse(Console.ReadLine(), out a);
        if (!success)
        {
            Console.WriteLine("Neplatný vstup");
        }
    } while (!success);
    Console.WriteLine("Zadejte druhé číslo");
    do
    {
        success = double.TryParse(Console.ReadLine(), out b);
        if (!success)
        {
            Console.WriteLine("Neplatný vstup");
        }

    } while (!success);
    Console.WriteLine(a * b);
}

static void Deleni()
{
    bool success = false;
    double a;
    double b;
    Console.WriteLine("Napište první číslo");
    do
    {
        success = double.TryParse(Console.ReadLine(), out a);
        if (!success)
        {
            Console.WriteLine("Neplatný vstup");
        }
    } while (!success);
    Console.WriteLine("Zadejte druhé číslo");
    do
    {
        success = double.TryParse(Console.ReadLine(), out b);
        if (!success)
        {
            Console.WriteLine("Neplatný vstup");
        }

    } while (!success);
    Console.WriteLine(a / b);
}

static void Umocnovani()
{
    bool success = false;
    double a;
    double b;
    Console.WriteLine("Napište první číslo");
    do
    {
        success = double.TryParse(Console.ReadLine(), out a);
        if (!success)
        {
            Console.WriteLine("Neplatný vstup");
        }
    } while (!success);
    Console.WriteLine("Zadejte druhé číslo");
    do
    {
        success = double.TryParse(Console.ReadLine(), out b);
        if (!success)
        {
            Console.WriteLine("Neplatný vstup");
        }

    } while (!success);
    Console.WriteLine(Math.Pow(a, b));
}

static void Odmocnovani()
{
    bool success = false;
    double a;
    double b;
    Console.WriteLine("Napište první číslo");
    do
    {
        success = double.TryParse(Console.ReadLine(), out a);
        if (!success)
        {
            Console.WriteLine("Neplatný vstup");
        }
    } while (!success);
    Console.WriteLine("Zadejte druhé číslo");
    do
    {
        success = double.TryParse(Console.ReadLine(), out b);
        if (!success)
        {
            Console.WriteLine("Neplatný vstup");
        }

    } while (!success);
    Console.WriteLine(Math.Pow(a, 1/b));
}









