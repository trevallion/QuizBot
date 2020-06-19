using QuizBot.UIControllers.BaseClasses;
using TMPro;

namespace QuizBot.UIControllers.Reusable
{
    public class TextController : ContainerController<TMP_Text, string>
    {
        protected override void FillContainer(TMP_Text container, string data)
        {
            container.text = data;
        }
    }
}