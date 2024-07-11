namespace Magic.DTO.IdentityModels.Commands.User.Update;

    public class UpdateUserRolesCommand
    {
        public string userName { get; set; }
        public IList<string> Roles { get; set;}
    }
