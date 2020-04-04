﻿using Newtonsoft.Json;
using System;

namespace Kraken.WebSockets.Converters
{
    /// <summary>
    /// Specialized converter for <see cref="OrderType"/>
    /// </summary>
    /// <seealso cref="JsonConverter" />
    internal sealed class OrderTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) 
            => objectType == typeof(OrderType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            return (enumString.ToLower()) switch
            {
                "limit" => OrderType.Limit,
                "market" => OrderType.Market,
                _ => throw new ArgumentOutOfRangeException(nameof(reader.Value)),
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                return;
            }

            writer.WriteValue(Enum.GetName(typeof(OrderType), value).ToLower());
        }
    }
}
