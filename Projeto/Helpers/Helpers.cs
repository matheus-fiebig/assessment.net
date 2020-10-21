using Microsoft.Extensions.Primitives;

namespace Projeto.Helpers
{
    public static class Helpers
    {
        public static string GetToken(StringValues value)
        {
            var splitValue = value.ToString().Split(';');
            var token = splitValue[0].Split('=');
            
            return token[1];
        }
    }
}