namespace ApiProject.Api.Authentication.TokenGenerators
{
    public class AuthenticatedResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
