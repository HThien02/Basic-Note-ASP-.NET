using Notion;
using Notion.Models;
class Program
{

    public static void Main(string[] args)
    {
        string filePath = "notes.txt";
        NoteManager noteManager = new NoteManager(filePath);
        
        while (true)
        {
            Console.WriteLine("1. Display all note");
            Console.WriteLine("2. Add/Update note");
            Console.WriteLine("3. Delete note");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Please choose from 1 to 4");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    noteManager.GetAllNotes().ForEach(note => Console.WriteLine(
                        $"ID: {note.ID}\n | Title: {note.Title}\n | Content: {note.Content}\n | Created Date: {note.Created}\n"
                        ));
                    break;
                case "2":
                    Console.WriteLine("Enter note's title: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter note content: ");
                    string content = Console.ReadLine();
                    noteManager.AddOrUpdateNote(title, content);
                    Console.WriteLine("Your note has been added or updated successfully!");
                    break;
                case "3":
                    Console.Write("Enter Note Title to Delete: ");
                    string titleToDelete = Console.ReadLine();
                    noteManager.DeleteNoteByID(int.Parse(titleToDelete));
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option!"); 
                    break;
            }
        }

    }

}