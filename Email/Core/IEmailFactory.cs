namespace Dotnet.Services.Email.Core
{
    public interface IEmailFactory
    {
        IEmail Create();
    }
}