using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CachMangVoz
{
    public class TextExtracter
    {
        public static string GetJsonValue(string text, string name)
        {
            var tagStart = string.Format("\"{0}\":\"", name);
            var tagEnd = "\"";
            return ExtractText(text, tagStart, tagEnd);
        }

        public static string ExtractText(string text, string tagStart, string tagEnd)
        {
            var startIndex = text.IndexOf(tagStart);
            var endIndex = text.IndexOf(tagEnd, startIndex + tagStart.Length);

            if (startIndex >= 0 && endIndex > 0)
            {
                startIndex += tagStart.Length;
                var result = text.Substring(startIndex, endIndex - startIndex);

                return result;
            }

            return string.Empty;
        }
    }
}
