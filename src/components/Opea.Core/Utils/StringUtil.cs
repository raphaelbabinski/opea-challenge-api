using System;
using System.Linq;
using System.Text;

namespace BX.Core.Utils
{
    public static class StringUtil
    {
        public static string TrimIfNotNull(this string value)
        {
            if (value != null) return value.Trim();

            return null;
        }
    }
}