using System;
using System.Collections.Generic;
using System.Linq;

class Wallet
{
    const int MaxListSize = 100; // Maximální velikost seznamu transakcí

    static List<(int, string, string)> transactions = new List<(int, string, string)>();

    static void Main()
    {
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
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Neplatná volba. Zadejte prosím číslo od 1 do 9.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddTransaction(transactions);
                    break;
                case 2:
                    EditTransaction();
                    break;
                case 3:
                    DeleteTransaction();
                    break;
                case 4:
                    DisplayTransactions(transactions);
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
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }
        }
    }

    static void AddTransaction(List<(int, string, string)> transactions)
    {
        if (transactions.Count >= MaxListSize)
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

        transactions.Add((amount, description, category));
        Console.WriteLine("Transakce byla přidána.");
    }

    static void EditTransaction()
    {
        if (transactions.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný. Nelze upravit žádný záznam.");
            return;
        }

        Console.WriteLine("Záznamy:");
        DisplayTransactions(transactions);

        Console.Write("Zadejte číslo záznamu pro úpravu: ");
        int index;
        while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > transactions.Count)
        {
            Console.WriteLine("Neplatný index. Zadejte prosím číslo z rozsahu existujících záznamů.");
            Console.Write("Zadejte číslo záznamu pro úpravu: ");
        }

        Console.Write("Zadejte novou částku transakce: ");
        int newAmount;
        while (!int.TryParse(Console.ReadLine(), out newAmount))
        {
            Console.WriteLine("Neplatná částka. Zadejte prosím číslo.");
            Console.Write("Zadejte novou částku transakce: ");
        }

        Console.Write("Zadejte nový název transakce: ");
        string newDescription = Console.ReadLine();

        Console.Write("Zadejte novou kategorii transakce: ");
        string newCategory = Console.ReadLine();

        transactions[index - 1] = (newAmount, newDescription, newCategory);
        Console.WriteLine("Záznam byl upraven.");
    }

    static void DeleteTransaction()
    {
        if (transactions.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný. Nelze smazat žádný záznam.");
            return;
        }

        Console.WriteLine("Záznamy:");
        DisplayTransactions(transactions);

        Console.Write("Zadejte číslo záznamu pro smazání: ");
        int index;
        while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > transactions.Count)
        {
            Console.WriteLine("Neplatný index. Zadejte prosím číslo z rozsahu existujících záznamů.");
            Console.Write("Zadejte číslo záznamu pro smazání: ");
        }

        transactions.RemoveAt(index - 1);
        Console.WriteLine("Záznam byl smazán.");
    }

    static void DisplayTransactions(List<(int, string, string)> transactions)
    {
        if (transactions.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný.");
            return;
        }

        Console.WriteLine("Seznam transakcí:");
        Console.WriteLine("{0,-15} {1,-25} {2,-20}", "Částka", "Název", "Kategorie");
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"{transaction.Item1,-15} {transaction.Item2,-25} {transaction.Item3,-20}");
        }
    }

    static void FilterTransactions()
    {
        Console.Write("Zadejte hledaný řetězec: ");
        string search = Console.ReadLine();

        var filteredTransactions = transactions.Where(t => t.Item2.Contains(search)).ToList();
        DisplayTransactions(filteredTransactions);
    }

    static void ShowStatistics()
    {
        if (transactions.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný. Nelze vypočítat statistiky.");
            return;
        }

        int totalIncome = transactions.Where(t => t.Item1 > 0).Sum(t => t.Item1);
        int totalExpenses = transactions.Where(t => t.Item1 < 0).Sum(t => t.Item1);
        int countIncome = transactions.Count(t => t.Item1 > 0);
        int countExpenses = transactions.Count(t => t.Item1 < 0);

        var incomeValues = transactions.Where(t => t.Item1 > 0).Select(t => t.Item1).ToList();
        var expenseValues = transactions.Where(t => t.Item1 < 0).Select(t => t.Item1).ToList();

        int maxIncome = incomeValues.Any() ? incomeValues.Max() : 0;
        int minIncome = incomeValues.Any() ? incomeValues.Min() : 0;
        int maxExpense = expenseValues.Any() ? expenseValues.Min() : 0;
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
        if (transactions.Count == 0)
        {
            Console.WriteLine("Seznam je prázdný. Nelze vypsat kategorie.");
            return;
        }

        var categories = transactions.Select(t => t.Item3).Distinct().ToList();
        Console.WriteLine("Dostupné kategorie:");
        foreach (var category in categories)
        {
            Console.WriteLine(category);
        }

        Console.WriteLine("Součty podle kategorií:");
        foreach (var category in categories)
        {
            int sum = transactions.Where(t => t.Item3 == category).Sum(t => t.Item1);
            Console.WriteLine($"Kategorie '{category}': {sum}");
        }
    }

    static void SortTransactions()
    {
        if (transactions.Count == 0)
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

        var sortedTransactions = sortChoice == 1
            ? orderChoice == 1
                ? transactions.OrderBy(t => t.Item1).ToList()
                : transactions.OrderByDescending(t => t.Item1).ToList()
            : orderChoice == 1
                ? transactions.OrderBy(t => t.Item2).ToList()
                : transactions.OrderByDescending(t => t.Item2).ToList();

        Console.WriteLine("Seznam záznamů po řazení:");
        DisplayTransactions(sortedTransactions);
    }
}
