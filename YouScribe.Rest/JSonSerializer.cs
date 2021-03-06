﻿using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouScribe.Rest
{
    internal class JSonSerializer : ISerializer
    {
        public T Deserialize<T>(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize<T>(T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, new IsoDateTimeConverter() { DateTimeFormat = @"yyyy-MM-dd\THH:mm:ss.FFFFFFF\Z",
                DateTimeStyles = System.Globalization.DateTimeStyles.AdjustToUniversal });
        }
    }
}
