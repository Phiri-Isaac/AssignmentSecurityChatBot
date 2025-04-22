using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "I-S-A-A-C - Your Security Awareness Assistant"; //Program name
        Console.ForegroundColor = ConsoleColor.Cyan;

        PlayVoiceGreeting(); // ✅ Play WAV file using PowerShell
        ShowAsciiLogo();
        ShowWelcomeMessage();

        string userName = GetUserName();
        GreetUser(userName);
        StartChatLoop(userName);
    }

    //**** AUDIO GREETING USING POWERSHELL ****//
    static void PlayVoiceGreeting()
    {
        try
        {
            string audioPath = @"C:\Users\isaac\OneDrive\Desktop\SecurityChatBot\SecurityChatBot\bin\Debug\net8.0\Voice 3.wav";

            if (File.Exists(audioPath))
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = $"-c (New-Object Media.SoundPlayer '{audioPath}').PlaySync();",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                System.Diagnostics.Process.Start(psi)?.WaitForExit();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Audio file not found at: " + audioPath);
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error playing audio: " + ex.Message);
            Console.ResetColor();
        }
    }

    //**** ASCII LOGO ****//
    static void ShowAsciiLogo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"
 ___ ___  ____ ____   ___   ___   ___  
|_ _/ _ \|_  /|_  /  / _ \ / _ \ / _ \ 
 | | | | |/ /  / /  | (_) | (_) | (_) |
|___\___//___|/___|  \___/ \___/ \___/ 
                                      
        ");
        Console.ResetColor();
        Thread.Sleep(800);
    }

    //**** WELCOME SECTION ****//
    static void ShowWelcomeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===========================================");
        Console.WriteLine("||     WELCOME TO I-S-A-A-C TERMINAL     ||");
        Console.WriteLine("===========================================\n");
        Console.ResetColor();
    }

    //**** USER INPUT: NAME ****//
    static string GetUserName()
    {
        string name = "";
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Please enter your name or nickname you would like me to call you: ");
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
        Console.WriteLine($"\nHello {userName}, I’m I-S-A-A-C — your cybersecurity assistant.\n");
        Console.ResetColor();
        Thread.Sleep(500);

        Console.ForegroundColor = ConsoleColor.Magenta;
        SimulateTyping("My name is I-S-A-A-C, which stands for:");
        Thread.Sleep(300);
        SimulateTyping("I – Inform");
        SimulateTyping("S – Secure");
        SimulateTyping("A – Alert");
        SimulateTyping("A – Analyze");
        SimulateTyping("C – Control\n");
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
            Console.Write("I-S-A-A-C: ");
            Console.ResetColor();

            // Keyword-based chatbot replies
            if (input.Contains("how are you"))
            {
                SimulateTyping("I'm pretty good could be better but atleast I'm always on the lookout for cyber threats!");
            }
            else if (input.Contains("your purpose"))
            {
                SimulateTyping("My Job is to educate and help you through online safety practices.");
            }
            else if (input.Contains("password"))
            {
                SimulateTyping("Be creative and use strong passwords: 8+ characters, with a combination of letters, numbers, and symbols.");
            }
            else if (input.Contains("phishing"))
            {
                SimulateTyping("Phishing is when attackers trick you into giving up info. Always make sure emails are from legit people or company");
            }
            else if (input.Contains("safe browsing"))
            {
                SimulateTyping("Stick to secure sites (HTTPS), avoid shady links, and don’t download untrusted files, because they lead to unwanted viruses.");
            }
            else if (input.Contains("exit") || input.Contains("bye"))
            {
                SimulateTyping("See you, Stay sharp and safe online.");
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
            Thread.Sleep(25);
        }
        Console.WriteLine();
    }
}