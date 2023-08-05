namespace FunChat.Application.Generators
{
    public static class Generators
    {
        public static string GetEmailActivationCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");

        }

        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}