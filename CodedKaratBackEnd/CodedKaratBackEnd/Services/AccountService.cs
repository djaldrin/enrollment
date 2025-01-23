using CodedKaratBackEnd.Data;
using CodedKaratBackEnd.Models;
using CodedKaratBackEnd.Services;
using MongoDB.Driver;

public class AccountService : IAccountService
{
    private readonly IMongoCollection<Account> _accounts;

    public AccountService(MongoDbService mongoDbService)
    {
        _accounts = mongoDbService.Database.GetCollection<Account>("account");
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var filter = Builders<Account>.Filter.Eq(a => a.Email, email);
        var account = await _accounts.Find(filter).FirstOrDefaultAsync();

        if (account == null)
        {
            return false; 
        }

      
        return account.PasswordHash == password; 
    }

    public async Task<bool> CreateAccountAsync(AccountRequestModel accountRequest)
    {
        var existingAccount = await _accounts.Find(a => a.Email == accountRequest.Email).FirstOrDefaultAsync();
        if (existingAccount != null)
        {
            return false; 
        }

        var account = new Account
        {
            Email = accountRequest.Email,
            PasswordHash = accountRequest.Password 
        };

        await _accounts.InsertOneAsync(account);
        return true;
    }
}