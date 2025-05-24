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
    static Dictionary<string, string> memory = new Dictionary<string, string>();

    static void Main(string[] args)
    {
        Console.Title = "I-S-A-A-C - Your Security Awareness Assistant";
        Console.ForegroundColor = ConsoleColor.Cyan;

        PlayVoiceGreeting();
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

        SimulateTyping("Let's chat! You can ask me about phishing, passwords, safe browsing, or just have a casual conversation.\nType 'help' if you need a list of things to ask.\n");
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

            pastInputs.Add(input);

            bool isPositive = input.Contains("good") || input.Contains("great") || input.Contains("thanks") || input.Contains("awesome") || input.Contains("cool");
            bool isNegative = input.Contains("bad") || input.Contains("terrible") || input.Contains("hate") || input.Contains("annoying") || input.Contains("sad") || input.Contains("tired");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("I-S-A-A-C: ");
            Console.ResetColor();

            // Memory Recall
            if (input.Contains("my name is") || input.Contains("call me"))
            {
                string[] parts = input.Split(' ');
                string newName = parts.Last();
                memory["userName"] = newName;
                SimulateTyping($"Got it! I'll call you {newName} from now on.");
                continue;
            }

            if (memory.ContainsKey("userName"))
            {
                userName = memory["userName"];
            }

            // Casual small talk
            if (input.Contains("how are you") || input.Contains("what's up"))
            {
                string[] casualReplies = {
                    "I'm just a bunch of code, but I'm feeling pretty electric today!",
                    "All systems online and ready to chat.",
                    "Always ready to help. How are you feeling today?",
                    "Chilling in the cyber realm, doing my bot thing."
                };
                SimulateTyping(casualReplies[rand.Next(casualReplies.Length)]);
            }
            else if (isPositive)
            {
                SimulateTyping("That's awesome! What's making you feel that way?");
            }
            else if (isNegative)
            {
                SimulateTyping("I'm sorry to hear that. Want to talk about it?");
            }
            else if (input.Contains("phishing"))
            {
                string[] responses = {
                    "Phishing is a sneaky attempt to get your personal info. Always check who sent the email.",
                    "Remember: no legit company will ask for your password via email.",
                    "If it feels fishy, it probably is. Don't click on suspicious links.",
                    "When in doubt, contact the company directly using their official site."
                };
                SimulateTyping(responses[rand.Next(responses.Length)]);
            }
            else if (input.Contains("password"))
            {
                string[] responses = {
                    "Strong passwords are like strong locks: long, complex, and unique.",
                    "Consider a password manager to handle the chaos of passwords.",
                    "Use different passwords for different accounts. One password to rule them all is not safe.",
                    "Don’t forget: change your passwords regularly, especially for critical accounts."
                };
                SimulateTyping(responses[rand.Next(responses.Length)]);
            }
            else if (input.Contains("safe browsing"))
            {
                string[] responses = {
                    "Stay safe: stick to secure (HTTPS) sites, avoid shady popups.",
                    "An ad blocker and regular software updates are your online shield.",
                    "Be cautious of what you download — that free game might come with a virus.",
                    "When in doubt, Google it. If it looks too good to be true, it probably is."
                };
                SimulateTyping(responses[rand.Next(responses.Length)]);
            }
            else if (input.Contains("help"))
            {
                DisplayHelp();
            }
            else if (input.Contains("bye") || input.Contains("exit"))
            {
                string[] goodbyes = {
                    "Catch you later! Stay safe online.",
                    "It's been great chatting. Remember, safety first!",
                    "Goodbye for now! I'll be here when you need me.",
                    "Logging off... but you know where to find me!"
                };
                SimulateTyping(goodbyes[rand.Next(goodbyes.Length)]);
                break;
            }
            else
            {
                // Catch-all casual responses
                string[] casualReplies = {
                    "Tell me more about that.",
                    "That's interesting! Can you elaborate?",
                    "I hear you! What else is on your mind?",
                    "Cool! Let's keep the conversation going."
                };
                SimulateTyping(casualReplies[rand.Next(casualReplies.Length)]);
            }

            Console.WriteLine();
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
        SimulateTyping("- Or just chat with me about anything!");
        Console.ResetColor();
    }
}
