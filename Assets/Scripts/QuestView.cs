using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestView : MonoBehaviour
{
    [SerializeField]
    private QuestData _data;
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private TMP_Text _description;
    [SerializeField]
    private Button _descriptionQuestButton;
    [SerializeField]
    private QuestButton _questButton;

    private void Start()
    {
        _questButton = GameObject.FindGameObjectWithTag("QuestButton").GetComponent<QuestButton>();
        _descriptionQuestButton.onClick.AddListener(InitializeQuest);
    }

    public void InitializeQuest()
    {
        _questButton.SetQuest(_data, gameObject.GetComponent<Button>());
        _label.text = _data.QuestName;
        _description.text = _data.QuestDescription;
    }
}
