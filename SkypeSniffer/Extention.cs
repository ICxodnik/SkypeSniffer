using SKYPE4COMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkypeSniffer
{
    public static class Extention
    {
        public static string GetCorrectName(this User user)
        {
            return new string[] { user.DisplayName, user.FullName, user.Handle }.First(x => x != "");
        }


        public static string ToInfoString(this User user)
        {
            return $"{user.Handle}|{DateTime.Now}|{user.OnlineStatus}|{user.LastOnline}";
        }
    }
}
