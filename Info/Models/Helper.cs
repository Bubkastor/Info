using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Info.Models
{
    public class Helper
    {
        static public AppPlatform GetPlatform(string platform)
        {
            switch (platform.ToLower())
            {
                case "android":
                    return AppPlatform.Android;
                case "ios":
                    return AppPlatform.Ios;
                case "windows":
                    return AppPlatform.Windows;
                default:
                    return AppPlatform.Android;
            }
        }
        static public string GetPlatformIcon(AppPlatform platform)
        {
            switch (platform)
            {
                case AppPlatform.Android:
                    return "Android";
                case AppPlatform.Ios:
                    return "Ios";
                case AppPlatform.Windows:
                    return "Windows";
                default:
                    return "";
            }
        }
    }
}
