using TMPro;
using UnityEngine;

public class Square : MonoBehaviour
{
    private int _number;

    public int Number { get => _number; set => _number = value; }

    public void AssignNumber(TMP_InputField input)
    {
        var num = int.Parse(input.text);
        _number = num;
        SumCounter.SendOnChangedNumber();
    }
}
