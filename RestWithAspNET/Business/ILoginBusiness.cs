using RestWithAspNET.Data.VO;

namespace RestWithAspNET.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
    }
}