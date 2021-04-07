using RestWithAspNET.Data.VO;
using RestWithAspNET.Models;

namespace RestWithAspNET.Repositories
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
    }
}