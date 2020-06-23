using QuizBot.UIControllers.BaseClasses;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuizBot.UIControllers.Reusable
{
    /// <summary>
    /// Concrete implementation of SelectableListController. Inserts a List<string> into a TextController.
    /// </summary>
    public class SelectableTextListController : SelectableListController<List<string>, string, TMP_Text>
    {
        [SerializeField]
        protected TextController _textListContainerController = null;

        protected override ContainerController<TMP_Text, string> ContainerController => _textListContainerController;

        public override void Refresh(List<string> data)
        {
            ResetSelection();
            ContainerController.Refresh(data.ToArray());
        }
    }
}