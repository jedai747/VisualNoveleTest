using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Visual.Novel.Frame;

namespace Frame.Convertor
{
    public class FrameDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(FrameData);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var type = jsonObject["Type"]?.ToString();

            FrameData frame = type switch
            {
                "Dialogue" => new DialogueFrameData(),
                "Text" => new TextFrameData(),
                "Choice" => new ChoiceFrameData(),
                "Final" => new FinalFrameData(),
                _ => throw new Exception("Unknown frame type: " + type)
            };

            serializer.Populate(jsonObject.CreateReader(), frame);
            return frame;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}