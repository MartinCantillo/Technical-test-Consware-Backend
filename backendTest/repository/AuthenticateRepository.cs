

using BackendTest.Models;

namespace BackendTest.repository
{
    public interface AuthenticateRepository
    {

        public string GenerateToken(int id, string username);
        public User ValidateUser(string user, string password);
    }

}