using therapyFlow.Modules.Note.Models;

namespace therapyFlow.Modules.Customer.Models
{
    public class CustomerModelDTO
    {
        public Guid Id { set; get; }
        public string FirstName { set; get; } = "";
        public string LastName { set; get; } = "";
        public List<NoteModelDTO> Notes { set; get; } = new();
    }
}