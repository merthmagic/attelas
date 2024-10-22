namespace Attelas.Application.Authentication;

public class LoginResponse : ClientObject<Token>
{
    
}


public  class Token
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}