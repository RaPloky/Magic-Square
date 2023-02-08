using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SumCounter : MonoBehaviour
{
    [SerializeField] private List<Square> _squares;

    private int _numSum;
    private TextMeshProUGUI _sumInfo;

    public int SquaresSum => _numSum;
    public static Action OnChangedNumber;

    private void OnEnable() => OnChangedNumber += CalculateNumSumInSquares;
    private void OnDisable() => OnChangedNumber -= CalculateNumSumInSquares;

    public static void SendOnChangedNumber() => OnChangedNumber?.Invoke();

    private void Start()
    {
        _sumInfo = GetComponent<TextMeshProUGUI>();
    }

    public void CalculateNumSumInSquares()
    {
        _numSum = 0;

        foreach (var magicSquare in _squares)
            _numSum += magicSquare.Number;

        _sumInfo.text = _numSum.ToString();
        GameController.Instance.CheckWinCondition();
    }
}
