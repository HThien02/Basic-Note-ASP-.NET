using Notion;
using Notion.Models;
class Program
{
        private static NoteManager NoteManager = new NoteManager();

    public static void Main(string[] args)
    {
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
                    ShowAllNotes();
                    break;
                case "2":
                    AddOrUpdate();
                    break;
                case "3":
                    DeleteNote();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
            }
        }

        static void ShowAllNotes()
        {
            List<Note> notes = NoteManager.GetAllNotes();

            if (notes.Count == 0)
            {
                Console.WriteLine("Don't have any note");
            }
            else
            {
                foreach(var note in notes)
                {
                    Console.WriteLine($"[{note.ID}] | [{note.Title}]: {note.Content} | {note.Created}");
                }
            }
        }
        
        static void AddOrUpdate()
        {
            Console.Write("Input title of note: ");
            string title = Console.ReadLine();
            Console.WriteLine("Input content of note: ");
            string content = Console.ReadLine();

            NoteManager.AddOrUpdateNote(title, content);
            Console.WriteLine("Your note has been updated");
        }

        static void DeleteNote()
        {
            Console.WriteLine("Input ID of note: ");
            if (int.TryParse(Console.ReadLine(), out int id)) {
                Note noteToDelete = NoteManager.GetNoteByID(id);
                if (noteToDelete != null)
                {
                    NoteManager.DeleteNoteByID(id);
                    Console.WriteLine($"Deleted note have ID is {id}");
                } else
                {
                    Console.WriteLine($"Don't have any note ID is {id}");
                } 
            } else
            {
                Console.WriteLine("Your ID is not valid");
            }
        }

    }

}