using therapyFlow.Modules.Customer.Models;

namespace therapyFlow.Modules.Note
{
    public class NoteModel
    {
        public Guid Id { set; get; }
        public string Title { set; get; } = "";
        public string Text { set; get; } = "";
        public Guid CustomerId { get; set; }
        public CustomerModel Customer { get; set; } = null!;
    }
}