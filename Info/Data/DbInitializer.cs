﻿using System;
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
            //comment if you dont have drop base
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (context.Apps.Any())
            {
                return;
            }
            context.Users.Add(
                new User { Name = "Admin", Login = "Admin", Pass = "Admin", Avatar = "/images/admin.png" });
            context.SaveChanges();

            var apps = new App[]
            {
                new App{ Icon = "/images/Skype.webp", Name = "Skype", Platform = AppPlatform.Android, UrlMarket = "https://play.google.com/store/apps/details?id=com.skype.raider&hl=ru"},
                new App{ Icon = "/images/vk.webp", Name = "Вконтакте", Platform = AppPlatform.Android, UrlMarket = "https://play.google.com/store/apps/details?id=com.vkontakte.android&hl=ru"},
                new App{ Icon = "/images/WhatsApp.webp", Name = "WhatsApp Messenger", Platform = AppPlatform.Android, UrlMarket = "https://play.google.com/store/apps/details?id=com.whatsapp"},
                new App{ Icon = "/images/sber.webp", Name = "Сбербанк Онлайн", Platform = AppPlatform.Android, UrlMarket = "https://play.google.com/store/apps/details?id=ru.sberbankmobile"},
                new App{ Icon = "/images/Instagram.webp", Name = "Instagram", Platform = AppPlatform.Android, UrlMarket = "https://play.google.com/store/apps/details?id=com.instagram.android"}
            };

            foreach (App app in apps)
            {
                context.Apps.Add(app);
            }
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
