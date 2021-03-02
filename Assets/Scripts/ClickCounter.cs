using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ClickCounter : MonoBehaviour
{
    public int value;
    public Text counterText;

    public void Increment()
    {
        value += 1;
        counterText.text = value.ToString();
    }
}

