using System;
using System.Globalization;

namespace ADV.Common
{
    public static class DateHelper
    {
        /// <summary>
        /// Helps to deserialize data from specified format
        /// </summary>
        /// <param name="string">Stringed data</param>
        /// <param name="format">Data format</param>
        /// <returns></returns>
        public static DateTime? GetDeserializedDateTime(this string @string, string format)
        {
            if (string.IsNullOrEmpty(@string))
                //return null;
                return default(DateTime);
            
            var val = @string;
            if (@string.Contains(" "))
                val = @string.Split(' ')[0];
            return DateTime.ParseExact(val, format, CultureInfo.InvariantCulture);
        }

    }
}
