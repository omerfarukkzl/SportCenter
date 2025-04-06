using Microsoft.AspNetCore.Mvc.Razor;

namespace SportCenter.Infrastructure
{
    public class LayoutMiddleware
    {
        private readonly RequestDelegate _next;

        public LayoutMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Kullanıcı oturum açmış mı kontrol et
            if (context.Session.GetInt32("UserId") != null)
            {
                // Kullanıcı tipine göre layout belirle
                var userType = context.Session.GetInt32("UserType");
                string layoutName = "_Layout"; // Varsayılan layout

                switch (userType)
                {
                    case 1: // Yönetici
                        layoutName = "_AdminLayout";
                        break;
                    case 2: // Antrenör
                        layoutName = "_TrainerLayout";
                        break;
                    case 3: // Üye
                        layoutName = "_MemberLayout";
                        break;
                }

                // ViewData dictionary'sine layout bilgisini ekle
                if (context.Items.ContainsKey("ViewData"))
                {
                    var viewData = context.Items["ViewData"] as dynamic;
                    if (viewData != null)
                    {
                        viewData["Layout"] = layoutName;
                    }
                }
                else
                {
                    // Özel bir durum, normalde ViewData zaten olmalı
                    context.Items["Layout"] = layoutName;
                }
            }

            await _next(context);
        }
    }

    // Extension method to add the middleware to the pipeline
    public static class LayoutMiddlewareExtensions
    {
        public static IApplicationBuilder UseLayoutMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LayoutMiddleware>();
        }
    }
} 