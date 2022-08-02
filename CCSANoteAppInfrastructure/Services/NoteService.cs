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

        public void CreateNote(User creator, string title, string content, GroupName groupName)
        {
            notes.Add(new Note
            {
                Title = title,
                Content = content,
                NoteCreator = creator,
                Group = groupName
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

        public List<Note> FetchNoteByGroup(Guid userId, GroupName groupName)
        {
            var _notes = notes.Where(x => x.NoteCreator == userId && x.Group == groupName);
            return notes.ToList();
        }

        public Note FetchNoteById(Guid id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            return note;
        }

        public List<Note> FetchNoteByUser(Guid creatorId)
        {
            var _notes = notes.Where(x => x.NoteCreator.Id == creatorId);
            return notes.ToList();
        }

        public void UpdateNote(Guid id, Note note)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Title = note.Title;
                _note.Content = note.Content;
                _note.Group = note.Group;
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

        public void UpdateNote(Guid id, string content, GroupName groupName)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Content = content;
                _note.Group = groupName;

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




