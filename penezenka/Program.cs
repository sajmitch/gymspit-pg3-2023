class Wallet
{
    const int MaxListSize = 100;
    static List<int> amounts = new List<int>();
    static List<string> descriptions = new List<string>();
    static List<string> categories = new List<string>();
    static void Main()
    {
        using (StreamReader wallet = new StreamReader(@"U:\Documents\penezenka.txt"))
        {
            string line = "x";  
            while (line != null)
            {
                line = wallet.ReadLine();
                if (line != null)
                {
                    string[] split = line.Split(',');
                    amounts.Add(int.Parse(split[0]));
                    descriptions.Add(split[1]);
                    categories.Add(split[2]);
                }
                else { break; }
                              
            }
wallet.Dispose();
        }

   
        while (true)
        {
            Console.WriteLine("Peněženka - Možnosti:");
            Console.WriteLine("1. Přidat záznam");
            Console.WriteLine("2. Upravit záznam");
            Console.WriteLine("3. Smazat záznam");
            Console.WriteLine("4. Výpis všech záznamů");
            Console.WriteLine("5. Výpis s filtrem");
            Console.WriteLine("6. Statistiky");
            Console.WriteLine("7. Kategorie");
            Console.WriteLine("8. Seřazení");
            Console.WriteLine("9. Konec programu");
            Console.Write("Vyberte akci (1-9): ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 9)
            {
                Console.WriteLine("Neplatná volba. Zadejte prosím číslo od 1 do 9.");
                continue;
            }
            switch (choice)
            {
                case 1:
                    AddTransaction();
                    break;
                case 2:
                    EditTransaction();
                    break;
                case 3:
                    DeleteTransaction();
                    break;
                case 4:
                    DisplayTransactions();
                    break;
                case 5:
                    FilterTransactions();
                    break;
                case 6:
                    ShowStatistics();
                    break;
                case 7:
                    ShowCategories();
                    break;
                case 8:
                    SortTransactions();
                    break;
                case 9:
                    using (StreamWriter xx = new StreamWriter(@"U:\Documents\penezenka.txt"))
                    {
                        for (int i = 0; i < amounts.Count; i++)
                        {
                            xx.WriteLine($"{amounts[i]};{descriptions[i]};{categories[i]}");
                        }
                        xx.Dispose();
                    }
                    Environment.Exit(0);
                    
                    break;
                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }
        }
    }
    static void AddTransaction()
    {
        if (amounts.Count >= MaxListSize)
        {
            Console.WriteLine("Seznam je plný. Nelze přidat další záznam.");
            return;
        }
        Console.Write("Zadejte částku transakce: ");
        int amount;
        while (!int.TryParse(Console.ReadLine(), out amount))
        {
            Console.WriteLine("Neplatná částka. Zadejte prosím číslo.");
            Console.Write("Zadejte částku transakce: ");
        }
        Console.Write("Zadejte název transakce: ");
        string description = Console.ReadLine();
        Console.Write("Zadejte kategorii transakce: ");
        string category = Console.ReadLine();
        amounts.Add(amount);
        descriptions.Add(description);
        categories.Add(category);
        Console.WriteLine("Transakce byla přidána.");
    }
    static void EditTransaction()
    {
        if (amounts.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný. Nelze upravit žádný záznam.");
            return;
        }
        DisplayTransactions();
        int index = GetValidInput("Zadejte číslo záznamu pro úpravu: ", 1, amounts.Count);
        Console.Write("Zadejte novou částku transakce: ");
        int newAmount = int.Parse(Console.ReadLine());
        Console.Write("Zadejte nový název transakce: ");
        string newDescription = Console.ReadLine();
        Console.Write("Zadejte novou kategorii transakce: ");
        string newCategory = Console.ReadLine();
        amounts[index - 1] = newAmount;
        descriptions[index - 1] = newDescription;
        categories[index - 1] = newCategory;
        Console.WriteLine("Záznam byl upraven.");

        using (StreamWriter xx = new StreamWriter(@"U:\Documents\penezenka.txt"))
        {
            for (int i = 0; i < amounts.Count; i++)
            {
                xx.WriteLine($"{amounts[i]};{descriptions[i]};{categories[i]}");
            }
            xx.Dispose();
        }
    }
    static void DeleteTransaction()
    {
        if (amounts.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný. Nelze smazat žádný záznam.");
            return;
        }
        DisplayTransactions();
        int index = GetValidInput("Zadejte číslo záznamu pro smazání: ", 1, amounts.Count);
        amounts.RemoveAt(index - 1);
        descriptions.RemoveAt(index - 1);
        categories.RemoveAt(index - 1);
        Console.WriteLine("Záznam byl smazán.");
    }
    static void DisplayTransactions()
    {
        if (amounts.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný.");
            return;
        }
        Console.WriteLine("Seznam transakcí:");
        Console.WriteLine("{0,-15} {1,-25} {2,-20}", "Částka", "Název", "Kategorie");
        for (int i = 0; i < amounts.Count; i++)
        {
            Console.WriteLine($"{amounts[i],-15} {descriptions[i],-25} {categories[i],-20}");
        }
    }
    static void FilterTransactions()
    {
        if (amounts.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný. Nelze provést filtraci.");
            return;
        }
        Console.Write("Zadejte hledaný řetězec: ");
        string search = Console.ReadLine();
        Console.WriteLine("Výsledky filtrace:");
        Console.WriteLine("{0,-15} {1,-25} {2,-20}", "Částka", "Název", "Kategorie");
        for (int i = 0; i < amounts.Count; i++)
        {
            if (descriptions[i].Contains(search) || categories[i].Contains(search))
            {
                Console.WriteLine($"{amounts[i],-15} {descriptions[i],-25} {categories[i],-20}");
            }
        }
    }
    static void ShowStatistics()
    {
        if (amounts.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný. Nelze vypočítat statistiky.");
            return;
        }
        int totalIncome = amounts.Where(a => a > 0).Sum();
        int totalExpenses = amounts.Where(a => a < 0).Sum();
        int countIncome = amounts.Count(a => a > 0);
        int countExpenses = amounts.Count(a => a < 0);
        var incomeValues = amounts.Where(a => a > 0).ToList();
        var expenseValues = amounts.Where(a => a < 0).ToList();
        int maxIncome = incomeValues.Any() ? incomeValues.Max() : 0;
        int minIncome = incomeValues.Any() ? incomeValues.Min() : 0;
        int maxExpense = expenseValues.Any() ? expenseValues.Max() : 0;
        int minExpense = expenseValues.Any() ? expenseValues.Min() : 0;
        Console.WriteLine($"Celkové příjmy: {totalIncome}");
        Console.WriteLine($"Celkové výdaje: {totalExpenses}");
        Console.WriteLine($"Počet příjmů: {countIncome}");
        Console.WriteLine($"Počet výdajů: {countExpenses}");
        Console.WriteLine($"Největší příjem: {maxIncome}");
        Console.WriteLine($"Nejmenší příjem: {minIncome}");
        Console.WriteLine($"Největší výdaj: {maxExpense}");
        Console.WriteLine($"Nejmenší výdaj: {minExpense}");
    }
    static void ShowCategories()
    {
        if (amounts.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný. Nelze vypsat kategorie.");
            return;
        }
        var distinctCategories = categories.Distinct().ToList();
        Console.WriteLine("Dostupné kategorie:");
        foreach (var category in distinctCategories)
        {
            Console.WriteLine(category);
        }
        Console.WriteLine("Součty podle kategorií:");
        foreach (var category in distinctCategories)
        {
            int sum = amounts.Where((a, index) => categories[index] == category).Sum();
            Console.WriteLine($"Kategorie '{category}': {sum}");
        }
    }
    static void SortTransactions()
    {
        if (amounts.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný. Nelze řadit žádné záznamy.");
            return;
        }
        Console.WriteLine("Vyberte podle čeho chcete řadit:");
        Console.WriteLine("1. Částka");
        Console.WriteLine("2. Název");
        Console.Write("Vaše volba (1-2): ");
        int sortChoice;
        if (!int.TryParse(Console.ReadLine(), out sortChoice) || (sortChoice != 1 && sortChoice != 2))
        {
            Console.WriteLine("Neplatná volba. Zadejte prosím číslo 1 nebo 2.");
            return;
        }
        Console.WriteLine("Vyberte typ řazení:");
        Console.WriteLine("1. Vzestupně");
        Console.WriteLine("2. Sestupně");
        Console.Write("Vaše volba (1-2): ");
        int orderChoice;
        if (!int.TryParse(Console.ReadLine(), out orderChoice) || (orderChoice != 1 && orderChoice != 2))
        {
            Console.WriteLine("Neplatná volba. Zadejte prosím číslo 1 nebo 2.");
            return;
        }
        if (sortChoice == 1)
        {
            if (orderChoice == 1)
            {
                SortAscendingByAmount();
            }
            else
            {
                SortDescendingByAmount();
            }
        }
        else
        {
            if (orderChoice == 1)
            {
                SortAscendingByDescription();
            }
            else
            {
                SortDescendingByDescription();
            }
        }
        Console.WriteLine("Seznam záznamů po řazení:");
        DisplayTransactions();
    }
    static void SortAscendingByAmount()
    {
        var sorted = amounts.Zip(descriptions, (amount, description) => new { Amount = amount, Description = description })
                            .OrderBy(item => item.Amount)
                            .ToList();
        amounts.Clear();
        descriptions.Clear();
        foreach (var item in sorted)
        {
            amounts.Add(item.Amount);
            descriptions.Add(item.Description);
        }
    }
    static void SortDescendingByAmount()
    {
        var sorted = amounts.Zip(descriptions, (amount, description) => new { Amount = amount, Description = description })
                            .OrderByDescending(item => item.Amount)
                            .ToList();
        amounts.Clear();
        descriptions.Clear();
        foreach (var item in sorted)
        {
            amounts.Add(item.Amount);
            descriptions.Add(item.Description);
        }
    }
    static void SortAscendingByDescription()
    {
        var sorted = descriptions.Zip(amounts, (description, amount) => new { Description = description, Amount = amount })
                                .OrderBy(item => item.Description)
                                .ToList();
        descriptions.Clear();
        amounts.Clear();
        foreach (var item in sorted)
        {
            descriptions.Add(item.Description);
            amounts.Add(item.Amount);
        }
    }
    static void SortDescendingByDescription()
    {
        var sorted = descriptions.Zip(amounts, (description, amount) => new { Description = description, Amount = amount })
                                .OrderByDescending(item => item.Description)
                                .ToList();
        descriptions.Clear();
        amounts.Clear();
        foreach (var item in sorted)
        {
            descriptions.Add(item.Description);
            amounts.Add(item.Amount);
        }
    }
    static int GetValidInput(string message, int minValue, int maxValue)
    {
        int input;
        do
        {
            Console.Write(message);

            
        } while (!int.TryParse(Console.ReadLine(), out input) || input < minValue || input > maxValue);
        return input;

        
    }
}