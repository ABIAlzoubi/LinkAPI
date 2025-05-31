using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.Utils
{
    public static class CheckStringEmpty
    {
        public static bool IsEmptyOrPlaceholder(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return true;

            var placeholders = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "string", "0" };
            return placeholders.Contains(value);
        }
    }
}
