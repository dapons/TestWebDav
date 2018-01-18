using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAppDomain.Extensions
{
    public static class StringExtensions
    {
        public static int? ConvertToInt(this string input)
        {
            if (!int.TryParse(input, out var value))
            {
                return null;
            }

            return value;
        }
    }
}
