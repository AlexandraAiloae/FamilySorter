using FamilySorter.DTOs;

namespace FamilySorter.Services
{
    public class FamilyService : IFamilyService
    {
        public List<FamilyDTO> GroupByLastNameAndSort(List<PersonDTO> people)
        {
            var families = people.GroupBy(p => p.LastName)
                                .Select(group => new FamilyDTO
                                {
                                    LastName = group.Key,
                                    Members = group.OrderBy(p => p.DateOfBirth)
                                                  .Select(p => p.FirstName)
                                                  .ToList()
                                })
                                .OrderByDescending(family => family.Members.Count)
                                .ToList();
            return families;
        }
    }
}
