using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Info.Models;

namespace Info.Data
{
    public class DbInitializer
    {
        public static void Initialize(InfoContext context)
        {
            context.Database.EnsureCreated();
            if (context.Apps.Any())
            {
                return;
            }

            var apps = new App[]
            {
                new App{ ID = 1, Icon = "/images/Skype.png", Name = "Skype", Platform = AppPlatform.Android, UrlMarket = "https://play.google.com/store/apps/details?id=com.skype.raider&hl=ru"},
                new App{ ID = 2, Icon = "/images/Вконтакте.png", Name = "Вконтакте", Platform = AppPlatform.Android, UrlMarket = "https://play.google.com/store/apps/details?id=com.vkontakte.android&hl=ru"},
                new App{ ID = 3, Icon = "/images/WhatsApp.png", Name = "WhatsApp Messenger", Platform = AppPlatform.Android, UrlMarket = "https://play.google.com/store/apps/details?id=com.whatsapp"},
                new App{ ID = 4, Icon = "/images/Сбербанк.png", Name = "Сбербанк Онлайн", Platform = AppPlatform.Android, UrlMarket = "https://play.google.com/store/apps/details?id=ru.sberbankmobile"},
                new App{ ID = 5, Icon = "/images/Instagram.png", Name = "Instagram", Platform = AppPlatform.Android, UrlMarket = "https://play.google.com/store/apps/details?id=com.instagram.android"}
            };

            foreach (App app in apps)
            {
                context.Apps.Add(app);
            }
            context.SaveChanges();

            context.Users.Add(
                new User { ID = 1, Name = "Admin", Login = "Admin", Pass = "Admin", Avatar = "/images/admin.png" });
            context.SaveChanges();

            var data = DateTime.Now;
            var articles = new Article[] {
                new Article{ AppID = context.Apps.Where(app => app.Name == "Skype").First() , UserID = context.Users.First(), Like = 0, Description="Обновление", Title="Skype получил обновлние", ReleaseDate = data, Content = "Обновился интерфейс" }
            };
            foreach (var article in articles)
            {
                context.Articles.Add(article);
            }
            context.SaveChanges();
        }
    }
}
