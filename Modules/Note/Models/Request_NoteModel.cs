namespace therapyFlow.Modules.Note
{
    public class Request_NoteModel
    {
        public string Title { set; get; } = "";
        public string Text { set; get; } = "";
        public Guid CustomerId { get; set; }
    }
}