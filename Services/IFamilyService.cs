using FamilySorter.DTOs;

namespace FamilySorter.Services
{
    public interface IFamilyService
    {
        List<FamilyDTO> GroupByLastNameAndSort(List<PersonDTO> people);
    }
}
