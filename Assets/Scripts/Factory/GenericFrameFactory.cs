using UnityEngine;

namespace Visual.Novel.Frame.Factory
{
    public class GenericFrameFactory<T> : IFrameFactory where T : BaseFrame
    {
        private readonly string _resourcePath;
        public string FrameType { get; }

        public GenericFrameFactory(string frameType, string resourcePath)
        {
            FrameType = frameType;
            _resourcePath = resourcePath;
        }

        public BaseFrame Create(Transform parent)
        {
            return Object.Instantiate(Resources.Load<T>(_resourcePath), parent);
        }
    }
}