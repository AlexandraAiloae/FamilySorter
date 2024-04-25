using FamilySorter.DTOs;

namespace FamilySorter.Services
{
    public class FileWritingService : IFileWritingService
    {
        public void WriteResultToFile(List<FamilyDTO> families, string outputPath)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var family in families)
                {
                    writer.WriteLine($"{family.LastName}: {string.Join(" ", family.Members)}");
                }
            }
        }
    }
}
