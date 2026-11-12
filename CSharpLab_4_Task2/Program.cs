using System.Text;
using CSharpLab_4_Task2;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

SocialNetwork network = new SocialNetwork();

network.Users.Add(new User("Олександр", "alex@example.com", "alex"));
network.Users.Add(new User("Тарас", "taras@example.com", "taras"));
network.Users.Add(new User("Йосип", "yosyp@example.com", "yosyp"));

network.CreatePost(network.Users[0], "Бажаю всім мирного неба!");
network.CreatePost(network.Users[1], "В мене сьогодні вихідний!");
network.CreatePost(network.Users[2], "Вивчаю програмування на C#");

while (true)
{
    Console.WriteLine("СОЦІАЛЬНА МЕРЕЖА");
    Console.WriteLine("Оберіть користувача:");

    for (int i = 0; i < network.Users.Count; i++)
    {
        Console.WriteLine(
            $"{i + 1}. {network.Users[i].Name} (@{network.Users[i].Nickname})");
    }

    Console.WriteLine("0. Завершити програму");
    Console.Write("Ваш вибір: ");

    if (!int.TryParse(Console.ReadLine(), out int userChoice))
    {
        Console.WriteLine("Некоректне введення.");
        continue;
    }

    if (userChoice == 0)
    {
        break;
    }

    if (userChoice < 1 || userChoice > network.Users.Count)
    {
        Console.WriteLine("Такого користувача немає.");
        continue;
    }

    User currentUser = network.Users[userChoice - 1];

    bool changeUser = false;

    while (!changeUser)
    {
        Console.WriteLine($"\nВи увійшли як @{currentUser.Nickname}");
        Console.WriteLine("1. Створити пост");
        Console.WriteLine("2. Переглянути пости користувача");
        Console.WriteLine("3. Поставити лайк");
        Console.WriteLine("4. Написати коментар");
        Console.WriteLine("5. Видалити свій пост");
        Console.WriteLine("6. Переглянути свої пости");
        Console.WriteLine("0. Змінити користувача");
        Console.Write("Оберіть дію: ");

        if (!int.TryParse(Console.ReadLine(), out int action))
        {
            Console.WriteLine("Некоректна команда.");
            continue;
        }

        if (action == 0)
        {
            changeUser = true;
            continue;
        }

        if (action == 1)
        {
            Console.Write("Введіть текст поста: ");
            string text = Console.ReadLine() ?? "";

            network.CreatePost(currentUser, text);
        }
        else if (action == 6)
        {
            network.ShowPosts(currentUser);
        }
        else if (action >= 2 && action <= 4)
        {
            Console.WriteLine("\nІнші користувачі:");

            for (int i = 0; i < network.Users.Count; i++)
            {
                if (network.Users[i] != currentUser)
                {
                    Console.WriteLine(
                        $"{i + 1}. @{network.Users[i].Nickname}");
                }
            }

            Console.Write("Оберіть номер користувача: ");

            if (!int.TryParse(Console.ReadLine(), out int authorNumber)
                || authorNumber < 1
                || authorNumber > network.Users.Count)
            {
                Console.WriteLine("Неправильний номер.");
                continue;
            }

            User author = network.Users[authorNumber - 1];

            if (author == currentUser)
            {
                Console.WriteLine("Оберіть іншого користувача.");
                continue;
            }

            network.ShowPosts(author);

            if (action == 2)
            {
                continue;
            }

            Console.Write("Введіть ID поста: ");

            if (!int.TryParse(Console.ReadLine(), out int postId))
            {
                Console.WriteLine("Некоректний ID.");
                continue;
            }

            if (action == 3)
            {
                network.LikePost(author, postId);
            }
            else
            {
                Console.Write("Введіть коментар: ");
                string comment = Console.ReadLine() ?? "";

                network.CommentPost(author, postId, currentUser, comment);
            }
        }
        else if (action == 5)
        {
            network.ShowPosts(currentUser);

            Console.Write("Введіть ID поста для видалення: ");

            if (int.TryParse(Console.ReadLine(), out int postId))
            {
                network.DeletePost(currentUser, postId);
            }
            else
            {
                Console.WriteLine("Некоректний ID.");
            }
        }
        else
        {
            Console.WriteLine("Невідома команда.");
        }
    }
}

Console.WriteLine("Роботу соціальної мережі завершено.");
