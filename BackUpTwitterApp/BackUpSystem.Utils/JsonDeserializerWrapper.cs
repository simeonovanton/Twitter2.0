﻿using BackUpSystem.DTO;
using BackUpSystem.Utilities.Contracts;
using Bytes2you.Validation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BackUpSystem.Utils
{
    /// <summary>
    /// Abstracts Newtonsoft Json Deserializer in order to be testable
    /// </summary>
    public class JsonDeserializerWrapper : IJsonObjectDeserializer
    {
        /// Deserializes the JSON to the User DTO type - wrapper instance method.
        /// </summary>
        /// <param name="jsonText">The JSON to be deserialized.</param>
        /// <returns>User Dto</returns>
        public Т Deserialize<Т>(string jsonUserText)
        {
            Guard.WhenArgument(jsonUserText, "Deserialize").IsNullOrEmpty().Throw();

            return JsonConvert.DeserializeObject<Т>(jsonUserText,
                new IsoDateTimeConverter { DateTimeFormat = "ddd MMM dd HH:mm:ss zzz yyyy" });
        }
    }
}
