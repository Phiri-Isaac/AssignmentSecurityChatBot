using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Random rand = new Random();

    //**** MEMORY AND STATE ****//
    static List<string> pastInputs = new List<string>();

    static void Main(string[] args)
    {
        Console.Title = "I-S-A-A-C - Your Security Awareness Assistant"; // Program name
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

        SimulateTyping("Ask me about phishing, passwords, safe browsing, or just chat!\nType 'help' if you’re unsure what to ask.\n");
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

            // Store in memory
            pastInputs.Add(input);

            // Basic sentiment detection
            bool isPositive = input.Contains("good") || input.Contains("great") || input.Contains("thanks");
            bool isNegative = input.Contains("bad") || input.Contains("terrible") || input.Contains("hate") || input.Contains("annoying");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("I-S-A-A-C: ");
            Console.ResetColor();

            // Memory-based reminders
            if (pastInputs.Count(i => i.Contains("phishing")) > 2)
            {
                SimulateTyping("You’ve asked about phishing a few times — remember to always double-check links!");
            }
            else if (pastInputs.Count(i => i.Contains("password")) > 2)
            {
                SimulateTyping("We’ve covered passwords quite a bit! Consider using a manager to help remember them.");
            }

            // Sentiment responses
            if (isPositive)
            {
                SimulateTyping("Glad to hear that! 😊");
            }
            else if (isNegative)
            {
                SimulateTyping("Sorry to hear that. If there’s anything I can do to help, let me know.");
            }

            // Keyword-based chatbot replies
            if (input.Contains("how are you"))
            {
                SimulateTyping("I'm pretty good, could be better, but at least I'm always on the lookout for cyber threats!");
            }
            else if (input.Contains("your purpose"))
            {
                SimulateTyping("My job is to educate and help you through online safety practices.");
            }
            else if (input.Contains("password"))
            {
                string[] responses = {
                    "Be creative and use strong passwords: 8+ characters, with a combination of letters, numbers, and symbols.",
                    "Use different passwords for different accounts, and track them with a password manager.",
                    "Use the auto-generated passwords, write them down securely or store them in a manager.",
                    "Enable multi-factor authentication wherever you can. It’s a strong second layer of protection."
                };
                int index = rand.Next(responses.Length);
                SimulateTyping(responses[index]);
            }
            else if (input.Contains("phishing"))
            {
                string[] responses = {
                    "Phishing is when attackers trick you into giving up info. Always make sure emails are from legit people or companies.",
                    "Double check if that email you received is from a trusted source before clicking links.",
                    "Avoid emails asking for personal info — that’s a red flag.",
                    "If something feels off in an email — trust your gut. Don't click suspicious links."
                };
                int index = rand.Next(responses.Length);
                SimulateTyping(responses[index]);
            }
            else if (input.Contains("safe browsing"))
            {
                string[] responses = {
                    "Stick to secure sites (HTTPS), avoid shady links, and don’t download untrusted files.",
                    "Use a trusted browser with security features, and always update it.",
                    "Don’t download random files — even if it looks like a game mod or crack, it might be malware.",
                    "Install an ad blocker and stay clear of sketchy popups."
                };
                int index = rand.Next(responses.Length);
                SimulateTyping(responses[index]);
            }
            else if (input.Contains("help"))
            {
                DisplayHelp();
            }
            else if (input.Contains("exit") || input.Contains("bye"))
            {
                string[] responses = {
                    "See you! Stay sharp and safe online.",
                    "Our time was good while it lasted, I hope I helped, bye.",
                    "Don't talk to strangers online who are asking for your personal information. See you, chief!",
                    "Come again soon, byeeeee."
                };
                int index = rand.Next(responses.Length);
                SimulateTyping(responses[index]);
                break;
            }
            else
            {
                SimulateTyping("Hmm... I didn’t quite understand that. Type 'help' if you’re stuck.");
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

    //**** HELP COMMAND OUTPUT ****//
    static void DisplayHelp()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        SimulateTyping("Here’s what you can ask me about:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        SimulateTyping("- 'phishing' → Learn how to spot and avoid phishing attempts.");
        SimulateTyping("- 'password' → Get advice on creating strong passwords.");
        SimulateTyping("- 'safe browsing' → Stay protected while surfing online.");
        SimulateTyping("- 'how are you' → Have a casual chat with me.");
        SimulateTyping("- 'exit' or 'bye' → End our session.");
        Console.ResetColor();
    }

    //**** FUTURE MODULE PLACEHOLDER ****//
    // static void FutureFeature() { 
    //     // You can build additional tools here later 
    // }
}
