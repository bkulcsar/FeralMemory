using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    public LoadSceneMode mode = LoadSceneMode.Single;

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, mode);
    }

    public void LoadByName(string name)
    {
        SceneManager.LoadScene(name, mode);
    }
}
