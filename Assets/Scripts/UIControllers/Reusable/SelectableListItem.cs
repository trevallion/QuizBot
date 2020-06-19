using QuizBot.UnityEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Allows initialization of list item via code and control over list item toggle status.
/// </summary>
public class SelectableListItem : MonoBehaviour
{
    private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public UnityEventInt OnListItemSelected;

    [SerializeField]
    private Toggle _listItemToggle = null;

    [SerializeField]
    private TMP_Text _listItemLabel = null;

    private int ListIndex { get; set; }

    public void SetToggle(bool newValue)
    {
        _listItemToggle.SetIsOnWithoutNotify(newValue);
    }

    public void OnToggleClicked(bool isOn)
    {
        if (isOn)
        {
            OnListItemSelected?.Invoke(ListIndex);
        }
    }

    public void Initialize(int index)
    {
        ListIndex = index;

        // Label could be enumerated instead of lettered if we added extra options here.
        if (index < letters.Length)
        {
            _listItemLabel.text = letters[index].ToString();
        }
    }
}
