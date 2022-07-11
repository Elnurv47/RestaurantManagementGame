using System;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDialogUI : MonoBehaviour
{
    public static QuestionDialogUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();
    }

    [SerializeField] private Text _questionText;
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    public void AskQuestion(string question, Action yesAction, Action noAction)
    {
        _yesButton.onClick.RemoveAllListeners();
        _noButton.onClick.RemoveAllListeners();

        Show();

        _questionText.text = question;
        _yesButton.onClick.AddListener(() =>
        {
            Hide();
            yesAction();
        });

        _noButton.onClick.AddListener(() =>
        {
            Hide();
            noAction();
        });
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
