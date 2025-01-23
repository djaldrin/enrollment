using CodedKaratBackEnd.Models;

namespace CodedKaratBackEnd.Services
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string email, string password);
        Task<bool> CreateAccountAsync(AccountRequestModel accountRequest);
    }
}
