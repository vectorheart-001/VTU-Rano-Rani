namespace ApiProject.Api.Authentication.TokenGenerators
{
    public class AuthenticationConfiguration
    {
        public string AccessTokenSecret { get; set; }
        public double AccessTokenExpepirationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string RefreshTokenSecret { get; set; }
        public double RefreshTokenExpepirationMinutes { get; set; }
    }
}
