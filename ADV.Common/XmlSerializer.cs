using System;
using System.IO;
using System.Xml.Serialization;

namespace ADV.Common
{
    public class XmlSerializeHelper
    {
        /// <summary>
        /// Deserialize xml to T objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rawXml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string rawXml)
        {
            if (string.IsNullOrEmpty(rawXml))
                throw new ArgumentNullException("Input xml data coudn't be empty!");

            var deserializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(rawXml))
            {
                var obj = deserializer.Deserialize(reader);
                reader.Close();
                return (T)obj;
            }
        }
    }
}
