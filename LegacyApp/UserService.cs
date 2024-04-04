using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserCreditService _userCreditService;
        private readonly UserValidator _userValidator;

        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService, UserValidator userValidator)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _userCreditService = userCreditService ?? throw new ArgumentNullException(nameof(userCreditService));
            _userValidator = userValidator ?? throw new ArgumentNullException(nameof(userValidator));
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_userValidator.ValidateName(firstName, lastName) ||
                !_userValidator.ValidateEmail(email) ||
                !_userValidator.ValidateAge(dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);
            var user = new User(client, firstName, lastName, email, dateOfBirth);
            AssignCreditLimit(user, client.Type);

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user); 
            return true;
        }

        private void AssignCreditLimit(User user, string clientType)
        {
            switch (clientType)
            {
                case "VeryImportantClient":
                    user.HasCreditLimit = false;
                    break;
                case "ImportantClient":
                    user.HasCreditLimit = true;
                    user.CreditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth) * 2;
                    break;
                default:
                    user.HasCreditLimit = true;
                    user.CreditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    break;
            }
        }
    }
}
