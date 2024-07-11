using System.Security.Claims;
using Magic.Domain;
using Magic.DTO.IdentityModels;
using Magic.DTO.IdentityModels.Commands.Auth;
using Magic.DTO.IdentityModels.Commands.User.Create;
using Magic.DTO.IdentityModels.Commands.User.Update;
using Refit;

namespace Magic.DTO.Interfaces.API;

public interface IIdentityApi
{
    [Post("api/Auth/Login")]
    public Task<AuthResponseDTO> Login(AuthCommand command);

    [Post("api/Auth/CheckAuthorization")]
    public Task<ClaimsPrincipal> Login();

    [Get("api/Auth/RefreshTokens")]
    public Task<RefreshResponseDTO> RefreshTokens(RefreshTokenCommand command);
    
    
    [Post("api/User/Create")]
    public Task<int> CreateUser(CreateUserCommand command);

    [Post("api/User/CreateVisitor")]
    public Task<int> CreateVisitorUser(CreateVisitorUserCommand command);

    [Get("api/User/GetAll")]
    public Task<List<UserResponseDTO>> GetAllUserAsync();

    [Delete("api/User/Delete/{userId}")]
    public Task<int> DeleteUser(string userId);

    [Get("api/User/GetUserDetails/{userId}")]
    public Task<UserDetailsResponseDTO> GetUserDetails(string userId);

    [Get("api/User/GetUserDetailsByUserName/{userName}")]
    public Task<UserDetailsResponseDTO> GetUserDetailsByUserName(string userName);

    [Post("api/User/AssignRoles")]
    public Task<int> AssignRoles(AssignUsersRoleCommand command);

    [Put("api/User/EditUserRoles")]
    public Task<int> EditUserRoles(UpdateUserRolesCommand command);

    [Get("api/User/GetAllUserDetails")]
    public Task<UserDetailsResponseDTO> GetAllUserDetails();

    [Put("api/User/EditUserProfile/{id}")]
    public Task<int> EditUserProfile(string id, EditUserProfileCommand command);


    [HttpPost("api/Role/Create")]
    [ProducesDefaultResponseType(typeof(int))]

    public async Task<int> CreateRoleAsync(RoleCreateCommand command);

    [HttpGet("api/Role/GetAll")]
    [ProducesDefaultResponseType(typeof(List<RoleResponseDTO>))]
    public async Task<IActionResult> GetRoleAsync();


    [HttpGet("api/Role/{id}")]
    [ProducesDefaultResponseType(typeof(RoleResponseDTO))]
    public async Task<IActionResult> GetRoleByIdAsync(string id);

    [HttpDelete("api/Role/Delete/{id}")]
    [ProducesDefaultResponseType(typeof(int))]
    public async Task<IActionResult> DeleteRoleAsync(string id);

    [HttpPut("api/Role/Edit/{id}")]
    [ProducesDefaultResponseType(typeof(int))]
    public async Task<ActionResult> EditRole(string id, [FromBody] UpdateRoleCommand command);
}