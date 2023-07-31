namespace FunChat.Application.Services.Implementations
{
    public interface IViewRenderService
    {
        string RenderToStringAsync(string viewName, object model);
    }
}
