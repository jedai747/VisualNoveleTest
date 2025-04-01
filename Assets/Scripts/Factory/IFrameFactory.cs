using UnityEngine;

namespace Visual.Novel.Frame.Factory
{
    public interface IFrameFactory
    {
        string FrameType { get; }
        BaseFrame Create(Transform parent);
    }
}