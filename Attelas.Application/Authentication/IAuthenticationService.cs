namespace Attelas.Application.Authentication;

public interface IAuthenticationService
{
    LoginResponse Authenticate(LoginRequest loginRequest);
}