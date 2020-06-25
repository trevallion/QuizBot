using QuizBot.UnityEvents;
using System.Collections.Generic;
using UnityEngine;

namespace QuizBot.UIControllers.BaseClasses
{
    /// <summary>
    /// Allows easy updating of a list of static UI components and fires an event when one of them is selected.
    /// </summary>
    /// <typeparam name="T">A list of type U. For inserting into the ContainerController. Do not implement Refresh(T) here because it would have to be boxed.</typeparam>
    /// <typeparam name="U">Data type consumed by the list's view.</typeparam>
    /// <typeparam name="V">Lists's view type.</typeparam>
    public abstract class SelectableListController<T, U, V> : UIController<T>
        where T : List<U>
        where V : MonoBehaviour
    {
        public UnityEventInt OnListItemSelected;

        [SerializeField]
        protected ContainerController<V, U> _containerController = null;

        // TODO: Add container controller functionality to this class and implement via SelectableListItems.
        protected abstract ContainerController<V, U> ContainerController { get; }

        [SerializeField]
        private List<SelectableListItem> _selectableListItems = new List<SelectableListItem>();

        private void Awake()
        {
            for (int i = 0; i < _selectableListItems.Count; ++i)
            {
                _selectableListItems[i].Initialize(i);
                _selectableListItems[i].OnListItemSelected.AddListener(SelectItem);
            }
        }

        public void SelectItem(int index)
        {
            OnListItemSelected?.Invoke(index);
        }

        public void ResetSelection()
        {
            foreach (var listItem in _selectableListItems)
            {
                listItem.SetToggleValue(false);
            }
        }

        public void SetListInteractable(bool isInteractable)
        {
            foreach (var listItem in _selectableListItems)
            {
                listItem.SetToggleInteractable(false);
            }
        }
    }
}