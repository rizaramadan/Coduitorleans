﻿namespace Grains.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    //https://stackoverflow.com/questions/2920744/url-slugify-algorithm-in-c
    //https://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
    public static class Slug
    {
        public static string GenerateSlug(this string phrase)
        {
            IdnMapping idn = new IdnMapping();
            string punyCode = idn.GetAscii(phrase);
            return punyCode?.Replace(' ','-')?.ToLower();
        }

        public static string RemoveDiacritics(this string text)
        {
            var s = new string(text.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());

            return s.Normalize(NormalizationForm.FormC);
        }
    }
}
