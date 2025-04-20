using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "A-L-E-X - Your Security Awareness Assistant";
        Console.ForegroundColor = ConsoleColor.Cyan;

        ShowWelcomeMessage();
        string userName = GetUserName();
        GreetUser(userName);
        StartChatLoop(userName);
    }

    //**** WELCOME SECTION ****//
    static void ShowWelcomeMessage()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("||     WELCOME TO A-L-E-X TERMINAL      ||");
        Console.WriteLine("===========================================\n");
        Console.ResetColor();
    }

    //**** USER INPUT: NAME ****//
    static string GetUserName()
    {
        string name = "";
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty.\n");
                Console.ResetColor();
            }
        }
        return name;
    }

    //**** PERSONALIZED GREETING + BOT INTRO ****//
    static void GreetUser(string userName)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nHello {userName}, I’m A-L-E-X — your cybersecurity assistant.\n");
        Console.ResetColor();
        Thread.Sleep(500);

        Console.ForegroundColor = ConsoleColor.Magenta;
        SimulateTyping("My name is A-L-E-X, which stands for:");
        Thread.Sleep(300);
        SimulateTyping("A – Awareness");
        SimulateTyping("L – Lockdown");
        SimulateTyping("E – Educate");
        SimulateTyping("X – eXecute Safely\n");
        Console.ResetColor();

        SimulateTyping("Ask me about phishing, passwords, safe browsing, or just chat!\n");
    }

    //**** CHAT LOOP ****//
    static void StartChatLoop(string userName)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{userName}: ");
            Console.ResetColor();

            string input = Console.ReadLine().ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter something. I didn’t catch that.\n");
                Console.ResetColor();
                continue;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("A-L-E-X: ");
            Console.ResetColor();

            // Keyword-based chatbot replies
            if (input.Contains("how are you"))
            {
                SimulateTyping("I'm functioning optimally and always on the lookout for cyber threats!");
            }
            else if (input.Contains("your purpose"))
            {
                SimulateTyping("My mission is to educate and guide you through online safety practices.");
            }
            else if (input.Contains("password"))
            {
                SimulateTyping("Always use strong passwords: 8+ characters, mix of letters, numbers, and symbols.");
            }
            else if (input.Contains("phishing"))
            {
                SimulateTyping("Phishing is when attackers trick you into giving up info. Always verify emails!");
            }
            else if (input.Contains("safe browsing"))
            {
                SimulateTyping("Stick to secure sites (HTTPS), avoid shady links, and don’t download untrusted files.");
            }
            else if (input.Contains("exit") || input.Contains("bye"))
            {
                SimulateTyping("Goodbye! Stay sharp and safe online.");
                break;
            }
            else
            {
                SimulateTyping("Hmm... I didn’t quite understand that. Could you rephrase?");
            }

            Console.WriteLine(); // Add spacing
        }
    }

    //**** TYPING EFFECT FOR REPLIES ****//
    static void SimulateTyping(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(25); // typing effect
        }
        Console.WriteLine();
    }
}