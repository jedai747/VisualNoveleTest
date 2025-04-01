using System.Collections.Generic;
using Newtonsoft.Json;
using Visual.Novel.Frame;

namespace Frame.Convertor
{
    public class FrameLoader
    {
        public static List<FrameData> Load(string json)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new FrameDataConverter());
            var wrapper = JsonConvert.DeserializeObject<FrameListWrapper>(json, settings);
            return wrapper.Frames;
        }
    }

    [System.Serializable]
    public class FrameListWrapper
    {
        public List<FrameData> Frames;
    }
}