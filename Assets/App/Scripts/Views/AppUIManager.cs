using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

[Serializable]
public class AppUIManager
{
    [SerializeField] Text versionLabel;
    public void SetVersion(string v)
    {
        versionLabel.text = v;
    }
}
