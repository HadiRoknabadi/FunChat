namespace FunChat.Application.Generators
{
    public static class Generators
    {
        public static string GetEmailActivationCode()
        {
            return Guid.NewGuid().ToString().Replace("-","");
            
        }
    }
}