using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SportCenter.Infrastructure
{
    public class UserBasedLayoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            // Controller'dan kullanıcı oturum bilgisini al
            var httpContext = context.HttpContext;
            var controller = context.Controller as Controller;

            if (controller != null && httpContext.Session.GetInt32("UserId") != null)
            {
                // Kullanıcı tipine göre layout belirle
                var userType = httpContext.Session.GetInt32("UserType");
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

                // Controller'ın ViewData'sına layout bilgisini ekle
                controller.ViewData["Layout"] = layoutName;
            }
        }
    }
} 