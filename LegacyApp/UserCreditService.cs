using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class UserCreditService : IUserCreditService
    {
        private readonly Dictionary<string, int> _creditLimitDatabase = new Dictionary<string, int>
        {
            {"Kowalski", 200},
            {"Malewski", 20000},
            {"Smith", 10000},
            {"Doe", 3000},
            {"Kwiatkowski", 1000}
            // Other clients as necessary...
        };

        public int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            SimulateDelay();

            if (_creditLimitDatabase.TryGetValue(lastName, out int creditLimit))
            {
                return creditLimit;
            }

            throw new ArgumentException($"Credit limit for the client with last name '{lastName}' does not exist.");
        }

        private void SimulateDelay()
        {
            int randomWaitingTime = new Random().Next(3000);
            Thread.Sleep(randomWaitingTime);
        }
    }
}