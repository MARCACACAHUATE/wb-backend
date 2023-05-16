using wb_backend.Models;
using wb_backend.Tools.Request;

namespace wb_backend.Services;

public interface IUserServices {
    User NewUser(UserRequest request);
    List<User> GetUserList();
    User GetUserById(int id);
}