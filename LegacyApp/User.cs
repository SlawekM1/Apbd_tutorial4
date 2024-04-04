using System;

namespace LegacyApp
{
    public class User
    {
        public Client Client { get; }
        public DateTime DateOfBirth { get; }
        public string EmailAddress { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public User(Client client, string firstName, string lastName, string emailAddress, DateTime dateOfBirth)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            DateOfBirth = dateOfBirth;
        }
    }
}