namespace therapyFlow.Modules.Note.Models
{
    public class NoteModelDTO
    {
        public Guid Id { set; get; }
        public string Title { set; get; } = "";
        public string Text { set; get; } = "";
        public Guid CustomerId { get; set; }
    }
}