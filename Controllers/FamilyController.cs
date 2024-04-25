using Microsoft.AspNetCore.Mvc;
using FamilySorter.Services;

namespace FamilySorter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;
        private readonly IFileParsingService _fileParsingService;
        private readonly IFileWritingService _fileWritingService;

        public FamilyController(IFamilyService familyService, IFileParsingService fileParsingService, IFileWritingService fileWritingService)
        {
            _familyService = familyService;
            _fileParsingService = fileParsingService;
            _fileWritingService = fileWritingService;
        }

        [HttpPost("group")]
        public IActionResult GroupByLastNameAndSort(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty.");
            }

            try
            {
                var people = _fileParsingService.ParseFile(file);
                var result = _familyService.GroupByLastNameAndSort(people);

                _fileWritingService.WriteResultToFile(result, "Output.txt");

                return Ok(new { Families = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
