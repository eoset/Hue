using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Hue.Middlewares
{
    public class AuthenticationMiddleWare
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleWare(RequestDelegate _next)
        {
            this._next = _next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];

            if(authHeader != null && authHeader.StartsWith("Basic"))
            {
                string encodedUserNamePassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string userNamePassword = encoding.GetString(Convert.FromBase64String(encodedUserNamePassword));

                int separatorIndex = userNamePassword.IndexOf(":");

                var userName = userNamePassword.Substring(0, separatorIndex);
                var password = userNamePassword.Substring(separatorIndex + 1);

                if (userName == "erik" && password == "Kattbajs@321")
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                return;
            }
        }
    }
}
