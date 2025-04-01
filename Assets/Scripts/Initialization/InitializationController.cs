using UnityEngine;
using Visual.Novel.Frame;
using Visual.Novel.Frame.Factory;

namespace Visual.Novel.Initialization
{
    public class InitializationController : MonoBehaviour
    {
        [SerializeField]
        private FrameController _frameController;
        private void Start()
        {
            FrameFactory.Register(new GenericFrameFactory<DialogueFrame>("Dialogue", "UI/DialogueFrame"));
            FrameFactory.Register(new GenericFrameFactory<TextFrame>("Text", "UI/TextFrame"));
            FrameFactory.Register(new GenericFrameFactory<ChoiceFrame>("Choice", "UI/ChoiceFrame"));
            FrameFactory.Register(new GenericFrameFactory<FinalFrame>("Final", "UI/FinalFrame"));
            _frameController.Init();
        }
    }
}