using wb_backend.Models;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;

namespace wb_backend.Services;

public interface IUserServices {
    User NewUser(UserRequest request);
    List<User> GetUserList();
    User GetUserById(int id);
    User ModifyUser(int id, UserModifyRequest request);
    AuthenticateResponse AuthUser(string email, string password);
}