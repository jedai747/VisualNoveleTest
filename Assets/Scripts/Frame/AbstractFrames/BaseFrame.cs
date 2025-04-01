using UnityEngine;

namespace Visual.Novel.Frame
{
    public abstract class BaseFrame : MonoBehaviour, IFrame
    {
        public FrameData FrameData { get; private set; }
        protected FrameController FrameController;

        public virtual void Show(FrameData data, FrameController controller)
        {
            FrameData = data;
            FrameController = controller;
            gameObject.SetActive(true);
            SubscribeTap();
        }

        public virtual void Hide()
        {
            UnsubscribeTap();
            Destroy(gameObject);
        }
        protected virtual void SubscribeTap() { }
        protected virtual void UnsubscribeTap() { }
    }
}