using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/SO/BoolSO", fileName = "BoolSO")]
public class BoolSO : ScriptableObject
{
    public bool state = false;
    public void setTrue()
    {
        state = true;
    }
    public void setFalse()
    {
        state = false;
    }
}