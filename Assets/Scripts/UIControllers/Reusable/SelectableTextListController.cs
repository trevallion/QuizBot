using QuizBot.UIControllers.BaseClasses;
using System.Collections.Generic;
using TMPro;

namespace QuizBot.UIControllers.Reusable
{
    /// <summary>
    /// Concrete implementation of SelectableListController. Inserts a List<string> into a TextController.
    /// </summary>
    public class SelectableTextListController : SelectableListController<List<string>, string, TMP_Text>
    {
        public override void Refresh(List<string> data)
        {
            ResetSelection();
            _containerController.Refresh(data.ToArray());
        }
    }
}