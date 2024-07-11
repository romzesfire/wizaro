namespace Magic.DTO.IdentityModels.Commands.User.Update;

    public class EditUserProfileCommand
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }

