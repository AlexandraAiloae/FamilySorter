namespace FamilySorter.DTOs
{
    public class PersonDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
