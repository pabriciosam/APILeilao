using Leilao.API.Contracts;
using Leilao.API.Entities;
using System.Text;

namespace Leilao.API.Services;

public class LoggerUser : ILoggerUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;

    public LoggerUser(IHttpContextAccessor httpContext, IUserRepository repository)
    {
        _httpContextAccessor = httpContext;

        _repository = repository;
    }

    public User User()
    {
        var token = TokenOnRequest();
        var email = FromBase64String(token);

        return _repository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return Encoding.UTF8.GetString(data);
    }
}
