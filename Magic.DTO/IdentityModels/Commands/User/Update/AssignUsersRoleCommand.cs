namespace Magic.DTO.IdentityModels.Commands.User.Update;

    public class AssignUsersRoleCommand
    {
        public string UserName { get; set; }
        public IList<string> Roles { get; set;}
    }

