namespace Magic.DTO.IdentityModels.Commands.Auth;

    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }

