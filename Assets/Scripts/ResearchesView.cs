using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResearchesView : MonoBehaviour
{
    [SerializeField]
    private ResearchesData _data;
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private TMP_Text _description;
    [SerializeField]
    private Button _descriptionResearchButton;
    [SerializeField]
    private ResearchButton _researchButton;

    private void Start()
    {
        _researchButton = GameObject.FindGameObjectWithTag("ResearchButton").GetComponent<ResearchButton>();
        _descriptionResearchButton.onClick.AddListener(InitializeResearch);
    }

    public void InitializeResearch()
    {
        _researchButton.SetResearch(_data, gameObject.GetComponent<Button>());
        _label.text = _data.ResearchName;
        _description.text = _data.ResearchDescription;
    }
}
