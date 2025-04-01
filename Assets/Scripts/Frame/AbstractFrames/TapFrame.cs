namespace Visual.Novel.Frame
{
    public abstract class TapFrame : BaseFrame
    {
        private TapCatcher _tapCatcher;

        public override void Show(FrameData data, FrameController controller)
        {
            base.Show(data, controller);
            if (_tapCatcher == null)
                _tapCatcher = gameObject.AddComponent<TapCatcher>();

            _tapCatcher.OnTap += HandleTap;
        }

        public override void Hide()
        {
            if (_tapCatcher != null)
                _tapCatcher.OnTap -= HandleTap;

            base.Hide();
        }

        protected virtual void HandleTap()
        {
            FrameController.ShowNextFrame();
        }
    }
}