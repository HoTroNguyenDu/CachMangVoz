using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CachMangVoz
{
    public class AccountExtracter
    {
        public static List<VozAccount> ExtractAccount(string rawText)
        {
            var lines = rawText.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            lines = lines.Select(l => l.Trim())
                        .ToArray();

            return lines.Select(l => l.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries))
                           .Where(i => i.Length == 2)
                           .Select(i => new VozAccount { Username = i[0], Password = i[1] })
                           .ToList();
        }
    }
}
