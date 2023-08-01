using therapyFlow.Modules.Note;

namespace therapyFlow.Modules.Customer.Models
{
    public class CustomerModel
    {
        public Guid Id { set; get; }
        public string FirstName { set; get; } = "";
        public string LastName { set; get; } = "";
        public List<NoteModel> Notes { set; get; } = new();
    }
}