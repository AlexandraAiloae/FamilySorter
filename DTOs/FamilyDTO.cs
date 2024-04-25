namespace FamilySorter.DTOs
{
    public class FamilyDTO
    {
        public required string LastName { get; set; }
        public required List<string> Members { get; set; }
    }
}
