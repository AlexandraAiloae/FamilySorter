using FamilySorter.DTOs;

namespace FamilySorter.Services
{
    public interface IDataParsingService
    {
        List<PersonDTO> ParseInput(string input);
    }
}
