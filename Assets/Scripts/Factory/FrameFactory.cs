using System.Collections.Generic;
using UnityEngine;

namespace Visual.Novel.Frame.Factory
{
    public static class FrameFactory
    {
        private static readonly Dictionary<string, IFrameFactory> _factories = new();

        public static void Register(IFrameFactory factory)
        {
            if (!_factories.TryAdd(factory.FrameType, factory))
                Debug.LogWarning($"Factory for type {factory.FrameType} already registered.");
        }

        public static BaseFrame CreateFrame(FrameData data, Transform parent)
        {
            if (_factories.TryGetValue(data.Type, out var factory))
            {
                return factory.Create(parent);
            }

            Debug.LogError($"Unknown frame type: {data.Type}");
            return null;
        }
    }
}