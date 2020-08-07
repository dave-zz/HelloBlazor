using System;
using System.Collections.Generic;
using System.Text;

namespace HelloBlazor.Common.Model
{
    public class LanguageSelection
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }

    public static class AvailableLanguages
    {
        public static List<LanguageSelection> GetLanguages() =>
            new List<LanguageSelection>
            {
                new LanguageSelection { Code= "en", Name="EN" },
                new LanguageSelection { Code= "fr", Name="FR" },
                new LanguageSelection { Code= "it", Name="IT" },
                new LanguageSelection { Code= "es", Name="ES" }
            };
    }
}
