using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace test.Middleware
{
    public class Jump404Middleware
    {
        private readonly RequestDelegate next;
        //new FileStream("../test/wwwroot/index.html", FileMode.Open)
        private readonly string fsRead = File.ReadAllText("../test/wwwroot/index.html");

        public Jump404Middleware(RequestDelegate next)
        {
            this.next = next;
        }
      

        public async Task Invoke(
            Microsoft.AspNetCore.Http.HttpContext context)
        {
            await next.Invoke(context);

            var response = context.Response;
            if (context.Request.Path.ToString().Contains("/api")) {
            }
            else
            {
                //如果是404就跳转到主页
                if (response.StatusCode == 404)
                {
                    response.WriteAsync(fsRead);
                }

            }
        }
    }
}
