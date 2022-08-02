using CCSANoteApp.Domain;

namespace CCSANoteApp.Infrastructure
{

    public class NoteService : INoteService
    {
        List<Note> notes = new List<Note>();

        public void CreateNote(Note note)
        {
            notes.Add(note);
        }

        public void CreateNote(Guid userId, string title, string content, string groupName)
        {
            notes.Add(new Note
            {
                Title = title,
                Content = content,
                UserId = userId,
                GroupName = groupName
            });
        }

        public void DeleteNote(Guid id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            if (note != null)
            {
                notes.Remove(note);
            }
        }

        public void DeleteNote(List<Guid> noteIds)
        {
            foreach (var id in noteIds)
            {
                DeleteNote(id);
            }
        }

        public List<Note> FetchNote()
        {
            return notes;
        }

        public List<Note> FetchNoteByGroup(Guid userId, string groupName)
        {
            var _notes = notes.Where(x => x.UserId == userId && x.GroupName == groupName);
            return notes.ToList();
        }

        public Note FetchNoteById(Guid id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            return note;
        }

        public List<Note> FetchNoteByUser(Guid id)
        {
            var _notes = notes.Where(x => x.UserId == id);
            return notes.ToList();
        }

        public void UpdateNote(Guid id, Note note)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Title = note.Title;
                _note.Content = note.Content;
                _note.GroupName = note.GroupName;
            }
        }

        public void UpdateNote(Guid id, string content)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Content = content;
            }
        }

        public void UpdateNote(Guid id, string content, string groupName)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Content = content;
                _note.GroupName = groupName;

            }
        }

        public void UpdateNoteTitle(Guid id, string title)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Title = title;
            }
        }

    }
}




