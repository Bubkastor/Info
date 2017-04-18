using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Info.Models
{
    public class Helper
    {
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
