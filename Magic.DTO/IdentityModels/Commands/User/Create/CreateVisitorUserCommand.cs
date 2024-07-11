namespace Magic.DTO.IdentityModels.Commands.User.Create;

    public class CreateVisitorUserCommand
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
    }
