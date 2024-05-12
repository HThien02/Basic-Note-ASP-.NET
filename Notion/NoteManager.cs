using Notion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notion
{
    public class NoteManager
    {
        private List<Note> notes;
        private int nextID;

        public NoteManager()
        {
            notes = new List<Note>();
            nextID = 1;
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
