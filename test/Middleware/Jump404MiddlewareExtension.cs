using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Middleware
{
    public static class Jump404MiddlewareExtension
    {
        public static void UseJump404(this IApplicationBuilder app)
        {
            app.UseMiddleware<Jump404Middleware>();
        }
    }
}
