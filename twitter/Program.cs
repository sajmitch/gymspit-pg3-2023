using System;

class Program
{
    static string[] usernames = new string[100];
    static string[] passwords = new string[100];
    static string[,] posts = new string[100, 100];
    static int[,] follows = new int[100, 100];

    static int currentUser = -1;
    static int usersCount = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Chceš se přihlásit (1), nebo se registrovat (2)? ");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    SignIn();
                    break;
                case '2':
                    Register();
                    break;
                default:
                    Console.WriteLine("\nNeplatná volba, zadej '1' pro přihlášení nebo '2' pro registraci.");
                    break;
            }
        }
    }

    static void SignIn()
    {
        Console.WriteLine("\nZadej uživatelské jméno: ");
        string username = Console.ReadLine();
        Console.WriteLine("Zadej heslo: ");
        string password = Console.ReadLine();

        int index = Array.IndexOf(usernames, username);
        if (index != -1 && passwords[index] == password)
        {
            currentUser = index;
            Console.WriteLine($"Přihlášení uživatele: {username}");
            UserMenu();
        }
        else
        {
            Console.WriteLine("Nesprávné uživatelské jméno nebo heslo.");
        }
    }

    static void Register()
    {
        Console.WriteLine("\nZadej nové uživatelské jméno: ");
        string newUsername = Console.ReadLine();

        if (Array.IndexOf(usernames, newUsername) != -1)
        {
            Console.WriteLine("Uživatelské jméno již existuje, vyber si jiné.");
            return;
        }

        Console.WriteLine("Zadej nové heslo: ");
        string newPassword = Console.ReadLine();

        usernames[usersCount] = newUsername;
        passwords[usersCount] = newPassword;
        usersCount++;

        Console.WriteLine("Registrace proběhla úspěšně.");
    }

    static void UserMenu()
    {
        while (true)
        {
            Console.WriteLine("\nCo chceš udělat?");
            Console.WriteLine("1. Vytvořit příspěvek");
            Console.WriteLine("2. Zobrazit mé příspěvky");
            Console.WriteLine("3. Zobrazit cizí příspěvky");
            Console.WriteLine("4. Sledovat někoho");
            Console.WriteLine("5. Zobrazit sledované");
            Console.WriteLine("6. Odhlásit se");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreatePost();
                        break;
                    case 2:
                        DisplayUserPosts(currentUser);
                        break;
                    case 3:
                        DisplayOtherPosts();
                        break;
                    case 4:
                        FollowUser();
                        break;
                    case 5:
                        DisplayFollowedUsers();
                        break;
                    case 6:
                        currentUser = -1;
                        Console.WriteLine("Uživatel byl odhlášen.");
                        return;
                    default:
                        Console.WriteLine("Neplatná volba.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Neplatná volba.");
            }
        }
    }

    static void CreatePost()
    {
        Console.WriteLine("Zadej titulek příspěvku: ");
        string title = Console.ReadLine();
        Console.WriteLine("Zadej obsah příspěvku: ");
        string content = Console.ReadLine();

        for (int i = 0; i < posts.GetLength(1); i++)
        {
            if (posts[currentUser, i] == null)
            {
                posts[currentUser, i] = $"{title} - {content}";
                Console.WriteLine("Příspěvek byl úspěšně přidán.");
                return;
            }
        }

        Console.WriteLine("Nemůžeš na tomto účtu zadat více příspěvků.");
    }

    static void DisplayUserPosts(int user)
    {
        Console.WriteLine("Moje příspěvky:");
        for (int i = 0; i < posts.GetLength(1); i++)
        {
            if (posts[user, i] != null)
            {
                Console.WriteLine(posts[user, i]);
            }
        }
    }

    static void DisplayOtherPosts()
    {
        Console.WriteLine("Všechny příspěvky:");

        for (int i = 0; i < usernames.Length; i++)
        {
            if (!string.IsNullOrEmpty(usernames[i]))
            {
                Console.WriteLine($"Příspěvky uživatele {usernames[i]}:");

                for (int j = 0; j < posts.GetLength(1); j++)
                {
                    if (!string.IsNullOrEmpty(posts[i, j]))
                    {
                        Console.WriteLine(posts[i, j]);
                    }
                }
            }
        }
    }

    static void FollowUser()
    {
        Console.WriteLine("Zadej uživatelské jméno uživatele, kterého chceš sledovat:");
        string username = Console.ReadLine();

        int index = Array.IndexOf(usernames, username);
        if (index == -1)
        {
            Console.WriteLine("Zadané uživatelské jméno neexistuje.");
            return;
        }

        follows[currentUser, index] = 1;
        Console.WriteLine($"Nyní sleduješ uživatele {username}");
    }

    static void DisplayFollowedUsers()
    {
        Console.WriteLine("Uživatelé, které sleduji:");
        for (int i = 0; i < follows.GetLength(1); i++)
        {
            if (follows[currentUser, i] == 1)
            {
                Console.WriteLine(usernames[i]);
            }
        }
    }
}
