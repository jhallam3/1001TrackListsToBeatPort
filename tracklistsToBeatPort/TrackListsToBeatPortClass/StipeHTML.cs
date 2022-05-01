using System;
using System.Text.RegularExpressions;

namespace TrackListsToBeatPortClass
{
    public class Strip
    {
        public string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}