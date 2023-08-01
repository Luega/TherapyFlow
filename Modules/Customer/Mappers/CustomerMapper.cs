using therapyFlow.Modules.Customer.Models;
using therapyFlow.Modules.Note;
using therapyFlow.Modules.Note.Mapper;
using therapyFlow.Modules.Note.Models;

namespace therapyFlow.Modules.Customer.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerModel ToCustomerModel(this Request_CustomerModel req)
        {
            return new CustomerModel
            {
                Id = Guid.NewGuid(),
                FirstName = req.FirstName,
                LastName = req.LastName,
            };
        }
        public static CustomerModelDTO ToCustomerModelDTO(this CustomerModel Customer)
        {
            return new CustomerModelDTO
            {
                Id = Customer.Id,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                Notes = NoteMapperHelper(Customer.Notes),
            };
        }
        private static List<NoteModelDTO> NoteMapperHelper(this List<NoteModel> CustomerNotes)
        {
            List<NoteModelDTO> CustomerNotesDTO = new();
            foreach (NoteModel note in CustomerNotes)
            {
                CustomerNotesDTO.Add(note.ToNoteModelDTO());
            }

            return CustomerNotesDTO;
        }
    }
}