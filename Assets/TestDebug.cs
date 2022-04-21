using UnityEngine;

public class TestDebug : MonoBehaviour
{
    void Awake()
    {
        Debug.Log(Tester.Asset.testInt);
    }
}