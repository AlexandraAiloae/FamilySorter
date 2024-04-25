using FamilySorter.DTOs;

namespace FamilySorter.Services
{
    public class FileParsingService : IFileParsingService
    {
        private readonly IDataParsingService _dataParsingService;

        public FileParsingService(IDataParsingService dataParsingService)
        {
            _dataParsingService = dataParsingService;
        }

        public List<PersonDTO> ParseFile(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            using (var reader = new StreamReader(stream))
            {
                var input = reader.ReadToEnd();
                return _dataParsingService.ParseInput(input);
            }
        }
    }
}
