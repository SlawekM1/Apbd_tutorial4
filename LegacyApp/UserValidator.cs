using System;

namespace LegacyApp
{
    public class UserValidator
    {
        public bool ValidateName(string firstName, string lastName)
        {
            return !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName);
        }

        public bool ValidateEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        public bool ValidateAge(DateTime dateOfBirth)
        {
            var age = CalculateAge(dateOfBirth);
            return age >= 21;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Today;
            var age = now.Year - dateOfBirth.Year;
            if (dateOfBirth > now.AddYears(-age)) age--;
            return age;
        }
    }
}