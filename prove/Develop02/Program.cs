using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    public void SaveJournalToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadJournalFromFile(string filename)
    {
        try
        {
            entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        Entry entry = new Entry
                        {
                            Date = parts[0],
                            Prompt = parts[1],
                            Response = parts[2]
                        };
                        entries.Add(entry);
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display the Journal");
            Console.WriteLine("3. Save the Journal to a File");
            Console.WriteLine("4. Load the Journal from a File");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter your response: ");
                    string response = Console.ReadLine();
                    Console.WriteLine("Enter the date (YYYY-MM-DD): ");
                    string date = Console.ReadLine();
                    Entry entry = new Entry
                    {
                        Prompt = GetRandomPrompt(),
                        Response = response,
                        Date = date
                    };
                    journal.AddEntry(entry);
                    break;

                case 2:
                    journal.DisplayEntries();
                    break;

                case 3:
                    Console.WriteLine("Enter the filename to save: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveJournalToFile(saveFileName);
                    break;

                case 4:
                    Console.WriteLine("Enter the filename to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadJournalFromFile(loadFileName);
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static string GetRandomPrompt()
    {
        // Implement logic to get a random prompt from your predefined list
        // For simplicity, you can use a fixed list of prompts.
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}
