using FamilySorter.DTOs;

namespace FamilySorter.Services
{
    public interface IFileWritingService
    {
        void WriteResultToFile(List<FamilyDTO> families, string outputPath);
    }
}
