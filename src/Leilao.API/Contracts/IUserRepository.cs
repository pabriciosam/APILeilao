using Leilao.API.Entities;

namespace Leilao.API.Contracts;

public interface IUserRepository
{
    bool ExisteUserEmail(string email);
    User GetUserByEmail(string email);
}