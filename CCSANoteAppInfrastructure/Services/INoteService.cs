using CCSANoteApp.Domain;

namespace CCSANoteApp.Infrastructure
{
    public interface INoteService
    {
        //C-R-U-D
        void CreateNote(Note note);
        void CreateNote(Guid creatorUserId,string title, string content,string groupName);
        void UpdateNote(Guid id, string content, string groupName);
        void UpdateNote(Guid id, string content);
        void UpdateNoteTitle(Guid id, string title);
        void DeleteNote(Guid id);
        void DeleteNote(List<Guid> notes);
        List<Note> FetchNote();
        List<Note> FetchNoteByUser(Guid id);
        Note FetchNoteById(Guid id);
        List<Note> FetchNoteByGroup(Guid userId, string groupName);
    }
}
