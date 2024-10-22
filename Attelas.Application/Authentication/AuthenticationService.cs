namespace Attelas.Application.Authentication;

internal class AuthenticationService : IAuthenticationService
{
    public LoginResponse Authenticate(LoginRequest loginRequest)
    {
        var loginName = loginRequest.LoginName;
        var password = loginRequest.Password;

        if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(password))
            throw new ArgumentException("LoginName or Password is can not be empty");

        if (loginName == "admin" && password == "password")
            return new LoginResponse()
            {
                Success = true, Data = new Token()
                {
                    AccessToken = "1234567890",
                    RefreshToken = "abcdefghij"
                }
            };
        else
            return new LoginResponse() { Success = false, Data = null! };
    }
}