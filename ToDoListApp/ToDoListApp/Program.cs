using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> tasks = new List<string>();
    const string filePath = "tasks.txt";

    static void Main()
    {
        LoadTasksFromFile();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nTo-Do List Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Delete Task");
            Console.WriteLine("3. View Tasks");
            Console.WriteLine("4. Edit Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    DeleteTask();
                    break;
                case "3":
                    ViewTasks();
                    break;
                case "4":
                    EditTask();
                    break;
                case "5":
                    SaveTasksToFile();
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter new task: ");
        string task = Console.ReadLine();
        if (!tasks.Contains(task))
        {
            tasks.Add(task);
            Console.WriteLine("Task added.");
        }
        else
        {
            Console.WriteLine("Task already exists.");
        }
    }

    static void DeleteTask()
    {
        Console.Write("Enter task number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            Console.WriteLine($"Task \"{tasks[index - 1]}\" deleted.");
            tasks.RemoveAt(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    static void ViewTasks()
    {
        Console.WriteLine("\nYour Tasks:");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    static void EditTask()
    {
        ViewTasks();
        Console.Write("Enter task number to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            Console.Write("Enter new task text: ");
            string newTask = Console.ReadLine();

            if (!tasks.Contains(newTask))
            {
                tasks[index - 1] = newTask;
                Console.WriteLine("Task updated.");
            }
            else
            {
                Console.WriteLine("Duplicate task. Edit cancelled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    static void LoadTasksFromFile()
    {
        if (File.Exists(filePath))
        {
            tasks = new List<string>(File.ReadAllLines(filePath));
        }
    }

    static void SaveTasksToFile()
    {
        File.WriteAllLines(filePath, tasks);
    }
}