using Notion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Notion
{
    public class NoteManager
    {
        private List<Note> notes;
        private int nextID;
        private string filePath;

        public NoteManager(string filePath)
        {
            notes = new List<Note>();
            nextID = 1;
            this.filePath = filePath;

            if(!File.Exists(filePath))
            {
                    SaveNotesToFile();
            }

            LoadNotesFromFile();
        }

        public void SaveNotesToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath)) {
                foreach (var note in notes) {            
                    writer.WriteLine($"ID : {note.ID}");
                    writer.WriteLine($"Title : {note.Title}");
                    writer.WriteLine($"Content : {note.Content}");
                    writer.WriteLine($"Created Date : {note.Created}");
                }
            }
        }

        private void LoadNotesFromFile() { 
            notes.Clear();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {

                    while (!reader.EndOfStream)
                    {
                        string title = ReadNoteProperty(reader.ReadLine());
                        string content = ReadNoteProperty(reader.ReadLine());

                        if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(content))
                        {
                            Note note = new Note { Title = title, Content = content };
                            notes.Add(note);
                        }
                    }
                }
            }
        }

        private string ReadNoteProperty(string line)
        {
            if (!string.IsNullOrWhiteSpace(line)) {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    return parts[1].Trim();
                }
            }
            return string.Empty;
        }

        public void AddOrUpdateNote(string title, string content)
        {
            Note existingNote = notes.FirstOrDefault(n => n.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        
            if (existingNote != null)
            {
                existingNote.Content = content;
            } else
            {
                Note newNote = new Note { 
                    ID = nextID++,
                    Title = title,
                    Content = content,
                    Created = DateTime.Now,
                };
                notes.Add(newNote);
                SaveNotesToFile();
            }
        }

        public void DeleteNoteByID(int id)
        {
            Note noteToDelete = notes.FirstOrDefault(n => n.ID == id);
            if (noteToDelete != null) { 
                notes.Remove(noteToDelete);
            }
        }

        public List<Note> GetAllNotes()
        {
            return notes.OrderBy(n => n.Created).ToList();
        }

        public Note GetNoteByID(int id)
        {
            return notes.FirstOrDefault(n => n.ID == id);
        }
    }
}
