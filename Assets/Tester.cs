using System;
using System.Collections;
using System.Collections.Generic;
using GG.ScriptableDataAsset;
using UnityEngine;

[ScriptableDataAssetSettings("","testDataAsset")]
public class Tester : ScriptableDataAsset<Tester>
{
    public int testInt = 10;

    protected override void OnCreated()
    {
        base.OnCreated();
        testInt = 50;
    }

    protected override void OnLoaded()
    {
        base.OnLoaded();
        Debug.Log(testInt);
    }
}