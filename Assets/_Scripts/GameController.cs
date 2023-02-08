using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] private List<SumCounter> _inlineCounters;
    [SerializeField] private GameObject _winPanel;

    [Header("Clear info")]
    [SerializeField] private List<TMP_InputField> _inputFields;
    [SerializeField] private List<Square> _squares;
    [SerializeField] private List<TextMeshProUGUI> _sumsList;

    public static GameController Instance;

    private readonly int _inlineTarget = 15;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckWinCondition()
    {
        foreach (var inlineCounter in _inlineCounters)
        {
            if (inlineCounter.SquaresSum != _inlineTarget)
                return;
        }
        WinGame();
    }

    private void WinGame()
    {
        _winPanel.SetActive(true);
    }

    public void ClearInputFields()
    {
        foreach (var field in _inputFields)
            field.text = string.Empty;

        foreach (var square in _squares)
            square.Number = 0;

        foreach (var squaresSum in _sumsList)
            squaresSum.text = string.Empty;
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
