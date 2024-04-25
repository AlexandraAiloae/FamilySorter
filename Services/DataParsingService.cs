using FamilySorter.DTOs;

namespace FamilySorter.Services
{
    public class DataParsingService : IDataParsingService
    {
        public List<PersonDTO> ParseInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input is null or empty.");
            }

            var lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            ValidateInput(lines);

            var countPeople = ParseCountPeople(lines[0]);
            var people = ParsePeople(lines.Skip(1).ToArray());

            if (people.Count != countPeople)
            {
                throw new ArgumentException("Count of people does not match.");
            }

            return people;
        }

        private void ValidateInput(string[] lines)
        {
            if (lines.Length < 2)
            {
                throw new ArgumentException("Invalid input format.");
            }
        }

        private int ParseCountPeople(string countLine)
        {
            if (!int.TryParse(countLine, out int countPeople))
            {
                throw new ArgumentException("Invalid count of people.");
            }
            return countPeople;
        }

        private List<PersonDTO> ParsePeople(string[] dataLines)
        {
            var people = new List<PersonDTO>();

            foreach (var line in dataLines)
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ValidateDataFormat(parts, line);

                var person = new PersonDTO
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    DateOfBirth = ParseDateOfBirth(parts[2])
                };

                people.Add(person);
            }

            return people;
        }

        private void ValidateDataFormat(string[] parts, string line)
        {
            if (parts.Length != 3)
            {
                throw new ArgumentException($"Invalid data format in line: {line}.");
            }
        }

        private DateTime ParseDateOfBirth(string dateOfBirthStr)
        {
            if (!DateTime.TryParse(dateOfBirthStr, out DateTime dateOfBirth))
            {
                throw new ArgumentException($"Invalid date of birth format: {dateOfBirthStr}.");
            }
            return dateOfBirth;
        }
    }
}
