using UnityEngine;
using System.Collections;

public class ErrorHandler : MonoBehaviour
{
    public GameObject ErrorScreen;
    public GameObject ExcellentScreen;

    public static GameObject Error { get; private set; }
    public static GameObject Excellent { get; private set; }

    void Start()
    {
        Error = ErrorScreen;
        Excellent = ExcellentScreen;
    }
}
