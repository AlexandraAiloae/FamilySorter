using FamilySorter.DTOs;

namespace FamilySorter.Services
{
    public interface IFileParsingService
    {
        List<PersonDTO> ParseFile(IFormFile file);
    }
}